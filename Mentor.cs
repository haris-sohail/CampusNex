using CampusNex.Model;
using CampusNex.PopUps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CampusNex
{
    public partial class Mentor : Form
    {
        // Arguements
        Model.Mentor mentor;
        List<Model.Society> societies = new List<Model.Society>();
        List<Model.Event> events = new List<Model.Event>();
        Model.Util utilObj = new Model.Util();

        /* -------------------------------------------------------------------------
                       
                            Initialization Functions
         
          ------------------------------------------------------------------------- */
       
        // Constructor
        public Mentor(string user_id)
        {
            mentor = new Model.Mentor(user_id);
            initializeSocieties();
            InitializeComponent();
            initializeEvents();

            SocietyRequestsPanel.Paint += SocReqGrid_Paint;
            EventsRequestsPanel.Paint += EveReqGrid_Paint;
        }

        // Load Funtion
        private void Mentor_Load(object sender, EventArgs e)
        {
            showDashBoard();
            setUsernameAndPic();
            showSocieties();
        }

        // Navigate to Dashboard
        public void showDashBoard()
        {
            MentorPages.SetPage("Dashboard");
            populateDashBoard();
        }
        
        // Populate Dashboard
        public void populateDashBoard()
        {
            nameLbl.Text = mentor.Username;
            emailLbl.Text = mentor.Email;
            userPicBox.Image = mentor.UserImage;
        }
        
        //Set User Image and Name
        public void setUsernameAndPic()
        {
            this.userName.Text = mentor.GetUsername();
            this.userPic.Image = mentor.GetUserImage();
        }

        // Initiialize Runtime Societies
        public void initializeSocieties()
        {
            List<List<object>> allSocieties = utilObj.getAllSocieties();
            foreach (var society in allSocieties)
            {
                Model.Society newSociety = new Model.Society();
                newSociety.initialize(society);
                societies.Add(newSociety);
            }
            List<Member> members = new List<Member>();
            int count = utilObj.getCount("Members");
            for (int i = 0; i < count; i++)
            {
                Model.Member m= new Model.Member(i+1);
                members.Add(m);
            }
            foreach (var s in societies)
            {
                foreach(var m in members)
                {
                    if(s.SocietyId == m.SocietyId)
                    {
                        s.Members.Add(m);
                    }
                }
            }
        }

        // Initialize Runtime Events
        private void initializeEvents()
        {
            foreach(var s in societies)
            {
                s.Events.Clear(); 
            }
            events.Clear();
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
       
        /* -------------------------------------------------------------------------

                        DashBoard Dynamic Functions

         ------------------------------------------------------------------------- */
       
        // Open Dashboard
        private void campusNexLbl_Click(object sender, EventArgs e)
        {
            MentorPages.SetPage("Dashboard");
        }

        // Logout Button Click
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Switch To Password Page
        private void changePassBtn_Click(object sender, EventArgs e)
        {
            MentorPages.SetPage("changePassword");
            oldPassTxt.Clear();
            newPassTxt.Clear();
        }

        // Update Password Button Handler
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (oldPassTxt.Text.Equals(mentor.Password))
            {
                DB_Connection DB_Connector = new DB_Connection();
                string tableName = "CUsers";
                string[] scolumns = { "password" };
                string[] wcolumns = { "user_id" };
                object[] values = { newPassTxt.Text, mentor.UserId };
                bool success = DB_Connector.UpdateData(tableName, scolumns, wcolumns, values);

                if (success)
                {
                    MessageBox.Show("Successfully changed your password", "Success", MessageBoxButtons.OK);
                    MentorPages.SetPage("Dashboard");
                    this.mentor.Password = newPassTxt.Text;
                }
            }
            else
            {
                MessageBox.Show("Old Password does not match", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oldPassTxt.Clear();
            }
        }

        // Change Picture Button Handler
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
            object[] values = { utilObj.convertToByteStream(userPicBox.Image), mentor.UserId };
            bool success = DB_Connector.UpdateData(tableName, scolumns, wcolumns, values);

            if (success)
            {
                MessageBox.Show("Successfully changed your image", "Success", MessageBoxButtons.OK);
            }

            else
            {
                MessageBox.Show("Error changing your image", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.mentor.UserImage = userPicBox.Image;
        }
        /* -------------------------------------------------------------------------

                       Societies Page  Dynamic Functions

        ------------------------------------------------------------------------- */

       // Navigate to Societies Page
        private void societiesBtn_Click(object sender, EventArgs e)
        {
            MentorPages.SetPage("Societies");
        }

        // Dynamic Search for Societies
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

        // Render Societies On Page
        public void showSocieties()
        {
            societyCardsPanel.Controls.Clear();
            foreach (var society in societies)
            {
                if (society.status == "accepted")
                {
                    System.Drawing.Image societyImg = utilObj.getImage(society.Logo);
                    string mentorName = utilObj.getMentorName(society.MentorId.ToString());
                    string headName = utilObj.getHeadName(society.HeadId.ToString());
                    string acronym = utilObj.getAcronym(society.Name);
                    Add_Society(society.Name, society.Slogan, acronym, headName, mentorName, societyImg, society.Description);
                }
            }
        }

        // Add Society Card
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
            newCard.ViewBtnClicked += (sender, e) =>
            {
                MentorPages.SetPage("view Society");

                societyCard clickedCard = sender as societyCard;
                string societyName = clickedCard.sName;
                string societySlogan = clickedCard.sSlogan;
                string societyAcronym = clickedCard.sAcronym;
                string societyHead = clickedCard.sHead;
                System.Drawing.Image societyLogo = clickedCard.sImage;
                string societyDesc = description;

                titleViewSociety.Text = societyName;
                sloganViewSociety.Text = societySlogan;
                accViewSociety.Text = societyAcronym;
                headViewSociety.Text = societyHead;
                logoViewSociety.Image = societyLogo;
                descViewSociety.Text = societyDesc;
            };
            societyCardsPanel.Controls.Add(newCard);
        }

        /* -------------------------------------------------------------------------

               Events Page  Dynamic Functions

        ------------------------------------------------------------------------- */

        // Navigate to Event Page
        private void eventsBtn_Click(object sender, EventArgs e)
        {
            MentorPages.SetPage("Events");
            showEvents();
        }

        // Navigate to Events Page From View Event
        private void BackBtn_Click(object sender, EventArgs e)
        {
            MentorPages.SetPage("Events");
        }

        // Populate Event Cards on Events Page
        private void showEvents()
        {
            allEventPanel.Controls.Clear();
            foreach (var s in societies)
            {
                foreach (var e in s.Events)
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
                        MentorPages.SetPage("view Event");
                        eventDetails(eve);
                    };
                    allEventPanel.Controls.Add(c);
                }

            }
        }
        // Populate Event Details Page
        private void eventDetails(eventData e)
        {
            foreach (var s in societies)
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


        /* -------------------------------------------------------------------------

                        Load Request For Society and Event Registration

         ------------------------------------------------------------------------- */

        // Navigate to Society Request Page
        private void reqBtn_Click(object sender, EventArgs e)
        {
            MentorPages.SetPage("societyReq");
            loadReqData();
        }

        // Navigate to Event Request Page
        private void eventRequest_Click(object sender, EventArgs e)
        {
            MentorPages.SetPage("eventReq");
            loadReqData();
        }

        // Load Cards
        private void loadReqData()
        {
            SocietyRequestsPanel.Controls.Clear();
            EventsRequestsPanel.Controls.Clear();
            foreach (var s in societies)    
            {
                if (s.MentorId == mentor.MentorId)
                {
                    if (s.status == "pending") { 
                        string societyName = s.Name;
                        string sHeadName = "";
                        int memId = -1;
                        foreach (var m in s.Members)
                        {
                            if (m.IsHead)
                            {
                                sHeadName = utilObj.getHeadName(m.StudentId.ToString());
                                memId = m.MemberId;
                            }
                        }
                        byte[] slogo = s.Logo;
                        System.Drawing.Image societyImg = utilObj.getImage(slogo);
                        addSocReqCard(societyImg, societyName, sHeadName, memId,
                            s.SocietyId);
                    }
                    foreach (var e in s.Events)
                    {
                        if (e.Status == "pending")
                        {
                            string oname = utilObj.getHeadName(e.OrganizerId.ToString());
                            System.Drawing.Image img = utilObj.getImage(e.EventImg);
                            byte[] slogo = s.Logo;
                            System.Drawing.Image societyImg = utilObj.getImage(slogo);
                            addEventsReqCard(img, s.Name, e.Title, oname, e.EventId, societyImg);
                        }

                    }
                }
            }
            SocietyRequestsPanel.Invalidate();
            EventsRequestsPanel.Invalidate();

        }

        /* -------------------------------------------------------------------------

                                 Request Pages Dynamic Functions

         ------------------------------------------------------------------------- */

       
        // Add Society Request Card
        private void addSocReqCard(System.Drawing.Image img, string sName, string hName, int memId,
                                int SocietyId)
        {

            RequestCard card = new RequestCard();
            card.Logo = img;
            card.HeadName = sName;
            card.Title = hName;
            card.uId = memId;
            card.societyId = SocietyId;

            card.detailsBtnClicked += (sender, e) =>
            {
                foreach (var s in societies)
                {
                    if (s.SocietyId == card.societyId)
                    {
                        SocietyRequest popup = new SocietyRequest(s);
                        popup.ShowDialog();
                        break;
                    }
                }
            };

            card.acceptBtnClicked += (sender, e) =>
            {
                DB_Connection DB_Connector = new DB_Connection();
                string tableName = "Societies";
                string[] scolumns = { "status" };
                string[] wcolumns = { "society_id" };
                object[] values = { "accepted", card.societyId };
                bool success = DB_Connector.UpdateData(tableName, scolumns, wcolumns, values);
                DB_Connector.connection.Close();
                tableName = "Members";
                string[] wcol = { "member_id" };
                object[] vals = { "accepted", card.uId };

                success = DB_Connector.UpdateData(tableName, scolumns, wcol, vals);
                foreach (var s in societies)
                {
                    if (s.SocietyId == card.societyId)
                    {
                        foreach (var m in s.Members)
                        {
                            if (m.MemberId == card.uId)
                            {
                                s.status = "accepted";
                                m.status = "accepted";
                            }
                        }
                    }
                }
                loadReqData();
                showSocieties();
            };

            card.rejectBtnClicked += (sender, e) =>
            {
                foreach (var s in societies)
                {
                    if (s.SocietyId == card.societyId)
                    {
                        Reject popup = new Reject("Society");
                        popup.sr = s;
                        popup.DataSent += RejectSocReq;
                        popup.ShowDialog();
                        break;
                    }

                }
            };
            SocietyRequestsPanel.Controls.Add(card);
        }

        // Reject Society Handler
        private void RejectSocReq(object sender, DataSentEventArgs e)
        {
            if (e.Status)
            {
                int index = societies.FindIndex(s => s.SocietyId == e.Id);
                if (index != -1)
                {
                    societies.RemoveAt(index);
                }
                loadReqData();
                MentorPages.SetPage("societyReq");
            }

        }

        // Paint Empty Society Request Panel
        private void SocReqGrid_Paint(object sender, PaintEventArgs e)
        {
            if (SocietyRequestsPanel.Controls.Count == 0)
            {
                string message = "No entries Yet";
                using (var font = new Font("Verdana", 16, FontStyle.Bold))
                using (var brush = new SolidBrush(Color.White))
                {
                    var stringSize = e.Graphics.MeasureString(message, font);
                    var x = (SocietyRequestsPanel.Width - stringSize.Width) / 2;
                    var y = (SocietyRequestsPanel.Height - stringSize.Height) / 2;
                    e.Graphics.DrawString(message, font, brush, x, y);
                }
            }
        }

        // Add Event Request Card
        private void addEventsReqCard(System.Drawing.Image eImg, string sName, string eName,
            string oname, int eId, System.Drawing.Image sImg)
        {
            RequestCard card = new RequestCard();
            card.Logo = eImg;
            card.HeadName = eName;
            card.Title = oname;
            card.uId = eId;
            card.hImg = sImg;
            card.sName = sName;
            card.detailsBtnClicked += (sender, e) =>
            {
                foreach (var ev in events)
                {
                    if (ev.EventId == card.uId)
                    {
                        EventRequest popup = new EventRequest(ev, card.hImg, card.sName, card.Title);
                        popup.ShowDialog();
                        break;
                    }
                }

            };

            card.acceptBtnClicked += (sender, e) =>
            {
                DB_Connection DB_Connector = new DB_Connection();
                string tableName = "Events";
                string[] scolumns = { "status" };
                string[] wcolumns = { "event_id" };
                object[] values = { "accepted", card.uId };
                bool success = DB_Connector.UpdateData(tableName, scolumns, wcolumns, values);
                foreach (var s in societies)
                {
                    foreach (var ev in s.Events)
                    {
                        if (ev.EventId == card.uId)
                        {
                            ev.Status = "accepted";
                            break;
                        }
                    }
                }
                loadReqData();
            };

            card.rejectBtnClicked += (sender, e) =>
            {
                foreach (var ev in events)
                {
                    if (ev.EventId == card.uId)
                    {
                        Reject popup = new Reject("Event");
                        popup.er = ev;
                        popup.DataSent += RejectEveReq;
                        popup.ShowDialog();
                        break;
                    }
                }
            };


            EventsRequestsPanel.Controls.Add(card);
        }
        // Reject Event Handler
        private void RejectEveReq(object sender, DataSentEventArgs e)
        {
            if (e.Status)
            {
                foreach (var s in societies)
                {
                    int idx = s.Events.FindIndex(ev => ev.EventId == e.Id);
                    if (idx != -1)
                    {
                        s.Events.RemoveAt(idx);
                        break;
                    }
                }

                int index = events.FindIndex(ev => ev.EventId == e.Id);
                if (index != -1)
                {
                    events.RemoveAt(index);
                }
                loadReqData();
                MentorPages.SetPage("eventReq");
            }

        }

        // Paint Empty Event Request Panel
        private void EveReqGrid_Paint(object sender, PaintEventArgs e)
        {

            if (EventsRequestsPanel.Controls.Count == 0)
            {
                string message = "No entries Yet";
                using (var font = new Font("Verdana", 16, FontStyle.Bold))
                using (var brush = new SolidBrush(Color.White))
                {
                    var stringSize = e.Graphics.MeasureString(message, font);
                    var x = (EventsRequestsPanel.Width - stringSize.Width) / 2;
                    var y = (EventsRequestsPanel.Height - stringSize.Height) / 2;
                    e.Graphics.DrawString(message, font, brush, x, y);
                }
            }
        }

    }
}