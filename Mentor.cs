using Bunifu.UI.WinForms;
using CampusNex.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Net.Mime.MediaTypeNames;

namespace CampusNex
{
    public partial class Mentor : Form
    {
        Model.Mentor mentor;
        List<Model.Society> societies = new List<Model.Society>();
        Model.Util utilObj = new Model.Util();

        public Mentor(string user_id)
        {
            mentor = new Model.Mentor();
            mentor.initialize(user_id);
            mentor.setMentorId();
            initializeSocieties();

            InitializeComponent();
        }

        public void initializeSocieties()
        {
            List<List<object>> allSocieties = utilObj.getAllSocieties();

            // initialize all societies
            foreach (var society in allSocieties)
            {
                Model.Society newSociety = new Model.Society();

                newSociety.initialize(society);

                societies.Add(newSociety);
            }
        }

        private void societiesBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage(((Control)sender).Text);
        }

        private void Add_Society(string Name, string Slogan, string Acronym, string Head, string Mentor, System.Drawing.Image logo, string description)
        {
            societyCard newCard = new societyCard()
            {
                sName = Name,
                sSlogan = Slogan,
                sAcronym = Acronym,
                sHead = Head,
                sMentor = Mentor,
                sImage = logo
            };

            // Subscribe to the "View More" button click event
            newCard.ViewBtnClicked += (sender, e) =>
            {
                // Switch to the "View More" tab when the button is clicked
                StudentPages.SelectedIndex = 3; // Index of the "View More" tab



                // Get the details from the clicked user control object
                societyCard clickedCard = sender as societyCard;
                string societyName = clickedCard.sName;
                string societySlogan = clickedCard.sSlogan;
                string societyAcronym = clickedCard.sAcronym;
                string societyHead = clickedCard.sHead;
                System.Drawing.Image societyLogo = clickedCard.sImage;
                string societyDesc = description;
                // Update the labels on the tab with the details
                titleViewSociety.Text = societyName;
                sloganViewSociety.Text = societySlogan;
                accViewSociety.Text = societyAcronym;
                headViewSociety.Text = societyHead;
                logoViewSociety.Image = societyLogo;
                descViewSociety.Text += societyDesc;



            };

            societyCardsPanel.Controls.Add(newCard);



        }


        public string getHeadName(String head_Id)   //take user id - go to student - go to members
        {
            DB_Connection dbConnector = new DB_Connection();
             string query = " select username from Users " +
                 "INNER JOIN Students " +
                 "ON Students.user_id = Users.user_id " +
                 "WHERE Students.student_id = " + head_Id;

           // string query = "SELECT username FROM Users WHERE user_id = " + head_Id;


            // each list contains an individual row's data

            List<List<object>> selectResult = dbConnector.executeSelect(query);

            string headName = selectResult[0][0].ToString();
            return headName;
        }

        public void setUsernameAndPic()
        {
            this.userName.Text = mentor.GetUsername();
            this.userPic.Image = mentor.GetUserImage();
        }

        public System.Drawing.Image getImage(byte[] imageBlob)
        {
            System.Drawing.Image societyImg;

            using (MemoryStream memoryStr = new MemoryStream(imageBlob))
            {
                societyImg = System.Drawing.Image.FromStream(memoryStr);
            }

            return societyImg;
        }



        private void Mentor_Load(object sender, EventArgs e)
        {   
            setUsernameAndPic();
            showSocieties();
        }

        public System.Drawing.Image ResizeImage(System.Drawing.Image image, int width, int height)
        {
            // Create a new bitmap with the desired dimensions
            Bitmap resizedImage = new Bitmap(width, height);

            // Draw the original image onto the new bitmap using Graphics
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(image, 0, 0, width, height);
            }

            // Return the resized image
            return resizedImage;
        }

        public void showSocieties(string searchTxt = null)
        {
            // Add society cards from the society list
            foreach (var society in societies)
            {
                System.Drawing.Image societyImg = utilObj.getImage(society.Logo);

                // get mentor and head names
                string mentorName = utilObj.getMentorName(society.MentorId.ToString());
                string headName = utilObj.getHeadName(society.HeadId.ToString());


                string acronym = utilObj.getAcronym(society.Name);

                Add_Society(society.Name, society.Slogan, acronym, headName, mentorName, societyImg, society.Description);
            }
        }

        private void loadReqData()
        {
            DB_Connection dbConnector = new DB_Connection();
            // Query to select data to populate Society Request Data Grid
            string query = "SELECT society_logo, society_name, u.username " +
                       "FROM societies s " +
                       "JOIN students st ON s.head_id = st.student_id " +
                       "JOIN users u ON st.user_id = u.user_id " +
                       "WHERE s.status = 'pending' AND mentor_id = " + mentor.MentorId;


            Console.WriteLine(query);

            List<List<object>> selectResult = dbConnector.executeSelect(query);
            socReqGrid.Rows.Clear();
            //// Add society cards from the select results
            foreach (var row in selectResult)
            {
                // Get the columns in the correct order
                string societyName = row[1].ToString();
                string sHeadName = row[2].ToString();

                byte[] slogo = (byte[])row[0];
                
                System.Drawing.Image societyImg = getImage(slogo);
                System.Drawing.Image resizedImage = ResizeImage(societyImg, 32, 32);
                // Populate DataGrid
                socReqGrid.Rows.Add(new Object[]
                {
                    resizedImage,
                    societyName,
                    sHeadName
                });

            }
        }
        private void reqBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage(((Control)sender).Text);
            loadReqData();
        }

        private void socReqGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4) 
            {
                if (socReqGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    DataGridViewRow clickedRow = socReqGrid.Rows[e.RowIndex];
                    // Extract Society Name
                    string cellValue = clickedRow.Cells[1].Value.ToString();

                    DB_Connection DB_Connector = new DB_Connection();
                    // Set status to accepted
                    string tableName = "Societies";
                    string[] scolumns = { "status" };
                    string[] wcolumns = { "society_name" };
                    object[] values = { "accepted", cellValue  };
     
                    // Call the UpdateData method
                    bool success = DB_Connector.UpdateData(tableName, scolumns, wcolumns,values);
                    loadReqData();
                    showSocieties();
                }
            }
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            // Remove the existing societies
            societyCardsPanel.Controls.Clear();

            // Search the societies 
            showSocieties(searchBar.Text);
        }

    }
}
