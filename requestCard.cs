using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampusNex
{
    public partial class RequestCard : Bunifu.UI.WinForms.BunifuUserControl
    {
        public event EventHandler detailsBtnClicked;
        public event EventHandler acceptBtnClicked;
        public event EventHandler rejectBtnClicked;
        public RequestCard()
        {
            InitializeComponent();
        }

        public string Title
        {
            get
            {
                return newSocName.Text;
            }
            set
            {
                newSocName.Text = value;
            }
        }
        
        public string prlabel
        {
            get
            {
                return presentlabel.Text;
            }
            set
            {
                presentlabel.Text = value;
            }
        }

        public string HeadName
        {
            get
            {
                return socHeadName.Text;
            }
            set
            {
                socHeadName.Text = value;
            }
        }

        public Image Logo 
        {
            get
            {
                return newSocImg.Image;
            }
            set
            {
                newSocImg.Image = value;
            }
        }

        // Helper Fields
        public int uId;
        public int societyId;
        public string sName;
        public string hdate;
        public string desc;
        public System.Drawing.Image hImg;


        public void detailsBtn_Click(object sender, EventArgs e)
        {
            
            detailsBtnClicked?.Invoke(this, EventArgs.Empty);
        }

        public void acceptBtn_Click(object sender, EventArgs e)
        {
            acceptBtnClicked?.Invoke(this, EventArgs.Empty);
        }

        public void rejectBtn_Click(object sender, EventArgs e)
        {
            rejectBtnClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
