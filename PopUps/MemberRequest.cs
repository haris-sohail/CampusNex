/*
 *              CAMPUSNEX POPUP CLASSES: MemberRequest.cs
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
    public partial class MemberRequest : Form
    {
        // Constructor
        public MemberRequest(string mName, string sName, System.Drawing.Image mPic, 
                            System.Drawing.Image sPic, string dateJoined, string interest)
        {
            InitializeComponent();
            memberName.Text = mName;
            socName.Text = sName;
            memberPic.Image = mPic;
            socPic.Image = sPic;
            regDateViewMember.Text = dateJoined;
            memberDesc.Text = interest;
           
        }

        // Dismiss Button
        private void closeBtnViewMember_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}