/*
 *              CAMPUSNEX POPUP CLASSES: EventRequest.cs
 *              
 *              Coded By ACECODERS:
 *              
 *                      -> Kalsoom Tariq (i21-2487)
 *                      -> Haris Sohail (i21-0531)
 *                      -> Aiman Safdar (i21-0588)
 *                      
 */
using CampusNex.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CampusNex.PopUps
{
    public partial class EventRequest : Form
    {
        // Data Members
        Event Request = new Event();
        Util utilobj = new Util();
        private Image societyImg;
        private string socname;
        private string org;

        // Constructor
        public EventRequest(Event Request, Image societyImg, string socName, string organizer )
        {
            this.Request = Request;
            this.societyImg = societyImg;
            socname = socName;
            org = organizer;
            InitializeComponent();
        }

        // Load Function
        private void EventRequest_Load(object sender, EventArgs e)
        {
            // Load All Data    
            evePic.Image = utilobj.getImage(this.Request.EventImg);
            socPic.Image = societyImg;
            socName.Text = this.socname;
            orgViewEvent.Text = this.org;
            eveName.Text = this.Request.Title;       
            dateViewEvent.Text = this.Request.Date;            
            locationViewEvent.Text = this.Request.Location;     
            eveDesc.Text = this.Request.Description;                
            
        }

        // Close Button
        private void closeButtonViewEvent_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
