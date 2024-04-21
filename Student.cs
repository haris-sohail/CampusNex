using Bunifu.UI.WinForms;
using CampusNex.Model;
using CampusNex.PopUps;
using Google.Protobuf;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static Bunifu.UI.WinForms.BunifuSnackbar;
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
        List<Model.Announcement> announcements = new List<Model.Announcement>();
        Model.Util utilObj = new Model.Util();

        // Event Handler for togling
        // Registration and Announcements
        private EventHandler currentHandler;

        public Student()
        {

        }
        public Student(string user_id)
        {
            initializeSocieties();
            initializeStudent(user_id);
            InitializeComponent();
            setControls();
            initializeEvents();
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

        private void setControls()
        {
            // Hide Member Request Btn
            MemberReqBtn.Visible = false;
            // Hide Event Reg Button
            organizeEventBtn.Visible = false;
            // Hide add announcement button 
            addAnnouncementBtn.Visible = false;

            foreach (var m in student.Members)
            {
                // Show Organize Event button only if
                // student is a member
                organizeEventBtn.Visible = true;
                foreach (var s in societies)
                {
                    if (m.SocietyId == s.SocietyId && m.status != "pending")
                    {
                        // Enable Member Request and add announcement Btn only 
                        // If the Student is Head of a Society
                        if (m.IsHead)
                        {
                            MemberReqBtn.Visible = true;
                            addAnnouncementBtn.Visible = true;
                        }
                    }
                }
            }
        }

        private void initializeStudent(string user_id)
        {
            // Initialize Student 
            student = new Model.Student(user_id);
            // Add student to its relevant Societies
            foreach (var m in student.Members)
            {
                foreach (var s in societies)
                {
                    if(m.SocietyId == s.SocietyId && m.status != "pending")
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
                if (newSociety.status != "pending")
                {
                    societies.Add(newSociety);
                }   
            }
        }

        private void societiesBtn_Click(object sender, EventArgs e)
        {
            // Navigate back to the Societies page
            StudentPages.SetPage("Societies");
        }

        private void Add_Announcement(string title, string body, string societyName, string postedAt, string expiresAt, string priority)
        {
            AnnouncementCard newAnnouncement = new AnnouncementCard()
            {
                title = title,
                announcement_body = body,
                society_name = societyName,
                posted_at = postedAt,
                expires_at = expiresAt
            };

            // set the border color according to priority
            if (priority.Equals("Low"))
            {
                newAnnouncement.BorderColor = Color.Green;
            }

            else if (priority.Equals("Medium"))
            {
                newAnnouncement.BorderColor = Color.Orange;
            }

            else
            {
                newAnnouncement.BorderColor = Color.IndianRed;
            }
            // set color
            newAnnouncement.setColor();
            announcementFlowLayoutPanel.Controls.Add(newAnnouncement);
        }
        private void Add_Society(FlowLayoutPanel p, string Name, string Slogan, string Acronym, string Head, string Mentor, System.Drawing.Image logo, string description, int societyId)
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
                string societyMentor = clickedCard.sMentor;

                System.Drawing.Image societyLogo = clickedCard.sImage;
                string societyDesc = description;
                // Update the labels on the tab with the details
                titleViewSociety.Text = societyName;    
                sloganViewSociety.Text = societySlogan;
                accViewSociety.Text = societyAcronym;
                headViewSociety.Text = societyHead;
                logoViewSociety.Image = societyLogo;
                descViewSociety.Text = societyDesc;
                mentorViewSociety.Text = societyMentor;

                // Change Button Label 
                // and Button OnClick Attribute
                if(p.Name == "societyCardsPanel")
                {
                    customSocietyBtn.Text = "Register";
                    customSocietyBtn.Click -= currentHandler;
                    currentHandler = regForSociety_Click;
                    customSocietyBtn.Click += currentHandler;
                }
                else
                {
                    customSocietyBtn.Text = "Announcements";
                    customSocietyBtn.Click -= currentHandler;
                    currentHandler = societyAnnouncement_Click;
                    customSocietyBtn.Click += currentHandler;
                }
            };

            p.Controls.Add(newCard);


        }
        private void regForSociety_Click(object sender, EventArgs e)
        {

            string societyName = titleViewSociety.Text;
            System.Drawing.Image societyLogo = logoViewSociety.Image;

            // this function will help us switch to tab for student registartion and pass soceity name and logo as well
            StudentRegistrationTab(societyName, societyLogo);
            StudentPages.SelectedIndex = 4;
        }

        protected void initializeAnnouncements()
        {
            announcements.Clear();

            // get the specific announcements for logged in student
            List<List<object>> announcementResults = utilObj.getAnnouncements(student.UserId);

            // initialize all announcements
            foreach (var announcement in announcementResults)
            {
                Model.Announcement newAnnouncement = new Model.Announcement();
                newAnnouncement.initialize(announcement);
                announcements.Add(newAnnouncement);
            }
        }

        protected void addAnnouncementCards()
        {
            announcementFlowLayoutPanel.Controls.Clear();
            initializeAnnouncements();

            foreach (var announcement in announcements)
            {
                if(utilObj.announcement_is_expired(announcement) == false)
                {
                    Add_Announcement(announcement.announcementTitle, announcement.announcementBody, announcement.societyName, announcement.postedAt.ToString(), announcement.validTill.ToString(), announcement.priority);
                }
            }
        }

        // @Haris Announcement Page Entry Point
        private void societyAnnouncement_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage("Announcements");

            addAnnouncementCards();
        }

        public void showSocieties(string searchTxt = null)
        {
            // Clear Panels
            societyCardsPanel.Controls.Clear();
            regSocPanel.Controls.Clear();
            currentHandler = regForSociety_Click;

            // Extract registered Society Id's
            List<int> Ids = new List<int>();
            foreach (var m in student.Members)
            {
                if(m.status != "pending")
                {
                    Ids.Add(m.SocietyId);
                }  
            }

            foreach (var s in societies)
            {
                System.Drawing.Image societyImg = utilObj.getImage(s.Logo);

                // Check if society is registered
                if (Ids.Contains(s.SocietyId))
                {
                    // Populate panel for registered societies
                    Add_Society(regSocPanel, s.Name, s.Slogan, s.acronym, s.headName, s.mentorName, societyImg, s.Description, s.SocietyId);
                }
                else
                {
                    // Populate panel for all societies
                    Add_Society(societyCardsPanel, s.Name, s.Slogan, s.acronym, s.headName, s.mentorName, societyImg, s.Description, s.SocietyId);
                }
            }


        }

        private void rSocietyForm_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage(((Control)sender).Text);
            // Load Dropdown of available Mentors
            string query = @"
            SELECT U.username AS mentor_name
            FROM Mentors M
            INNER JOIN CUsers U ON M.user_id = U.user_id
            LEFT JOIN Societies S ON M.mentor_id = S.mentor_id
            WHERE U.role = 'mentor'
            GROUP BY M.mentor_id, U.username
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

        private void uploadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDial = new OpenFileDialog();
            fileDial.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff)|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff";

            if (fileDial.ShowDialog() == DialogResult.OK)
            {
                eimgHolder.Image = new Bitmap(fileDial.FileName);
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

            // Insertion in Societies and Members table
            dbConnector.ExecuteInsert(formInput, "Societies");

            // Show registration request sent popup
            MessageBox.Show("Registration request sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear Input Fields
            societyName.Clear();
            societySlogan.Clear();
            societyDesc.Clear();
            availableMentors.Items.Clear();
            uploadImgPicBox.Image = null;

            // Navigate back to the Societies page
            StudentPages.SetPage("Societies");
        }

        // Implement Dynamic search
        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            foreach (societyCard card in societyCardsPanel.Controls)
            {
                // Check if the control is a UserControl
                if (card is UserControl)
                {
                    card.toggleDisplay(searchBar.Text);
                }
            }

        }



        //registration button for student registration in society
        private void member_Registration(object sender, EventArgs e)     
        {
            DB_Connection dbConnector = new DB_Connection();
            string societyId = dbConnector.GetSocietyId(societyNameRegField.Text).ToString();   //getting soicetyId and converting it to string
            bool isHead = false;   //will always be false for members
            List<object> formInput = new List<object>();
            formInput.Add(student.StudentId);
            formInput.Add(societyId);
            formInput.Add(datePickerRegStudent.Value);
            formInput.Add(isHead);            
            formInput.Add(societyStudentRegTextBox.Text);

            dbConnector.ExecuteInsert2(formInput, "Members");
            // Clear Fields
            societyStudentRegTextBox.Text = "";

            MessageBox.Show("Member Registration request sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            StudentPages.SelectedIndex = 0;   //will take user bcak to socities display page after user has pressed confirm button
            customSocietyBtn.IndicateFocus = false;
        }

        private void StudentRegistrationTab(string societyName, System.Drawing.Image societyLogo)
        {
            //Auto-Fill Fields of Data
            societyNameRegField.Text = societyName;   
            logoStudentReg.Image = societyLogo;
            idRegField.Text = student.RollNo;
            nameRegField.Text = student.Username;
        }

      

        private void eventsBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage("Events");
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
                    c.eId = e.EventId;
                    c.DetailsBtn += (sender, eve) =>
                    {
                        StudentPages.SelectedIndex = 6;
                        eventDetails(eve);
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

        private void eventDetails(eventData e)
        {
            foreach(var s in societies)
            {
                foreach (var eve in s.Events)
                {
                    // Populate Page
                    if (e.Id == eve.EventId)
                    {
                        socImg.Image = utilObj.getImage(s.Logo);
                        eveImg.Image = utilObj.getImage(eve.EventImg);
                        socTitle.Text = s.Name;
                        eveTitle.Text = eve.Title;

                        eveDesc.Text = eve.Description;
                        eveTime.Text = eve.Time.ToString();
                        eveDate.Text = eve.Date;
                        eveLoc.Text = eve.Location;
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
                " JOIN CUsers U ON St.user_id = U.user_id" +
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

                                //need to add user id of that particular member

                     
                });

            }
            
        }

        private void memReqGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex != 0)
           // {
                //member approved
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

                //if view button clicked on member request table
                if (e.ColumnIndex == 3)
                {
                    if (memReqGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {
                        DataGridViewRow clickedRow = memReqGrid.Rows[e.RowIndex];

                        string memberId = clickedRow.Cells[0].Value.ToString();
                        foreach (var m in student.Members)
                        {
                            
                            Console.Write(memberId);                            
                            System.Drawing.Image socPic;
                            System.Drawing.Image memPic;
                            int socId = m.SocietyId;
                            socPic = utilObj.getSocietyImage(socId);
                            memPic = utilObj.getMemberImage(int.Parse(memberId));
                            String socName = utilObj.getSocietyName(socId.ToString());
                            string memberInt = utilObj.getMemberInterest(int.Parse(memberId));
                            string memberName = utilObj.getMemberName(int.Parse(memberId));
                            string dateJoined = m.getMemberDateJoined(int.Parse(memberId));


                            MemberRequest popup = new MemberRequest(m, socName, socPic, memberInt, memberName, memPic, dateJoined);
                            popup.ShowDialog();
                            break;
                        }




                    }
                }
           // }
        }

        private void MemberReqBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage("Member Requests");
            loadReqData();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage("Events");
        }

        private void organizeEventBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage("Organize An Event !!");
            // Set DropDown
            foreach (var s in societies)
            {
                foreach(var m in s.Members)
                {
                    foreach (var i in student.Members)
                    {
                        if (m.MemberId == i.MemberId)
                        {
                            // Populate Society Name in
                            // Drop down
                            chooseSocDD.Items.Add(s.Name);
                        }
                    }
                }
            }
        }

        private void regEventBtn_Click(object sender, EventArgs e)
        {
            // Register an event
            Event newEvent = new Event();

            // Get Society ID
            foreach (var s in societies)
            {
                if(s.Name == chooseSocDD.Text)
                {
                    newEvent.SocietyId = s.SocietyId;
                }
            }
            // Get Title, Type and Description
            newEvent.Title = eTitle.Text;
            newEvent.Type = eType.Text;
            newEvent.Description = eDesc.Text;

            // Get Date, Time and Location
            // Get the selected date and time from the DateTimePicker
            DateTime tmp = eDt.Value;
            string val = dateVal(tmp.ToShortDateString());

            Console.WriteLine(val);
            newEvent.Date = val;
            newEvent.Time = tmp.TimeOfDay;
            newEvent.Location = elocation.Text;


            // Get status and Organizer Id
            newEvent.Status = "pending";
            newEvent.OrganizerId = student.StudentId;

            byte[] imageBytes = utilObj.convertToByteStream(eimgHolder.Image);
            // Get Image
            newEvent.EventImg = imageBytes;

            // Add to database
            Event.AddEvent(newEvent);
            // Add to runtime
            foreach (var s in societies)
            {
                if(s.SocietyId == newEvent.SocietyId)
                {
                    s.Events.Add(newEvent);
                    break;
                }
            }
            // Clear Fields
            chooseSocDD.Items.Clear();
            elocation.Clear();
            eTitle.Clear();
            eType.Clear();
            eDesc.Clear();
            eDt.Text = "";
            eimgHolder.Image = null;

            // Navigate to Events Page
            StudentPages.SetPage("Events");
            showEvents();
        }

        private string dateVal(string dt)
        {
            string[] parts = dt.Split('/');

            // Extract day, month, and year parts
            string day = parts[0];
            string month = parts[1];
            string year = parts[2];

            // Pad day and month parts with leading zeros if necessary
            day = day.PadLeft(2, '0');
            month = month.PadLeft(2, '0');

            // Create the formatted date string
            return $"{year}-{day}-{month}";
        }

        private void addAnnouncementBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage("addAnnouncementPage");
        }

        private void previousPageBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage("Societies");
        }

        public List<List<object>> getSocietyAndHeadId(string user_id)
        {
            DB_Connection dbConnector = new DB_Connection();

            string query = "SELECT SOCIETIES.society_id, STUDENTS.student_id\r\nFROM SOCIETIES INNER JOIN \r\nMEMBERS ON \r\nSOCIETIES.society_id = MEMBERS.society_id\r\nINNER JOIN STUDENTS ON\r\nSTUDENTS.student_id = MEMBERS.student_id\r\nINNER JOIN CUSERS ON\r\nCUSERS.user_id = STUDENTS.user_id\r\nWHERE CUSERS.user_id = " + user_id;

            List<List<object>> selectResult = dbConnector.executeSelect(query);

            return selectResult;
        }

        public bool isEmptyFieldPresent_AnnouncementForm()
        {
            if((titleTxt.Text.Length == 0) || (bodyTxt.Text.Length == 0) || (validTillPicker.Text.Length == 0)
                || (hoursCombo.Text.Length == 0) || (minsCombo.Text.Length == 0) || (am_pmCombo.Text.Length == 0)
                || (priorityCombo.Text.Length == 0))
            {
                return true;
            }

            return false;
        }

        public bool isDateTimeValid(DateTime toCheck)
        {
            if (toCheck < DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public List<object> getAnnouncementFormInput()
        {
            if (isEmptyFieldPresent_AnnouncementForm())
            {
                MessageBox.Show("Input field can not be empty", "Post failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StudentPages.SetPage("addAnnouncementPage");
                return null;
            }
            List<object> formData = new List<object>();

            List<List<object>> societyAndHeadId = getSocietyAndHeadId(student.UserId.ToString());

            formData.Add(societyAndHeadId[0][0].ToString());
            formData.Add(societyAndHeadId[0][1].ToString());
            formData.Add(titleTxt.Text);
            formData.Add(bodyTxt.Text);

            string validDate = validTillPicker.Text;
            string hours = hoursCombo.Text;
            string mins = minsCombo.Text;
            string am_pm = am_pmCombo.Text;

            string combinedDateTime = utilObj.getCombinedDateTime(validDate, hours, mins, am_pm);

            if (isDateTimeValid(DateTime.Parse(combinedDateTime)) == false)
            {
                MessageBox.Show("Please enter a valid date and time", "Post failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StudentPages.SetPage("addAnnouncementPage");
                return null;
            }

            formData.Add(combinedDateTime);
            formData.Add(priorityCombo.Text);

            return formData;
        }
        private void postBtn_Click(object sender, EventArgs e)
        {
            DB_Connection dbConnector = new DB_Connection();
            List<object> formInput = getAnnouncementFormInput();
            
            if(formInput != null)
            { 
                dbConnector.ExecuteInsertAnnouncement(formInput);
                MessageBox.Show("Announcement Posted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StudentPages.SetPage("Announcements");
                addAnnouncementCards();
            }
        }

        private void memReqGrid_Paint(object sender, PaintEventArgs e)
        {
            if (memReqGrid.Rows.Count == 0)
            {
                string message = "No entries Yet";
                using (var font = new Font("Verdana", 16, FontStyle.Bold))
                using (var brush = new SolidBrush(Color.White))
                {
                    var stringSize = e.Graphics.MeasureString(message, font);
                    var x = (memReqGrid.Width - stringSize.Width) / 2;
                    var y = (memReqGrid.Height - stringSize.Height) / 2;
                    e.Graphics.DrawString(message, font, brush, x, y);
                }
            }
        }
    }
}
