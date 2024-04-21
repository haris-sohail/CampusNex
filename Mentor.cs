using Bunifu.UI.WinForms;
using CampusNex.Model;
using CampusNex.PopUps;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
        List<Model.Event> events = new List<Model.Event>();
        Model.Util utilObj = new Model.Util();

        public Mentor(string user_id)
        {
            mentor = new Model.Mentor(user_id);
            initializeSocieties();
            InitializeComponent();
            initializeEvents();
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
                StudentPages.SelectedIndex = 2; // Index of the "View More" tab


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

            socReqGrid.Rows.Clear(); 
            eveReqGrid.Rows.Clear();
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
                            System.Drawing.Image resizedImage = utilObj.ResizeImage(societyImg, 32, 32);
                            // Populate the society request DataGrid 
                            socReqGrid.Rows.Add(new Object[]
                            {
                                resizedImage,
                                societyName,
                                sHeadName,
                                "View",
                                "Accept",
                                memId.ToString(),
                                s.SocietyId.ToString()
                            });
                    }

                    foreach (var e in s.Events)
                    {
                        if (e.Status == "pending")
                        {
                            string oname = utilObj.getHeadName(e.OrganizerId.ToString());
                            System.Drawing.Image img = utilObj.getImage(e.EventImg);
                            System.Drawing.Image eImgg = utilObj.ResizeImage(img, 32, 32);

                            byte[] slogo = s.Logo;

                            System.Drawing.Image societyImg = utilObj.getImage(slogo);
                            System.Drawing.Image resizedImage = utilObj.ResizeImage(societyImg, 32, 32);
                            eveReqGrid.Rows.Add(new Object[]
                            {
                                eImgg,
                                s.Name,
                                e.Title,
                                oname,
                                "View",
                                "Accept",
                                 e.EventId.ToString(),   //sending eventId
                                 resizedImage
             
                            });
                        }

                    }
                }

               
            }

        }
        private void reqBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage(((Control)sender).Text);
            loadReqData();
        }

        private void socReqGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //need to add condition that if its row 1
            // Check Click Event on Accept Column
            if (e.ColumnIndex == 4) 
            {
                if (socReqGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    DataGridViewRow clickedRow = socReqGrid.Rows[e.RowIndex];
                    // Extract Society Id
                    string societyId = clickedRow.Cells[6].Value.ToString();

                    DB_Connection DB_Connector = new DB_Connection();
                    // Set status to accepted
                    string tableName = "Societies";
                    string[] scolumns = { "status" };
                    string[] wcolumns = { "society_id" };
                    object[] values = { "accepted", int.Parse(societyId)};
     
                    //  Update Societies Table
                    bool success = DB_Connector.UpdateData(tableName, scolumns, wcolumns,values);

                    // Update Member i.e. Head Status
                    DB_Connector.connection.Close();
                    // Extract Member Id
                    string memberId = clickedRow.Cells[5].Value.ToString();
                    Console.WriteLine("Val: ", memberId);
                    tableName = "Members";
                    string[] wcol = { "member_id"};
                    object[] vals = { "accepted", int.Parse(memberId)};

                    // Update Members Table in database
                    success = DB_Connector.UpdateData(tableName, scolumns, wcol, vals);
                    // Update Runtime data
                    foreach (var s in societies)
                    {
                        if (s.SocietyId == int.Parse(societyId))
                        {
                            foreach(var m in s.Members)
                            {
                                if(m.MemberId == int.Parse(memberId))
                                {
                                    s.status = "accepted";
                                    m.status = "accepted";
                                }
                            }
                        }
                    }

                    loadReqData();
                    showSocieties();
                }
            }

            // Check Click Event on View More Column
            if (e.ColumnIndex == 3)
            {
                if (socReqGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    DataGridViewRow clickedRow = socReqGrid.Rows[e.RowIndex];
                    // Get Society Id
                    string societyId = clickedRow.Cells[6].Value.ToString();
                    foreach(var s in societies)
                    {
                        if(s.SocietyId == int.Parse(societyId))
                        {
                            SocietyRequest popup = new SocietyRequest(s);
                            popup.ShowDialog();
                            break;
                        }
                    }
                    

                }
            }

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
            StudentPages.SetPage("Events");
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
                        StudentPages.SetPage("view Event");
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

        private void eveReqGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
                //when accept button is clicked
                if (e.ColumnIndex == 5)
                {
                    if (eveReqGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {
                        DataGridViewRow clickedRow = eveReqGrid.Rows[e.RowIndex];
                        // Extract Event Id
                        string cellValue = clickedRow.Cells[2].Value.ToString();
                        int eveId = -1;
                        foreach (var ee in events)
                        {
                            if (ee.Title == cellValue)
                            {
                                eveId = ee.EventId;
                                break;
                            }
                        }
                        DB_Connection DB_Connector = new DB_Connection();
                        // Set status to accepted
                        string tableName = "Events";
                        string[] scolumns = { "status" };
                        string[] wcolumns = { "event_id" };
                        object[] values = { "accepted", eveId };

                        // Call the UpdateData method
                        bool success = DB_Connector.UpdateData(tableName, scolumns, wcolumns, values);
                        initializeEvents();
                        loadReqData();
                    }
                }

                if (e.ColumnIndex == 4)
                {
                    if (eveReqGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {
                        DataGridViewRow clickedRow = eveReqGrid.Rows[e.RowIndex];
                        

                        string eventId = clickedRow.Cells[6].Value.ToString();
                        bool flg = false;
                    

                        foreach (var s in societies)
                        {
                            foreach (var ev in s.Events)
                            {
                                //if (ev.EventId == int.Parse(eventId))
                               // {
                                    string organizerOfEvent = utilObj.getHeadName(s.HeadId.ToString());
                                    string socName = utilObj.getSocietyName(s.SocietyId.ToString());
                                    EventRequest popup = new EventRequest(ev, s.Logo, socName, organizerOfEvent);
                                    popup.ShowDialog();
                                    flg = true;
                            
                                    break;
                                //}
                            }

                            if(flg == true)
                             {
                               break;
                             }
                        }

                    }
                }
            
        }

        // Added New Event Handlers For Empty Grids
        private void SocGrid_Paint(object sender, PaintEventArgs e)
        {
            if (socReqGrid.Rows.Count == 0)
            {
                string message = "No entries Yet";
                using (var font = new Font("Verdana", 16, FontStyle.Bold))
                using (var brush = new SolidBrush(Color.White))
                {
                    var stringSize = e.Graphics.MeasureString(message, font);
                    var x = (socReqGrid.Width - stringSize.Width) / 2;
                    var y = (socReqGrid.Height - stringSize.Height) / 2;
                    e.Graphics.DrawString(message, font, brush, x, y);
                }
            }
        }

        private void EveGrid_Paint(object sender, PaintEventArgs e)
        {

            if (eveReqGrid.Rows.Count == 0)
            {
                string message = "No entries Yet";
                using (var font = new Font("Verdana", 16, FontStyle.Bold))
                using (var brush = new SolidBrush(Color.White))
                {
                    var stringSize = e.Graphics.MeasureString(message, font);
                    var x = (eveReqGrid.Width - stringSize.Width) / 2;
                    var y = (eveReqGrid.Height - stringSize.Height) / 2;
                    e.Graphics.DrawString(message, font, brush, x, y);
                }
            }
        }

    }
}
