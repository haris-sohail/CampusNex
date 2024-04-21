using CampusNex.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampusNex.PopUps
{
    public partial class EventRequest : Form
    {
        Event Request = new Event();
        Util utilobj = new Util();
        private byte[] societyImg;
        private string socname;
        private string org;

        public EventRequest(Event Request, byte[] societyImg, string socName, string organizer )
        {
            InitializeComponent();
            this.Request = Request;
            this.societyImg = societyImg;
            this.socname = socName;
            this.org = organizer;
            Console.WriteLine(this.Request);
        }

        private void socDesc_Click(object sender, EventArgs e)
        {

        }

        private void EventRequest_Load(object sender, EventArgs e)
        {
            // Load All Data    
            evePic.Image = utilobj.getImage(this.Request.EventImg);  
            if (societyImg != null)
            {
                using (MemoryStream ms = new MemoryStream(societyImg))
                {
                    socPic.Image = Image.FromStream(ms);
                }
            }
             socName.Text = this.socname;
            orgViewEvent.Text = this.org;
            eveName.Text = this.Request.Title;       
            dateViewEvent.Text = this.Request.Date;            
            locationViewEvent.Text = this.Request.Location;     
            eveDesc.Text = this.Request.Description;                
            
        }

        private void closeButtonViewEvent_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void locationLbl_Click(object sender, EventArgs e)
        {

        }

        private void socName_Click(object sender, EventArgs e)
        {

        }

        private void evePic_Click(object sender, EventArgs e)
        {

        }

        private void eventPic_Click(object sender, EventArgs e)
        {

        }
    }
}
