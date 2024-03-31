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
        List<Model.Society> societies = new List<Model.Society>();
        Model.Util utilObj = new Model.Util();
        public Student(string user_id)
        {
            student = new Model.Student();

            student.initialize(user_id);

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

        
        private void regNewSociety_Click(object sender, EventArgs e)
        {
            DB_Connection dbConnector = new DB_Connection();

            List<object> formInput = new List<object>();

            formInput.Add(societyName.Text);
            formInput.Add(societySlogan.Text);
            formInput.Add(societyDesc.Text);
            formInput.Add(availableMentors.Text);

            // convert the image to byte stream
            byte[] imageBytes = utilObj.convertToByteStream(uploadImgPicBox.Image);

            formInput.Add(imageBytes);
            formInput.Add(student.GetUserId());


            dbConnector.executeInsert(formInput, "Societies");
        }

        public void setUsernameAndPic()
        {
            this.userName.Text = student.GetUsername();
            this.userPic.Image = student.GetUserImage();
        }

        private void Student_Load(object sender, EventArgs e)
        {
            setUsernameAndPic();
            showSocieties();
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
