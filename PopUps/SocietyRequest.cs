/*
 *              CAMPUSNEX POPUP CLASSES: SocietyRequest.cs
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
using System.Windows.Forms;

namespace CampusNex.PopUps
{
    public partial class SocietyRequest : Form
    {
        // Data Members
        Society Request = new Society();
        Util utilobj = new Util();

        // Constructor
        public SocietyRequest(Society Request)
        {
            InitializeComponent();
            this.Request = Request;
        }
        
        // Dismiss Button
        private void btnDismiss_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Loader Function
        private void SocietyRequest_Load(object sender, EventArgs e)
        {
            foreach(var m in this.Request.Members)
            {
                if (m.IsHead)
                {
                    headPic.Image = utilobj.getUserImage(m.StudentId);                
                }
            }
            headName.Text = this.Request.headName;
            socSlogan.Text = this.Request.Slogan;
            socName.Text = this.Request.Name;
            socDesc.Text = this.Request.Description;
            socPic.Image = utilobj.getImage(this.Request.Logo);

        }
    }
}
