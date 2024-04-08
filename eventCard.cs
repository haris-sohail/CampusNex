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
    public partial class eventCard : Bunifu.UI.WinForms.BunifuUserControl
    {
        public eventCard()
        {
            InitializeComponent();
        }

        public string sName
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

        public string eName
        {

            get
            {
                return eventName.Text;
            }

            set
            {
                eventName.Text = value;
            }
        }

        public string eDate
        {

            get
            {
                return eventDate.Text;
            }

            set
            {
                eventDate.Text = value;
            }
        }

        public string eTime
        {

            get
            {
                return eventTime.Text;
            }

            set
            {
                eventTime.Text = value;
            }
        }

        public Image eImage
        {

            get
            {
                return eventImg.Image;
            }

            set
            {
                eventImg.Image = value;
            }
        }

    }
}
