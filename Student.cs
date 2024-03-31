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
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace CampusNex
{
    public partial class Student : Form
    {
        Model.Student student;
        public Student(string user_id)
        {
            student = new Model.Student();
            student.SetUserId(int.Parse(user_id));

            InitializeComponent();
        }

        private void societiesBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage(((Control)sender).Text);
        }

        private void Add_Society(string Name, string Slogan, string Acronym, string Head, string Mentor, System.Drawing.Image logo, string description)
        {
            //second adjusment   -- original
            /* societyCardsPanel.Controls.Add(new societyCard()
             {
                 sName = Name,
                 sSlogan = Slogan,
                 sAcronym = Acronym,
                 sHead  = Head,
                 sMentor = Mentor,
                 sImage = logo
             });*/
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

        public string getHeadName(String headId)
        {
            DB_Connection dbConnector = new DB_Connection();
            string query = " select username from Users " +
                "INNER JOIN Students " +
                "ON Students.user_id = Users.user_id " +
                "WHERE Students.student_id = " + headId;

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

        public System.Drawing.Image getImage(byte[] imageBlob)
        {
            System.Drawing.Image img = null;
            
            
            using (MemoryStream memoryStr = new MemoryStream(imageBlob))
            {
                img = System.Drawing.Image.FromStream(memoryStr);
            }
            
          
            return img;
        }

        public void showSocieties(string searchTxt = null)
        {
            // get societies from database

            DB_Connection dbConnector = new DB_Connection();
            string query = "SELECT * FROM Societies WHERE STATUS='accepted'";

            if(!(searchTxt is null))
            {
                query += $" AND (Societies.society_name LIKE '%{searchTxt}%'\r\n OR Societies.society_slogan LIKE '%{searchTxt}%'\r\n OR Societies.society_description LIKE '%{searchTxt}%'\r\n OR Societies.creation_date LIKE '%{searchTxt}%')";
            }

            // each list contains an individual row's data

            List<List<object>> selectResult = dbConnector.executeSelect(query);

            // Add society cards from the select results
            foreach (var row in selectResult)
            {
                // Get the columns in the correct order
                string societyName = row[1].ToString();
                string sSlogan = row[2].ToString();
                string sDesc = row[3].ToString();    //new addition
                string sMentorId = row[4].ToString();
                string sHeadId = row[5].ToString();


                byte[] imageBlob = (byte[])row[7];     


                System.Drawing.Image societyImg = getImage(imageBlob);     


                // get mentor and head names
                string mentorName = getMentorName(sMentorId);

                string headName = getHeadName(sHeadId);

                string acronym = getAcronym(societyName);

                Add_Society(societyName, sSlogan, acronym, headName, mentorName, societyImg, sDesc);
            }
        }
        public void setUsernameAndPic()
        {
            DB_Connection dbConnector = new DB_Connection();

            string query = "select username, user_pic from users where user_id = " + student.GetUserId();

            List<List<object>> selectResult = dbConnector.executeSelect(query);

            userName.Text = selectResult[0][0].ToString();

            byte[] userPicBytes = selectResult[0][1] as byte[];

            System.Drawing.Image userImg = getImage(userPicBytes);

            userPic.Image = userImg;
        }

        private void rSocietyForm_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage(((Control)sender).Text);
            // Load Dropdown of available Mentors
            string query = @"
            SELECT U.username AS mentor_name
            FROM Mentors M
            INNER JOIN Users U ON M.user_id = U.user_id
            LEFT JOIN Societies S ON M.mentor_id = S.mentor_id
            WHERE U.role = 'mentor'
            GROUP BY M.mentor_id
            HAVING COUNT(S.society_id) < 2;"
            ;
            DB_Connection dbConnector = new DB_Connection();
            List<List<object>> selectResult = dbConnector.executeSelect(query);
            // Add society cards from the select results
  
            foreach (var row in selectResult)
            {
                // Get the columns in the correct order
                string mentorName = row[0].ToString();
                Console.WriteLine(mentorName);
                availableMentors.Items.Add(mentorName);
            }
        }

        private void uploadImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDial = new OpenFileDialog();
            fileDial.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff)|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff";

            if (fileDial.ShowDialog() == DialogResult.OK)
            {
                uploadImgPicBox.Image = new Bitmap(fileDial.FileName);
            }
        }

        public byte[] convertToByteStream(System.Drawing.Image image)
        {
            byte[] bytes;

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat); // Choose appropriate format
                bytes = ms.ToArray();
            }

            return bytes;
        }
        private void regNewSociety_Click(object sender, EventArgs e)
        {
            DB_Connection dbConnector = new DB_Connection();

            List<object> formInput = new List<object>();

            formInput.Add(societyName.Text);
            formInput.Add(societySlogan.Text);
            formInput.Add(societyDesc.Text);
            formInput.Add(availableMentors.Text);

            // convert the image to byte stream
            byte[] imageBytes = convertToByteStream(uploadImgPicBox.Image);

            formInput.Add(imageBytes);
            formInput.Add(student.GetUserId());


            dbConnector.executeInsert(formInput, "Societies");
        }

        private void Student_Load(object sender, EventArgs e)
        {
            setUsernameAndPic();
            showSocieties();
        }


        private void societyReg_Click(object sender, EventArgs e)
        {

        }

        private void societyCardsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SocietiesPage_Click(object sender, EventArgs e)
        {

        }

        private void EventsPage_Click(object sender, EventArgs e)
        {

        }

        private void userPic_Click(object sender, EventArgs e)
        {

        }

        private void headLabelViewSociety_Click(object sender, EventArgs e)
        {

        }

        private void titleViewSociety_Click(object sender, EventArgs e)
        {

        }

        private void descViewSociety_Click(object sender, EventArgs e)
        {

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
