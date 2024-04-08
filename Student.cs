using Bunifu.UI.WinForms;
using CampusNex.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using static CampusNex.Student;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Net.Mime.MediaTypeNames;

namespace CampusNex
{
    public partial class Student : Form
    {
        Model.Student student;
        List<Model.Society> societies = new List<Model.Society>();
        List<Model.Event> events = new List<Model.Event>();
        Model.Util utilObj = new Model.Util();



        public Student(string user_id)
        {
            
            initializeSocieties();
            initializeStudent(user_id);
            initializeEvents();
            InitializeComponent();
        }

        private void initializeStudent(string user_id)
        {
            // Initialize Student 
            student = new Model.Student(user_id);

            // Attach Members to Society
            foreach (var m in student.Members)
            {
                foreach(var s in societies)
                {
                    if(m.SocietyId == s.SocietyId)
                    {
                        s.Members.Add(m);
                    }
                }
            }
        }
        private void initializeEvents()
        {
            // Get Events count from database
            int count = utilObj.getCount("Events");
            for (int i = 0; i < count; i++)
            {
                Model.Event e = new Model.Event(i+1);
                events.Add(e);
            }
            // Link events with Societies
            foreach (var e in events)
            {
                foreach(var s in societies)
                {
                    if (e.SocietyId == s.SocietyId)
                    {
                        s.Events.Add(e);
                    }
                }
               
            }
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

        private void addHead(int userID, int society_id)
        {
            DB_Connection dbConnector = new DB_Connection();

            int userIDforStudent = userID;
            int societyId = society_id;   //getting soicetyId and converting it to string
            bool isHead = true;
            List<object> formInput = new List<object>();

            formInput.Add(userIDforStudent);
            formInput.Add(societyId);
            formInput.Add(datePickerRegStudent.Value);
            formInput.Add(isHead);
            formInput.Add(societyStudentRegTextBox.Text);


            dbConnector.executeInsert2(formInput, "Members");

        }


        private void Add_Society(string Name, string Slogan, string Acronym, string Head, string Mentor, System.Drawing.Image logo, string description, int societyId)
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
                addHead(student.GetUserId(), societyId);
                System.Drawing.Image societyLogo = clickedCard.sImage;
                string societyDesc = description;
                // Update the labels on the tab with the details
                titleViewSociety.Text = societyName;    
                sloganViewSociety.Text = societySlogan;
                accViewSociety.Text = societyAcronym;
                headViewSociety.Text = societyHead;
                logoViewSociety.Image = societyLogo;
                descViewSociety.Text = societyDesc;

              



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

                Add_Society(society.Name, society.Slogan, acronym, headName, mentorName, societyImg, society.Description, society.SocietyId);    //society id added as another parameter
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

            // Show registration request sent popup
            MessageBox.Show("Registration request sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Navigate back to the Societies page
            StudentPages.SetPage("Societies");
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




        private void Confrim_Click(object sender, EventArgs e)     //registration button for student registration in society
        {
            DB_Connection dbConnector = new DB_Connection();

            int userIDforStudent = student.GetUserId();
            string societyId = dbConnector.getSocietyId(societyNameRegField.Text).ToString();   //getting soicetyId and converting it to string
            bool isHead = false;   //will always be false for members
            List<object> formInput = new List<object>();

            formInput.Add(userIDforStudent);
            formInput.Add(societyId);
            formInput.Add(datePickerRegStudent.Value);
            formInput.Add(isHead);            
            formInput.Add(societyStudentRegTextBox.Text);


            dbConnector.executeInsert2(formInput, "Members");

            MessageBox.Show("Member Registration request sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

           


            StudentPages.SelectedIndex = 0;   //will take user bcak to socities display page after user has pressed confirm button


        }

        private void StudentRegistrationTab(string societyName, System.Drawing.Image societyLogo)
         {
           
   
           string studentName = null;
           string rollNumber = null;


           int userIDforStudent = student.GetUserId();
    

             string query = "SELECT Users.username AS StudentName, Students.roll_number AS RollNumber "+
             "FROM Users "+
             "INNER JOIN Students ON Users.user_id = Students.user_id " +
             "WHERE Users.user_id = '" + userIDforStudent + "'";

             DB_Connection dbConnector = new DB_Connection();

               try   //we need the user's name and roll number from db
               {
                      List<List<object>> selectResult = dbConnector.executeSelect(query);
                      if (selectResult != null && selectResult.Count > 0 && selectResult[0].Count > 0)
                       {
            
                          studentName = selectResult[0][0].ToString();
                          rollNumber = selectResult[0][1].ToString();

          
                       }
               }
               catch (Exception ex)
               {
     
                MessageBox.Show("Error: " + ex.Message);
                }

   


                 societyNameRegField.Text = societyName;   //automatically filled fields of already present data
                logoStudentReg.Image = societyLogo;
                  idRegField.Text = rollNumber;
                 nameRegField.Text = studentName;
    

    

         }

        private void regViewSocietyButton_Click(object sender, EventArgs e)    //on student page, tab 'view society'
        {

            string societyName = titleViewSociety.Text;
            System.Drawing.Image societyLogo = logoViewSociety.Image;

            // this function will help us switch to tab for student registartion and pass soceity name and logo as well
            StudentRegistrationTab(societyName, societyLogo);



            StudentPages.SelectedIndex = 4;

        }

        private void eventsBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage(((Control)sender).Text);
            showEvents();
        }

        private void showEvents()
        {
            // Parse Each event of society 
            // and add it to Panel

            foreach (var s in societies)
            {
                foreach(var e in s.Events)
                {
                    eventCard c = new eventCard()
                    {
                        sName = s.Name,
                        eName = e.Title,
                        eDate = e.Date,
                        eTime = e.Time.ToString(),
                        eImage = utilObj.getImage(e.EventImg)

                    };
                    // Add all events to Panel 1
                    allEventPanel.Controls.Add(c);

                    // Add only Society Relevant Events to Panel 2
                    foreach(var m in student.Members)
                    {
                        if(m.SocietyId == e.SocietyId)
                        {
                            societyEventPanel.Controls.Add(c);
                        }
                    }
                }
            }
        }
    }
}
