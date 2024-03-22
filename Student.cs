﻿using Bunifu.UI.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

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
                "WHERE Mentors.mentor_id = " + mentorId;

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
            string query = "SELECT * FROM Societies WHERE STATUS='accepted';";

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

        private void rSocietyForm_Click(object sender, EventArgs e)
        {
            StudentPages.SetPage(((Control)sender).Text);
            // Load Dropdown of available Mentors
            string query = @"
            SELECT U.username AS mentor_name
            FROM Mentors M
            INNER JOIN Users U ON M.user_id = U.user_id
            LEFT JOIN Societies S ON M.mentor_id = S.mentor_id
            WHERE U.role = 'mentor'
            GROUP BY M.mentor_id
            HAVING COUNT(S.society_id) < 2;"
            ;
            DB_Connection dbConnector = new DB_Connection();
            List<List<object>> selectResult = dbConnector.executeSelect(query);
            // Add society cards from the select results
  
            foreach (var row in selectResult)
            {
                // Get the columns in the correct order
                string mentorName = row[0].ToString();
                Console.WriteLine(mentorName);
                availableMentors.Items.Add(mentorName);
            }
        }

        private void uploadImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDial = new OpenFileDialog();
            fileDial.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff)|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff";

            if (fileDial.ShowDialog() == DialogResult.OK)
            {
                uploadImgPicBox.Image = new Bitmap(fileDial.FileName);
            }
        }

        public byte[] convertToByteStream(System.Drawing.Image image)
        {
            byte[] bytes;

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat); // Choose appropriate format
                bytes = ms.ToArray();
            }

            return bytes;
        }
        private void regNewSociety_Click(object sender, EventArgs e)
        {
            DB_Connection dbConnector = new DB_Connection();

            List<object> formInput = new List<object>();

            formInput.Add(societyName.Text);
            formInput.Add(societySlogan.Text);
            formInput.Add(societyDesc.Text);
            formInput.Add(availableMentors.Text);

            // convert the image to byte stream
            byte[] imageBytes = convertToByteStream(uploadImgPicBox.Image);

            formInput.Add(imageBytes);

            dbConnector.executeInsert(formInput, "Societies");
        }
    }
}
