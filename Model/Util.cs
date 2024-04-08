﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusNex.Model
{
    internal class Util
    {
        DB_Connection dbConnector = new DB_Connection();
        public System.Drawing.Image getImage(byte[] imageBlob)
        {
            System.Drawing.Image img = null;


            using (MemoryStream memoryStr = new MemoryStream(imageBlob))
            {
                img = System.Drawing.Image.FromStream(memoryStr);
            }


            return img;
        }
        // Added Image Resize Function
        public System.Drawing.Image ResizeImage(System.Drawing.Image image, int width, int height)
        {
            // Create a new bitmap with the desired dimensions
            Bitmap resizedImage = new Bitmap(width, height);

            // Draw the original image onto the new bitmap using Graphics
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(image, 0, 0, width, height);
            }

            // Return the resized image
            return resizedImage;
        }
        // Get Number of rows in Table
        public int getCount(string tableName)
        {
            string query = "SELECT COUNT(*) FROM "+tableName;
            List<List<object>> selectResult = dbConnector.executeSelect(query);
            return int.Parse(selectResult[0][0].ToString());
        }

        public List<List<object>> getAllSocieties()
        {
            string query = "SELECT * FROM Societies WHERE STATUS='accepted'";

            List<List<object>> selectResult = dbConnector.executeSelect(query);

            return selectResult;
        }

        public string getAcronym(string societyName)
        {
            string[] splitName = societyName.Split(' ');

            string acronym = "";

            foreach (var word in splitName)
            {
                acronym += word[0];
            }

            return acronym;
        }

        public string getHeadName(String headId)
        {
            DB_Connection dbConnector = new DB_Connection();
            string query = " select username from Users " +
                "INNER JOIN Students " +
                "ON Students.user_id = Users.user_id " +
                "WHERE Students.student_id = " + headId;

            // each list contains an individual row's data

            List<List<object>> selectResult = dbConnector.executeSelect(query);

            string headName = selectResult[0][0].ToString();
            return headName;
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
    }
}
