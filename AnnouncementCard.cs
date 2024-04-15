using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampusNex
{
    public partial class AnnouncementCard : Bunifu.UI.WinForms.BunifuUserControl
    {
        public AnnouncementCard()
        {
            InitializeComponent();
        }

        public string title {
            get
            {
                return announcementTitle.Text;
            }
            set
            {
                announcementTitle.Text = value;
            }
        }

        public string society_name
        {
            get
            {
                return societyName.Text;
            }
            set
            {
                societyName.Text = value;
            }
        }

        public string announcement_body
        {
            get
            {
                return announcementBody.Text;
            }
            set
            {
                announcementBody.Text = value;
            }

        }

        public string posted_at
        {
            get
            {
                return postedAt.Text;
            }
            set
            {
                postedAt.Text = value;
            }
        }

        public string expires_at
        {
            get
            {
                return expiresAt.Text;
            }
            set
            {
                expiresAt.Text = value;
            }
        }
    }
}
