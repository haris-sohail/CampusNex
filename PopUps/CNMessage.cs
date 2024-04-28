/*
 *              CAMPUSNEX POPUP CLASSES: CN_Message.cs
 *              
 *              Coded By ACECODERS:
 *              
 *                      -> Kalsoom Tariq (i21-2487)
 *                      -> Haris Sohail (i21-0531)
 *                      -> Aiman Safdar (i21-0588)
 *                      
 */
using System;
using System.Windows.Forms;

namespace CampusNex.PopUps
{
    public partial class CNMessage : Form
    {
        // Constructor
        public CNMessage(string t, string c)
        {
            InitializeComponent();
            msgtype.Text = t;
            if (c != null )
            {
                reasons.Text = c;
            }
            else
            {
                reasons.Text = "No Comments :(";
            }
           
        }

        // Close Button Handler
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}