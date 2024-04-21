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
        Member Request = new Member();
        Util utilobj = new Util();
        private System.Drawing.Image societyImg;
        private System.Drawing.Image memImg;
        private string soc_Name;
        private string memInterest;
        private string memName;
        private string dateJoined;

        public MemberRequest(Member Request, string soc_Name, System.Drawing.Image socImg, string memInterest, string memName, System.Drawing.Image memImg, string dateJoined)
        {
            InitializeComponent();
            this.Request = Request;
            this.societyImg = socImg;
            this.soc_Name = soc_Name;
            this.memInterest = memInterest;
            this.memName = memName;
            this.memImg = memImg;
            this.dateJoined = dateJoined;
            Console.WriteLine(this.Request);
           
        }

        private void closeBtnViewMember_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void regDateViewMember_Click(object sender, EventArgs e)
        {

        }

        private void MemberRequest_Load(object sender, EventArgs e)
        {
            //Load all data  
            memberPic.Image = this.memImg;
            socPic.Image = this.societyImg;
            nameViewMember.Text = this.memName;   
            socName.Text = this.soc_Name;
            regDateViewMember.Text = this.dateJoined;
            memberDesc.Text = this.memInterest;
            

        }
    }
}
