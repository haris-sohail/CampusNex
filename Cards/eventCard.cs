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

namespace CampusNex
{
    public partial class eventCard : Bunifu.UI.WinForms.BunifuUserControl
    {
        public event EventHandler<eventData> DetailsBtn;
        public eventCard()
        {
            InitializeComponent();
        }

        public int eId;
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

        public string eStatus
        {

            get
            {
                return eventStatus.Text;
            }

            set
            {
                eventStatus.Text = value;
            }
        }

        public void viewBtn_Click(object sender, EventArgs e)
        {
            DetailsBtn?.Invoke(this, new eventData(eId));
        }
    }
}

public class eventData : EventArgs
{
    public int Id { get; }

    public eventData(int Id)
    {
        this.Id = Id;
    }
}
