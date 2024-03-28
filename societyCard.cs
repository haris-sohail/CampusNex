﻿using System;
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
    public partial class societyCard : Bunifu.UI.WinForms.BunifuUserControl
    {
        public societyCard()
        {
            InitializeComponent();
        }

        public Image sImage 
        {

            get {
                return societyLogo.Image;
            }

            set 
            {
                societyLogo.Image = value;
            }
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

        public string sAcronym
        {

            get
            {
                return societyAcronym.Text;
            }

            set
            {
                societyAcronym.Text = value;
            }
        }

        public string sSlogan
        {

            get
            {
                return societySlogan.Text;
            }

            set
            {
                societySlogan.Text = value;
            }
        }

        public string sHead
        {

            get
            {
                return presidentName.Text;
            }

            set
            {
                presidentName.Text = value;
            }
        }

        public string sMentor
        {

            get
            {
                return mentorName.Text;
            }

            set
            {
                mentorName.Text = value;
            }
        }

        private void societyCard_Click(object sender, EventArgs e)
        {

        }

        private void viewBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
