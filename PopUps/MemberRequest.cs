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
using static System.Net.Mime.MediaTypeNames;

namespace CampusNex.PopUps
{
    public partial class MemberRequest : Form
    {

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

        private void closeBtnViewMember_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
