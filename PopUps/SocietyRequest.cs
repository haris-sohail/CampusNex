using CampusNex.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampusNex.PopUps
{
    public partial class SocietyRequest : Form
    {
        Society Request = new Society();
        Util utilobj = new Util();
        public SocietyRequest(Society Request)
        {
            InitializeComponent();
            this.Request = Request;
            Console.WriteLine(this.Request);
        }

        private void btnDismiss_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SocietyRequest_Load(object sender, EventArgs e)
        {
            // Load All Data
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
