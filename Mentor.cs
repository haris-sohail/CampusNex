using Bunifu.UI.WinForms;
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
        private String user_id;
        private String mentor_id;
        public Mentor(string user_id)
        {
            InitializeComponent();
            this.user_id = user_id;
            setMentorId();
        }
        private void setMentorId()
        {
            DB_Connection dbConnector = new DB_Connection();
            string query = "SELECT mentor_id FROM Mentors WHERE user_id = " + this.user_id.ToString();
            List<List<object>> selectResult = dbConnector.executeSelect(query);
            this.mentor_id = selectResult[0][0].ToString();
        }

        private void societiesBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage(((Control)sender).Text);
        }

        private void Add_Society(string Name, string Slogan, string Acronym, string Head, string Mentor, System.Drawing.Image logo)
        {
            societyCardsPanel.Controls.Add(new societyCard()
            {
                sName = Name,
                sSlogan = Slogan,
                sAcronym = Acronym,
                sHead  = Head,
                sMentor = Mentor,
                sImage = logo
            });
          

        }

        public string getMentorName(String mentorId)
        {
            DB_Connection dbConnector = new DB_Connection();
            string query = " select username from Users " +
                "INNER JOIN Mentors " +
                "ON Mentors.user_id = Users.user_id " +
                "WHERE Mentors.mentor_id = " + mentorId;

            // each list contains an individual row's data

            List<List<object>> selectResult = dbConnector.executeSelect(query);

            string mentorName = selectResult[0][0].ToString();
            return mentorName;
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

        public string getAcronym(string societyName)
        {
            string[] splitName = societyName.Split(' ');

            string acronym = "";

            foreach(var word in splitName)
            {
                acronym += word[0];
            }

            return acronym;
        }

        public void setUsernameAndPic()
        {
            DB_Connection dbConnector = new DB_Connection();

            string query = "select username, user_pic from users where user_id = " + this.user_id;

            List<List<object>> selectResult = dbConnector.executeSelect(query);

            userName.Text = selectResult[0][0].ToString();

            byte[] userPicBytes = selectResult[0][1] as byte[];

            System.Drawing.Image userImg = getImage(userPicBytes);

            userPic.Image = userImg;
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
            loadSocData();
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

        private void loadSocData(string searchTxt = null)
        {
            // get societies from database

            DB_Connection dbConnector = new DB_Connection();
            string query = "SELECT * FROM Societies where status = 'accepted'";

            if (!(searchTxt is null))
            {
                query += $" AND (Societies.society_name LIKE '%{searchTxt}%'\r\n OR Societies.society_slogan LIKE '%{searchTxt}%'\r\n OR Societies.society_description LIKE '%{searchTxt}%'\r\n OR Societies.creation_date LIKE '%{searchTxt}%')";
            }

            // each list contains an individual row's data

            List<List<object>> selectResult = dbConnector.executeSelect(query);
            societyCardsPanel.Controls.Clear();
            // Add society cards from the select results
            foreach (var row in selectResult)
            {
                // Get the columns in the correct order
                string societyName = row[1].ToString();
                string sSlogan = row[2].ToString();
                string sMentorId = row[4].ToString();
                string sHeadId = row[5].ToString();


                byte[] imageBlob = (byte[])row[7];

                System.Drawing.Image societyImg = getImage(imageBlob);

                // get mentor and head names
                string mentorName = getMentorName(sMentorId);

                string headName = getHeadName(sHeadId); 

                string acronym = getAcronym(societyName);

                Add_Society(societyName, sSlogan, acronym, headName, mentorName, societyImg);
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
                       "WHERE s.status = 'pending' AND mentor_id = " + this.mentor_id;


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
                    loadSocData();
                }
            }
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            // Remove the existing societies
            societyCardsPanel.Controls.Clear();

            // Search the societies 
            loadSocData(searchBar.Text);
        }

        private void societyCardsPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
