using MySql.Data.MySqlClient;
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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
            this.Shown += Student_Shown;
        }

        private void societiesBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage(((Control)sender).Text);
        }

        private void Add_Society(string Name, string Slogan, string Acronym, string Head, string Mentor, Image logo)
        {
            societyCardsPanel.Controls.Add(new societyCard()
            {
                sName = Name,
                sSlogan = Slogan,
                sAcronym = Acronym,
                sHead  = Head,
                sMentor = Mentor,
                sImage = logo
            });
          

        }

        private void Student_Shown(object sender, EventArgs e)
        {

        }

    }
}
