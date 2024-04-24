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
        Model.Mentor mentor;
        List<Model.Society> societies = new List<Model.Society>();
        List<Model.Event> events = new List<Model.Event>();
        Model.Util utilObj = new Model.Util();

        public Mentor(string user_id)
        {
            mentor = new Model.Mentor(user_id);
            initializeSocieties();
            InitializeComponent();
            initializeEvents();

            SocietyRequestsPanel.Paint += SocReqGrid_Paint;
            EventsRequestsPanel.Paint += EveReqGrid_Paint;
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

            // Get members of each society
            List<Member> members = new List<Member>();
            int count = utilObj.getCount("Members");
            Console.WriteLine("No Of Members: ", count.ToString());
            for (int i = 0; i < count; i++)
            {
                // Print out each Member
                Model.Member m= new Model.Member(i+1);
                members.Add(m);
                Console.WriteLine(m);
            }
            
           // Adding members to respective societies
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

        private void initializeEvents()
        {
            // Clear events
            foreach(var s in societies)
            {
                s.Events.Clear();
                
            }
            events.Clear();
            // Get Events count from database
            int count = utilObj.getCount("Events");
            for (int i = 0; i < count; i++)
            {
                Model.Event e = new Model.Event(i + 1);
                events.Add(e);
            }
            // Link events with Societies
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

        private void societiesBtn_Click(object sender, EventArgs e)
        {
            MentorPages.SetPage("Societies");
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
                MentorPages.SelectedIndex = 2; // Index of the "View More" tab


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

        public void setUsernameAndPic()
        {
            this.userName.Text = mentor.GetUsername();
            this.userPic.Image = mentor.GetUserImage();
        }


        private void Mentor_Load(object sender, EventArgs e)
        {   
            setUsernameAndPic();
            showSocieties();
        }

        public void showSocieties(string searchTxt = null)
        {
            societyCardsPanel.Controls.Clear();
            // Add society cards from the society list
            foreach (var society in societies)
            {
                if (society.status == "accepted")
                {
                    System.Drawing.Image societyImg = utilObj.getImage(society.Logo);

                    // get mentor and head names
                    string mentorName = utilObj.getMentorName(society.MentorId.ToString());
                    string headName = utilObj.getHeadName(society.HeadId.ToString());


                    string acronym = utilObj.getAcronym(society.Name);

                    Add_Society(society.Name, society.Slogan, acronym, headName, mentorName, societyImg, society.Description);
                }
            }
        }

        private void loadReqData()
        {
            // changing
            SocietyRequestsPanel.Controls.Clear();
            EventsRequestsPanel.Controls.Clear();
            foreach (var s in societies)    
            {
                if (s.MentorId == mentor.MentorId)
                {
                    if (s.status == "pending") { 
                            // Get society and Head name
                        string societyName = s.Name;
                        string sHeadName = "";
                        int memId = -1;
                        foreach (var m in s.Members)
                        {
                            if (m.IsHead)
                            {
                                sHeadName = utilObj.getHeadName(m.StudentId.ToString());
                                memId = m.MemberId;
                                Console.WriteLine("MemID: ", memId.ToString());
                            }
                        }
                        byte[] slogo = s.Logo;

                        System.Drawing.Image societyImg = utilObj.getImage(slogo);
                            // Populate soc Req Panel
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

        private void addEventsReqCard(System.Drawing.Image eImg, string sName ,string eName ,
            string oname, int eId, System.Drawing.Image sImg)
        {
            RequestCard card = new RequestCard();
            card.Logo = eImg;
            card.HeadName = eName;
            card.Title = oname;
            card.uId = eId;
            card.hImg = sImg;
            card.sName = sName;

            // Add Controllers
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
                // Set status to accepted
                string tableName = "Events";
                string[] scolumns = { "status" };
                string[] wcolumns = { "event_id" };
                object[] values = { "accepted", card.uId };

                // Call the UpdateData method
                bool success = DB_Connector.UpdateData(tableName, scolumns, wcolumns, values);
                
                // Update Runtime
                foreach (var s in societies)
                {
                    foreach(var ev in s.Events)
                    {
                        if(ev.EventId == card.uId)
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
                foreach(var ev in events)
                {
                    if(ev.EventId == card.uId)
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
        private void RejectEveReq(object sender, DataSentEventArgs e)
        {
            if (e.Status)
            {
                // Delete from runtime
                foreach(var s in societies)
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
                // Reload Page
                loadReqData();
                MentorPages.SetPage("eventReq");
            }
            
        }

        private void addSocReqCard(System.Drawing.Image img, string sName, string hName, int memId,
                                int SocietyId)
        {

            RequestCard card = new RequestCard();
            card.Logo = img;
            card.HeadName = sName;
            card.Title = hName;
            card.uId = memId;
            card.societyId = SocietyId;
            // Add Controllers
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
                // Set status to accepted
                string tableName = "Societies";
                string[] scolumns = { "status" };
                string[] wcolumns = { "society_id" };
                object[] values = { "accepted", card.societyId };

                //  Update Societies Table
                bool success = DB_Connector.UpdateData(tableName, scolumns, wcolumns, values);

                // Update Member i.e. Head Status
                DB_Connector.connection.Close();
                // Extract Member Id
                tableName = "Members";
                string[] wcol = { "member_id" };
                object[] vals = { "accepted", card.uId };

                // Update Members Table in database
                success = DB_Connector.UpdateData(tableName, scolumns, wcol, vals);
                // Update Runtime data
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
                    if(s.SocietyId == card.societyId)
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

        private void RejectSocReq(object sender, DataSentEventArgs e)
        {
            if (e.Status)
            {
                // Delete from runtime
                int index = societies.FindIndex(s => s.SocietyId == e.Id);
                if (index != -1)
                {
                    societies.RemoveAt(index);
                }
                // Reload Page
                loadReqData();
                MentorPages.SetPage("societyReq");
            }

        }

        private void reqBtn_Click(object sender, EventArgs e)
        {
            MentorPages.SetPage("societyReq");
            loadReqData();
        }
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

        private void eventsBtn_Click(object sender, EventArgs e)
        {
            MentorPages.SetPage("Events");
            showEvents();
        }

        private void showEvents()
        {
            // Parse Each event of society 
            // and add it to Panel
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
                        
                    // Add all accepted events to Panel 1
                    allEventPanel.Controls.Add(c);
                   

                }

            }
        }

        private void eventDetails(eventData e)
        {
            foreach (var s in societies)
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

        private void eventRequest_Click(object sender, EventArgs e)
        {
            MentorPages.SetPage("eventReq");
            loadReqData();
        }

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
    }
}
