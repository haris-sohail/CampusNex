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
            InitializeComponent();
            initializeStudent(user_id);
            initializeEvents();
            
        }

        private void initializeStudent(string user_id)
        {
            // Initialize Student 
            student = new Model.Student(user_id);
            // Hide Member Request Btn
            MemberReqBtn.Visible = false;
            // Attach Members to Society
            foreach (var m in student.Members)
            {
                foreach(var s in societies)
                {
                    if(m.SocietyId == s.SocietyId)
                    {

                        s.Members.Add(m);
                        // Enable Member Request Btn only 
                        // If the Student is Head of a Society
                        if (m.IsHead)
                        {
                            MemberReqBtn.Visible = true;
                        }
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

            regNewSociety.IndicateFocus = false;
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
            formInput.Add(student.StudentId);

            
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



        //registration button for student registration in society
        private void member_Registration(object sender, EventArgs e)     
        {
            DB_Connection dbConnector = new DB_Connection();
            string societyId = dbConnector.getSocietyId(societyNameRegField.Text).ToString();   //getting soicetyId and converting it to string
            bool isHead = false;   //will always be false for members
            List<object> formInput = new List<object>();
            formInput.Add(student.StudentId);
            formInput.Add(societyId);
            formInput.Add(datePickerRegStudent.Value);
            formInput.Add(isHead);            
            formInput.Add(societyStudentRegTextBox.Text);

            dbConnector.executeInsert2(formInput, "Members");
            // Clear Fields
            societyStudentRegTextBox.Text = "";

            MessageBox.Show("Member Registration request sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            StudentPages.SelectedIndex = 0;   //will take user bcak to socities display page after user has pressed confirm button
            regViewSocietyButton.IndicateFocus = false;
        }

        private void StudentRegistrationTab(string societyName, System.Drawing.Image societyLogo)
        {
            //Auto-Fill Fields of Data
            societyNameRegField.Text = societyName;   
            logoStudentReg.Image = societyLogo;
            idRegField.Text = student.RollNo;
            nameRegField.Text = student.Username;
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
            allEventPanel.Controls.Clear();
            societyEventPanel.Controls.Clear();

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
                        eImage = utilObj.getImage(e.EventImg),
                        eStatus = e.Status

                    };

                    if (e.Status == "accepted")
                    {
                        // Add all accepted events to Panel 1
                        allEventPanel.Controls.Add(c);
                    }
                   
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

        // Member Request Data For Head
        private void loadReqData()
        {
            // Fetch society Id
            int sId = -1;
            foreach (var m in student.Members)
            {
                if (m.IsHead)
                {
                    sId = m.SocietyId;
                }
            }

            DB_Connection dbConnector = new DB_Connection();
            // Query to select data to populate Society Request Data Grid
            string query = "SELECT " +
                "U.username AS user_name, S.society_name,M.member_id" +
                " FROM Members M JOIN Students St ON M.student_id = St.student_id" +
                " JOIN Users U ON St.user_id = U.user_id" +
                " JOIN Societies S ON M.society_id = S.society_id" +
                " WHERE M.status = 'pending' and M.society_id = " + sId.ToString();


            Console.WriteLine(query);

            List<List<object>> selectResult = dbConnector.executeSelect(query);
            memReqGrid.Rows.Clear();
            //// Add society cards from the select results
            foreach (var row in selectResult)
            {
                // Get the columns in the correct order
                string societyName = row[1].ToString();
                string memName = row[0].ToString();
                string memId = row[2].ToString();

                // Populate DataGrid
                memReqGrid.Rows.Add(new Object[]
                {
                    memId,
                    societyName,
                    memName,
                    "More Details",
                    "Accept"
                });

            }
            
        }

        private void memReqGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (memReqGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    DataGridViewRow clickedRow = memReqGrid.Rows[e.RowIndex];
                    // Extract Request ID
                    int cellValue = int.Parse(clickedRow.Cells[0].Value.ToString());

                    DB_Connection DB_Connector = new DB_Connection();
                    // Set status to accepted
                    string tableName = "Members";
                    string[] scolumns = { "status" };
                    string[] wcolumns = { "member_id" };
                    object[] values = { "accepted", cellValue };

                    // Call the UpdateData method
                    bool success = DB_Connector.UpdateData(tableName, scolumns, wcolumns, values);
                    loadReqData();
                }
            }
        }

        private void MemberReqBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage("Member Requests");
            loadReqData();
        }
    }
}
