using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CampusNex
{
    public partial class Mentor : Form
    {
        public Mentor()
        {
            InitializeComponent();
            this.Shown += Student_Shown;
        }

        private void societiesBtn_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage(((Control)sender).Text);
        }

        private void Add_Society(string Name, string Slogan, string Acronym, string Head, string Mentor, System.Drawing.Image logo)
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

        public string getMentorName(String mentorId)
        {
            DB_Connection dbConnector = new DB_Connection();
            string query = " select username from Users " +
                "INNER JOIN Mentors " +
                "ON Mentors.user_id = Users.user_id " +
                "WHERE Mentors.user_id = " + mentorId;

            // each list contains an individual row's data

            List<List<object>> selectResult = dbConnector.executeSelect(query);

            string mentorName = selectResult[0][0].ToString();
            return mentorName;
        }

        public string getHeadName(String headId)
        {
            DB_Connection dbConnector = new DB_Connection();
            string query = " select username from Users " +
                "INNER JOIN Students " +
                "ON Students.user_id = Users.user_id " +
                "WHERE Students.user_id = " + headId;

            // each list contains an individual row's data

            List<List<object>> selectResult = dbConnector.executeSelect(query);

            string headName = selectResult[0][0].ToString();
            return headName;
        }

        public string getAcronym(string societyName)
        {
            string[] splitName = societyName.Split(' ');

            string acronym = "";

            foreach(var word in splitName)
            {
                acronym += word[0];
            }

            return acronym;
        }

        public System.Drawing.Image getImage(byte[] imageBlob)
        {
            System.Drawing.Image societyImg;

            using (MemoryStream memoryStr = new MemoryStream(imageBlob))
            {
                societyImg = System.Drawing.Image.FromStream(memoryStr);
            }

            return societyImg;
        }
        private void Student_Shown(object sender, EventArgs e)
        {
            // get societies from database

            DB_Connection dbConnector = new DB_Connection();
            string query = "SELECT * FROM Societies;";

            // each list contains an individual row's data

            List<List<object>> selectResult = dbConnector.executeSelect(query);

            // Add society cards from the select results
            foreach(var row in selectResult) {
                // Get the columns in the correct order
                string societyName = row[1].ToString();
                string sSlogan = row[2].ToString();
                string sMentorId = row[4].ToString();
                string sHeadId = row[5].ToString();


                byte[] imageBlob = (byte[])row[7];

                System.Drawing.Image societyImg = getImage(imageBlob);

                // get mentor and head names
                string mentorName = getMentorName(sMentorId);

                string headName = getHeadName(sHeadId);

                string acronym = getAcronym(societyName); 

                Add_Society(societyName, sSlogan, acronym, headName, mentorName, societyImg);
            }
        }
    }
}
