/*
 *              CAMPUSNEX CONTROLLER CLASS: Student.cs
 *              
 *              Coded By ACECODERS:
 *              
 *                      -> Kalsoom Tariq (i21-2487)
 *                      -> Haris Sohail (i21-0531)
 *                      -> Aiman Safdar (i21-0588)
 *                      
 */

using CampusNex.Model;
using CampusNex.PopUps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CampusNex
{
    public partial class Student : Form
    {
        // Data Members
        Model.Student student;
        List<Model.Society> societies = new List<Model.Society>();
        List<Model.Event> events = new List<Model.Event>();
        List<Model.Announcement> announcements = new List<Model.Announcement>();
        Model.Util utilObj = new Model.Util();

        // Event Handler for togling
        // Registration and Announcements
        private EventHandler currentHandler;

        /* -------------------------------------------------------------------------

                          Initialization Functions

        ------------------------------------------------------------------------- */


        public Student(string user_id)
        {
            initializeSocieties();
            initializeStudent(user_id);
            InitializeComponent();
            setControls();
            initializeEvents();
            
        }

        // Load Data
        private void Student_Load(object sender, EventArgs e)
        {
            showDashBoard();
            setUsernameAndPic();
            showSocieties();
        }
        // Navigate to Dashboard
        public void showDashBoard()
        {
            StudentPages.SetPage("Dashboard");
            populateDashBoard();
        }
        // Populate Dashboard
        public void populateDashBoard()
        {
            nameLbl.Text = student.Username;
            emailLbl.Text = student.Email;
            userPicBox.Image = student.UserImage;
            idLbl.Text = student.RollNo;
        }
        // Initialize name and Image
        public void setUsernameAndPic()
        {
            this.userName.Text = student.GetUsername();
            this.userPic.Image = student.GetUserImage();
        }

        // Initialize Student Object
        private void initializeStudent(string user_id)
        {
            student = new Model.Student(user_id);
            foreach (var m in student.Members)
            {
                foreach (var s in societies)
                {
                    if (m.SocietyId == s.SocietyId && m.status != "pending")
                    {
                        s.Members.Add(m);
                    }
                }
            }

        }
        // Initialize Event Object
        private void initializeEvents()
        {
            int count = utilObj.getCount("Events");
            for (int i = 0; i < count; i++)
            {
                Model.Event e = new Model.Event(i + 1);
                events.Add(e);
            }
            foreach (var e in events)
            {
                foreach (var s in societies)
                {
                    if (e.SocietyId == s.SocietyId)
                    {
                        s.Events.Add(e);
                    }
                }

            }
        }

        // Set Controls Of Student
        private void setControls()
        {
            MemberReqBtn.Visible = false;
            organizeEventBtn.Visible = false;
            addAnnouncementBtn.Visible = false;
            rSocietyForm.Visible = true;
            foreach (var m in student.Members)
            {
  
                foreach (var s in societies)
                {
                    if (m.SocietyId == s.SocietyId && (m.status != "pending" || m.status != "rejected"))
                    {
                        organizeEventBtn.Visible = true;
                        if (m.IsHead)
                        {
                            MemberReqBtn.Visible = true;
                            addAnnouncementBtn.Visible = true;
                            rSocietyForm.Visible = false;
                        }
                    }
                }
            }
        }

        // Initialize Societies
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
        /* -------------------------------------------------------------------------

                DashBoard Dynamic Functions

        ------------------------------------------------------------------------- */
      
        // Navigate to dashboard
        private void campusNexLbl_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage("Dashboard");
        }

        // Fetch Notification on click
        private void viewMsgs_Click(object sender, EventArgs e)
        {
            fetchNotifications();

        }

        public void fetchNotifications()
        {
            // 01. Show Rejected Society 
            foreach (var s in societies)
            {
                if (s.HeadId == student.StudentId && s.status == "rejected")
                {
                    CNMessage popup = new CNMessage(s.Name + " Rejected", s.Comments);
                    popup.ShowDialog();
                    s.DeleteSociety();
                }
            }
            int index = societies.FindIndex(s => s.HeadId == student.StudentId
                                            && s.status == "rejected");
            if (index != -1)
            {
                societies.RemoveAt(index);
            }
            // 02. Show Rejected Events
            foreach (var e in events)
            {
                if (student.StudentId == e.OrganizerId && e.Status == "rejected")
                {
                    CNMessage popup = new CNMessage(e.Title + " Rejected", e.Comments);
                    popup.ShowDialog();
                    e.DeleteEvent();
                }
            }
            index = -1;
            index = events.FindIndex(e => e.OrganizerId == student.StudentId
                                            && e.Status == "rejected");
            if (index != -1)
            {
                events.RemoveAt(index);
            }

            foreach (var s in societies)
            {
                int idx = s.Events.FindIndex(e => e.OrganizerId == student.StudentId
                                            && e.Status == "rejected");
                if (idx != -1)
                {
                    s.Events.RemoveAt(idx);
                }
            }
            // 02. Show Rejected Member Request
            foreach (var m in student.Members)
            {
                if (m.status == "rejected" && m.IsHead != true)
                {
                    CNMessage popup = new CNMessage("Member Rejection", m.Comments);
                    popup.ShowDialog();
                    m.DeleteMember();
                }
            }
            // Remove from RunTime
            index = -1;
            index = student.Members.FindIndex(m => m.status == "rejected"
                                                && m.IsHead != true);
            if (index != -1)
            {
                student.Members.RemoveAt(index);
                student.nOfm -= 1;
            }

            // No Notificications left
            viewMsgsLbl.Text = "";
            viewMsgs.Visible = false;

        }

        // Navigate to Change Password Page
        private void changePassBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage("changePassword");
            oldPassTxt.Clear();
            newPassTxt.Clear();
        }

        // Change User Picture Function 
        private void changePicBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDial = new OpenFileDialog();
            fileDial.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff)|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff";

            if (fileDial.ShowDialog() == DialogResult.OK)
            {
                userPicBox.Image = new Bitmap(fileDial.FileName);
            }
            DB_Connection DB_Connector = new DB_Connection();
            string tableName = "CUsers";
            string[] scolumns = { "user_pic" };
            string[] wcolumns = { "user_id" };
            object[] values = { utilObj.convertToByteStream(userPicBox.Image), student.UserId };
            bool success = DB_Connector.UpdateData(tableName, scolumns, wcolumns, values);

            if (success)
            {
                MessageBox.Show("Successfully changed your image", "Success", MessageBoxButtons.OK);
            }

            else
            {
                MessageBox.Show("Error changing your image", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.student.UserImage = userPicBox.Image;
        }

        // Change Password
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (oldPassTxt.Text.Equals(student.Password))
            {
                DB_Connection DB_Connector = new DB_Connection();
                string tableName = "CUsers";
                string[] scolumns = { "password" };
                string[] wcolumns = { "user_id" };
                object[] values = { newPassTxt.Text, student.UserId };
                bool success = DB_Connector.UpdateData(tableName, scolumns, wcolumns, values);
                if (success)
                {
                    MessageBox.Show("Successfully changed your password", "Success", MessageBoxButtons.OK);
                    StudentPages.SetPage("Dashboard");
                    this.student.Password = newPassTxt.Text;
                }
            }
            else
            {
                MessageBox.Show("Old Password does not match", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oldPassTxt.Clear();
            }
        }
       
        // Sign/Log out Button
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* -------------------------------------------------------------------------

               Societies Page  Dynamic Functions

        ------------------------------------------------------------------------- */

        // Navigate to Societies Page
        private void societiesBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage("Societies");
            setUsernameAndPic();
        }

        // Show Societies On Page
        public void showSocieties(string searchTxt = null)
        {
            societyCardsPanel.Controls.Clear();
            regSocPanel.Controls.Clear();
            currentHandler = regForSociety_Click;
            List<int> Ids = new List<int>();
            foreach (var m in student.Members)
            {
                if (m.status != "pending" && m.status != "rejected")
                {
                    Ids.Add(m.SocietyId);
                }
            }
            foreach (var s in societies)
            {
                System.Drawing.Image societyImg = utilObj.getImage(s.Logo);
                if (s.status != "rejected" && s.status != "pending")
                {
                    if (Ids.Contains(s.SocietyId) && s.status != "pending")
                    {
                        Add_Society(regSocPanel, s.Name, s.Slogan, s.acronym, s.headName, s.mentorName, societyImg, s.Description, s.SocietyId);
                    }
                    else
                    {
                        Add_Society(societyCardsPanel, s.Name, s.Slogan, s.acronym, s.headName, s.mentorName, societyImg, s.Description, s.SocietyId);
                    }
                }

            }


        }

        // Add Society to FLow Panel
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

            newCard.ViewBtnClicked += (sender, e) =>
            {
                StudentPages.SelectedIndex = 3; 
                societyCard clickedCard = sender as societyCard;
                string societyName = clickedCard.sName;
                string societySlogan = clickedCard.sSlogan;
                string societyAcronym = clickedCard.sAcronym;
                string societyHead = clickedCard.sHead;
                string societyMentor = clickedCard.sMentor;

                System.Drawing.Image societyLogo = clickedCard.sImage;
                string societyDesc = description;
                titleViewSociety.Text = societyName;
                sloganViewSociety.Text = societySlogan;
                accViewSociety.Text = societyAcronym;
                headViewSociety.Text = societyHead;
                logoViewSociety.Image = societyLogo;
                descViewSociety.Text = societyDesc;
                mentorViewSociety.Text = societyMentor;

                if (p.Name == "societyCardsPanel")
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
        // Implement Dynamic search
        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            foreach (societyCard card in societyCardsPanel.Controls)
            {
                if (card is UserControl)
                {
                    card.toggleDisplay(searchBar.Text);
                }
            }

        }

        /* -------------------------------------------------------------------------

                        Societies Registration Functionalities

            ------------------------------------------------------------------------- */

        // Navigate to societies page
        private void previousPageBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage("Societies");
        }

        // Register as Member in Society
        private void regForSociety_Click(object sender, EventArgs e)
        {
            if(student.nOfm == 2)
            {
                MessageBox.Show("Already Registered in 2 Societies", "Cannot Initiate Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string societyName = titleViewSociety.Text;
            System.Drawing.Image societyLogo = logoViewSociety.Image;
            StudentRegistrationTab(societyName, societyLogo);
            StudentPages.SelectedIndex = 4;
        }
        // Auto Fill Student Information
        private void StudentRegistrationTab(string societyName, System.Drawing.Image societyLogo)
        {
            societyNameRegField.Text = societyName;
            logoStudentReg.Image = societyLogo;
            idRegField.Text = student.RollNo;
            nameRegField.Text = student.Username;
        }

        // Click handler to confirm Member Registration
        private void member_Registration(object sender, EventArgs e)
        {
            DB_Connection dbConnector = new DB_Connection();
            string societyId = dbConnector.GetSocietyId(societyNameRegField.Text).ToString();
            bool isHead = false;
            List<object> formInput = new List<object>();
            formInput.Add(student.StudentId);
            formInput.Add(societyId);
            formInput.Add(datePickerRegStudent.Value);
            formInput.Add(isHead);
            formInput.Add(societyStudentRegTextBox.Text);

            dbConnector.InsertMember(formInput, "Members");
            // Clear Fields
            societyStudentRegTextBox.Text = "";

            MessageBox.Show("Member Registration request sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            StudentPages.SelectedIndex = 0;
            customSocietyBtn.IndicateFocus = false;
        }

        // Register a new Society
        private void rSocietyForm_Click(object sender, EventArgs e)
        {
            societyName.Clear();
            societySlogan.Clear();
            societyDesc.Clear();
            availableMentors.Text = "";
            availableMentors.Items.Clear();
            uploadImgPicBox.Image = null;
            string query = @"
            SELECT U.username AS mentor_name
            FROM Mentors M
            INNER JOIN CUsers U ON M.user_id = U.user_id
            LEFT JOIN Societies S ON M.mentor_id = S.mentor_id
            WHERE U.role = 'mentor'
            GROUP BY M.mentor_id, U.username
            HAVING COUNT(S.society_id) < 2;";

            DB_Connection dbConnector = new DB_Connection();
            List<List<object>> selectResult = dbConnector.executeSelect(query);
            foreach (var row in selectResult)
            {
                string mentorName = row[0].ToString();
                availableMentors.Items.Add(mentorName);
            }
            if (availableMentors.Items.Count == 0)
            {
                MessageBox.Show("No Mentors are Currently Available", "Cannot Initiate Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            StudentPages.SetPage("Register a New Society !!");
        }

        // Register Society Button Click Handler
        private void regNewSociety_Click(object sender, EventArgs e)
        {
            if (societyName.Text == "" || societySlogan.Text == ""
                || societyDesc.Text == "" || availableMentors.Text == "" || uploadImgPicBox.Image == null)
            {
                MessageBox.Show("One or More Field(s) empty", "Please Fill All Fields and Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (Society society in this.societies)
            {
                if (society.Name.ToLower() == societyName.Text.ToLower())
                {
                    MessageBox.Show("Society name has already been taken", "Please Fill All Fields and Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!utilObj.CheckRegistrationParams(societyName.Text,
                societySlogan.Text, societyDesc.Text))
            {
                return;
            }

            DB_Connection dbConnector = new DB_Connection();

            List<object> formInput = new List<object>();

            formInput.Add(societyName.Text);
            formInput.Add(societySlogan.Text);
            formInput.Add(societyDesc.Text);
            formInput.Add(availableMentors.Text);
            byte[] imageBytes = utilObj.convertToByteStream(uploadImgPicBox.Image);
            formInput.Add(imageBytes);
            formInput.Add(student.StudentId);
            dbConnector.InsertSocietyAndMember(formInput, "Societies");
            MessageBox.Show("Registration request sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Society newSociety = new Society();
            newSociety.Name = societyName.Text;
            newSociety.Slogan = societySlogan.Text;
            newSociety.Description = societyDesc.Text;
            newSociety.mentorName = availableMentors.Text;
            newSociety.headName = student.Username;
            newSociety.HeadId = student.UserId;
            newSociety.Logo = utilObj.convertToByteStream(uploadImgPicBox.Image);
            newSociety.headName = student.Username;
            newSociety.status = "pending";
            societies.Add(newSociety);

            Member newMember = new Member();
            newMember.StudentId = student.StudentId;
            newMember.status = "pending";
            student.Members.Add(newMember);
            student.nOfm += 1;
            rSocietyForm.Visible = false;
            StudentPages.SetPage("Societies");
        }

        // Upload Image Function for image box
        private void uploadImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDial = new OpenFileDialog();
            fileDial.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff)|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff";

            if (fileDial.ShowDialog() == DialogResult.OK)
            {
                uploadImgPicBox.Image = new Bitmap(fileDial.FileName);
            }
        }
        // Upload Image Function for image holder
        private void uploadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDial = new OpenFileDialog();
            fileDial.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff)|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff";

            if (fileDial.ShowDialog() == DialogResult.OK)
            {
                eimgHolder.Image = new Bitmap(fileDial.FileName);
            }
        }

        /* -------------------------------------------------------------------------

                 Announcements Functionality

        ------------------------------------------------------------------------- */

        // Navigate to Announcments Page on Click
        private void addAnnouncementBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage("addAnnouncementPage");
        }
        // Announcements Click Handler
        private void societyAnnouncement_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage("Announcements");
            addAnnouncementCards();
        }

        // Post button handler
        private void postBtn_Click(object sender, EventArgs e)
        {
            DB_Connection dbConnector = new DB_Connection();
            List<object> formInput = getAnnouncementFormInput();

            if (formInput != null)
            {
                dbConnector.ExecuteInsertAnnouncement(formInput);
                MessageBox.Show("Announcement Posted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StudentPages.SetPage("Announcements");
                addAnnouncementCards();
            }
        }

                // Add Announcement Cards to Page
                protected void addAnnouncementCards()
        {
            announcementFlowLayoutPanel.Controls.Clear();
            initializeAnnouncements();
            foreach (var announcement in announcements)
            {
                if (utilObj.announcement_is_expired(announcement) == false)
                {
                    Add_Announcement(announcement.announcementTitle, announcement.announcementBody, announcement.societyName, announcement.postedAt.ToString(), announcement.validTill.ToString(), announcement.priority);
                }
            }
        }

        // Initialize Announcements
        protected void initializeAnnouncements()
        {
            announcements.Clear();
            List<List<object>> announcementResults = utilObj.getAnnouncements(student.UserId);
            foreach (var announcement in announcementResults)
            {
                Model.Announcement newAnnouncement = new Model.Announcement();
                newAnnouncement.initialize(announcement);
                announcements.Add(newAnnouncement);
            }
        }

        // Adding Cards to Announcements Page
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
            newAnnouncement.setColor();
            announcementFlowLayoutPanel.Controls.Add(newAnnouncement);
        }
        // Check Anouncement Page 
        public bool isEmptyFieldPresent_AnnouncementForm()
        {
            if ((titleTxt.Text.Length == 0) || (bodyTxt.Text.Length == 0) || (validTillPicker.Text.Length == 0)
                || (hoursCombo.Text.Length == 0) || (minsCombo.Text.Length == 0) || (am_pmCombo.Text.Length == 0)
                || (priorityCombo.Text.Length == 0))
            {
                return true;
            }

            return false;
        }
        // Check Date validation
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
        // Validate Input on Announcement form
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

        // Get Data Form Database
        public List<List<object>> getSocietyAndHeadId(string user_id)
        {
            DB_Connection dbConnector = new DB_Connection();

            string query = "SELECT SOCIETIES.society_id, STUDENTS.student_id\r\nFROM SOCIETIES INNER JOIN \r\nMEMBERS ON \r\nSOCIETIES.society_id = MEMBERS.society_id\r\nINNER JOIN STUDENTS ON\r\nSTUDENTS.student_id = MEMBERS.student_id\r\nINNER JOIN CUSERS ON\r\nCUSERS.user_id = STUDENTS.user_id\r\nWHERE CUSERS.user_id = " + user_id;

            List<List<object>> selectResult = dbConnector.executeSelect(query);

            return selectResult;
        }

        /* -------------------------------------------------------------------------

                 Events Page Functionality

         ------------------------------------------------------------------------- */

        // Navigate to Events Page
        private void eventsBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage("Events");
            showEvents();
        }

        // Display Events on Page
        private void showEvents()
        {
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
                        StudentPages.SetPage("view Event");
                        eventDetails(eve);
                    };

                    if (e.Status == "accepted")
                    {
                        allEventPanel.Controls.Add(c);
                    }
                    foreach(var m in student.Members)
                    {
                        if(m.SocietyId == e.SocietyId && m.status == "accepted")
                        {
                            societyEventPanel.Controls.Add(c);
                        }
                    }
                }
            }
        }

        // Populate View Events Page
        private void eventDetails(eventData e)
        {
            foreach(var s in societies)
            {
                foreach (var eve in s.Events)
                {
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
                foreach (var m in s.Members)
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

        // Click Handler for Registering an event
        private void regEventBtn_Click(object sender, EventArgs e)
        {
            Event newEvent = new Event();
            foreach (var s in societies)
            {
                if (s.Name == chooseSocDD.Text)
                {
                    newEvent.SocietyId = s.SocietyId;
                }
            }
            newEvent.Title = eTitle.Text;
            newEvent.Type = eType.Text;
            newEvent.Description = eDesc.Text;
            DateTime tmp = eDt.Value;
            string val = dateVal(tmp.ToShortDateString());

            Console.WriteLine(val);
            newEvent.Date = val;
            newEvent.Time = tmp.TimeOfDay;
            newEvent.Location = elocation.Text;
            newEvent.Status = "pending";
            newEvent.OrganizerId = student.StudentId;

            byte[] imageBytes = utilObj.convertToByteStream(eimgHolder.Image);
            newEvent.EventImg = imageBytes;
            Event.AddEvent(newEvent);
            foreach (var s in societies)
            {
                if (s.SocietyId == newEvent.SocietyId)
                {
                    s.Events.Add(newEvent);
                    break;
                }
            }
            chooseSocDD.Items.Clear();
            elocation.Clear();
            eTitle.Clear();
            eType.Clear();
            eDesc.Clear();
            eDt.Text = "";
            eimgHolder.Image = null;
            StudentPages.SetPage("Events");
            showEvents();
        }
        // Helper function for resolving date
        private string dateVal(string dt)
        {
            string[] parts = dt.Split('/');
            string day = parts[0];
            string month = parts[1];
            string year = parts[2];
            day = day.PadLeft(2, '0');
            month = month.PadLeft(2, '0');
            return $"{year}-{day}-{month}";
        }

        /* -------------------------------------------------------------------------

                    Member Requests Page Functionality

         ------------------------------------------------------------------------- */

        //Navigate to Member Requests Page
        private void MemberReqBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage("Member Requests");
            loadReqData();
        }

        // Member Request Data For Head
        private void loadReqData()
        {
            MemberRequestsPanel.Controls.Clear();
            int sId = -1;
            foreach (var m in student.Members)
            {
                if (m.IsHead)
                {
                    sId = m.SocietyId;
                }
            }

            if (sId != -1)
            {
                string query = "SELECT " +
                    "U.username AS user_name, S.society_name,M.member_id, U.user_pic, S.society_logo, M.join_date " +
                    ", M.interest FROM Members M JOIN Students St ON M.student_id = St.student_id" +
                    " JOIN CUsers U ON St.user_id = U.user_id" +
                    " JOIN Societies S ON M.society_id = S.society_id" +
                    " WHERE M.status = 'pending' and M.society_id = " + sId.ToString();

                DB_Connection dbConnector = new DB_Connection();
                List<List<object>> memreqdata = dbConnector.executeSelect(query);

                foreach (var row in memreqdata)
                {
                    string societyName = row[1].ToString();
                    string memName = row[0].ToString();
                    string memId = row[2].ToString();

                    Image uImg = utilObj.getImage((row[3] as byte[]));
                    Image sLogo = utilObj.getImage((row[4] as byte[]));
                    string mdate = row[5].ToString();
                    string interest = row[6].ToString();

                    addMemReq(memId, societyName, memName, uImg, sLogo, mdate, interest);
                }

            }
            
        }

        // Add Membere Request Card
        private void addMemReq(string memId, string societyName, string memName, 
                            Image uImg, Image sImg, string d, string interest)
        {
            RequestCard card = new RequestCard();
            card.Logo = uImg;
            card.HeadName = societyName;
            card.prlabel = "wants to join";
            card.Title = memName;
            card.uId = int.Parse(memId);
            card.hImg = sImg;
            card.hdate = d;
            card.desc = interest;

            card.detailsBtnClicked += (sender, e) =>
            {
                MemberRequest popup = new MemberRequest(card.Title, card.HeadName,card.Logo, card.hImg, card.hdate, card.desc);
                popup.ShowDialog();

            };

            card.acceptBtnClicked += (sender, e) =>
            {
                DB_Connection DB_Connector = new DB_Connection();
                string tableName = "Members";
                string[] scolumns = { "status" };
                string[] wcolumns = { "member_id" };
                object[] values = { "accepted", card.uId };
                bool success = DB_Connector.UpdateData(tableName, scolumns, wcolumns, values);
                loadReqData();
            };

            card.rejectBtnClicked += (sender, e) =>
            {
                Reject popup = new Reject("Member");
                popup.mId = card.uId;
                popup.ShowDialog();
                loadReqData();
            };
            MemberRequestsPanel.Controls.Add(card);
        }

        // Paint Empty Request Panel
        private void memReqGrid_Paint(object sender, PaintEventArgs e)
        {
            if (MemberRequestsPanel.Controls.Count == 0)
            {
                string message = "No entries Yet";
                using (var font = new Font("Verdana", 16, FontStyle.Bold))
                using (var brush = new SolidBrush(Color.White))
                {
                    var stringSize = e.Graphics.MeasureString(message, font);
                    var x = (MemberRequestsPanel.Width - stringSize.Width) / 2;
                    var y = (MemberRequestsPanel.Height - stringSize.Height) / 2;
                    e.Graphics.DrawString(message, font, brush, x, y);
                }
            }
        }

    }
}