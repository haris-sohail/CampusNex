/*
 *              CAMPUSNEX MODEL CLASS: Util.cs
 *              
 *              Coded By ACECODERS:
 *              
 *                      -> Kalsoom Tariq (i21-2487)
 *                      -> Haris Sohail (i21-0531)
 *                      -> Aiman Safdar (i21-0588)
 *                      
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CampusNex.Model
{
    internal class Util
    {
        // Helping Data Member
        DB_Connection dbConnector = new DB_Connection();

        // Function to convert Byte Image to Image Type
        public System.Drawing.Image getImage(byte[] imageBlob)
        {
            System.Drawing.Image img = null;
            using (MemoryStream memoryStr = new MemoryStream(imageBlob))
            {
                img = System.Drawing.Image.FromStream(memoryStr);
            }
            return img;
        }

        // Function to Return Rows Of Table
        public int getCount(string tableName)
        {
            string query = "SELECT COUNT(*) FROM "+tableName;
            List<List<object>> selectResult = dbConnector.executeSelect(query);
            return int.Parse(selectResult[0][0].ToString());
        }

        // Function to Fetch Societies data From Database
        public List<List<object>> getAllSocieties()
        {
            string query = "SELECT * FROM Societies";
            List<List<object>> selectResult = dbConnector.executeSelect(query);
            return selectResult;
        }

        // Function to fetch Announcements
        public List<List<object>> getAnnouncements(int user_id)
        {
            string query = "SELECT ANNOUNCEMENTS.announcement_id, ANNOUNCEMENTS.title, ANNOUNCEMENTS.body, ANNOUNCEMENTS.posted_at, ANNOUNCEMENTS.valid_till, ANNOUNCEMENTS.priority, \r\nSOCIETIES.society_name FROM ANNOUNCEMENTS\r\nINNER JOIN SOCIETIES ON\r\nSOCIETIES.society_id = ANNOUNCEMENTS.society_id\r\nINNER JOIN MEMBERS ON \r\nMEMBERS.society_id = SOCIETIES.society_id\r\nINNER JOIN STUDENTS ON\r\nSTUDENTS.student_id = MEMBERS.student_id\r\nINNER JOIN CUSERS ON\r\nCUSERS.user_id = STUDENTS.user_id\r\nWHERE CUSERS.user_id = " + user_id.ToString();
            List<List<object>> selectResult = dbConnector.executeSelect(query);
            return selectResult;
        }

        // Checlk Announcements Expiry
        public bool announcement_is_expired(Announcement announcement)
        {
            if(DateTime.Now > announcement.validTill)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Function to combine date and time
        public string getCombinedDateTime(string validDate, string hours, string mins, string am_pm)
        {
            DateTime date = DateTime.Parse(validDate);

            int hoursInt = int.Parse(hours);
            int minsInt = int.Parse(mins);

            if (am_pm == "pm" && hoursInt < 12)
            {
                hoursInt += 12;
            }
            DateTime combinedDateTime = new DateTime(date.Year, date.Month, date.Day, hoursInt, minsInt, 0);
            return combinedDateTime.ToString();
        }

        // Function to Return Acronym
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

        // Function to get Head Name
        public string getHeadName(String headId)
        {
            DB_Connection dbConnector = new DB_Connection();
            string query = " select username from CUsers " +
                "INNER JOIN Students " +
                "ON Students.user_id = CUsers.user_id " +
                "WHERE Students.student_id = " + headId;
            List<List<object>> selectResult = dbConnector.executeSelect(query);
            string headName = selectResult[0][0].ToString();
            return headName;
        }

        // Function to get Mentor Name
        public string getMentorName(String mentorId)
        {
            DB_Connection dbConnector = new DB_Connection();
            string query = " select username from CUsers " +
                "INNER JOIN Mentors " +
                "ON Mentors.user_id = CUsers.user_id " +
                "WHERE Mentors.mentor_id = " + mentorId;
            List<List<object>> selectResult = dbConnector.executeSelect(query);
            string mentorName = selectResult[0][0].ToString();
            return mentorName;
        }

        // Function to Convert Image to Byte Stream
        public byte[] convertToByteStream(System.Drawing.Image image)
        {
            byte[] bytes;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                bytes = ms.ToArray();
            }
            return bytes;
        }

        // Function to fetch Student's Image
        public System.Drawing.Image getUserImage(int studentid)
        {
            string query = "Select user_pic from cusers u inner join" +
                " students s on u.user_id = s.user_id where student_id = " + studentid.ToString();
            List<List<object>> selectResult = dbConnector.executeSelect(query);
            return this.getImage(selectResult[0][0] as byte[]);
        }

        // Check Function for UserName Length
        public static bool checkUserNameLength(string userName)
        {
            if(userName.Count() == 0)
            {
                MessageBox.Show("Username should not be empty", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (userName.Count() >= 5 && userName.Count() <= 15)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Username length should be between 5 and 15", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }
        // Check Function for Password Length
        public static bool checkPasswordLength(string password)
        {
            if (password.Count() == 0)
            {
                MessageBox.Show("Password should not be empty", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (password.Count() >= 5 && password.Count() <= 20)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Password length should be between 5 and 20", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        // Check Function for UserName Special Characters
        public static bool checkUserNameSpecialChars(string username)
        {
            if (username.All(Char.IsLetter))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Username should only contain alphabets", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Check Function for UserName 
        public static bool checkUsername(string username)
        {

            if (!checkUserNameLength(username))
            {
                return false;
            }

            if (!checkUserNameSpecialChars(username))
            {
                return false;
            }
            return true;
        }
        // Check Function for Password
        public static bool checkPassword(string password)
        {
            if (!checkPasswordLength(password))
            {
                return false;
            }

            return true;
        }

        // Check Sociey Registration Fields
        public bool CheckRegistrationParams(string Name, string Slogan, string Desc)
        {
            if (Name[0] == ' ' || Name[Name.Length-1] == ' '|| Slogan[0] == ' ' || Slogan[Slogan.Length - 1] == ' ')
            {
                MessageBox.Show("One or More Field(s) has leading or ending White Spaces", "Please Fix and Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string pattern = @"^[a-zA-Z\s]*$";
            Regex regex = new Regex(pattern);
           
            if (!regex.IsMatch(Name))
            {
                MessageBox.Show("Society Name Cannot Have any Special Characters or Numbers", "Please Fix and Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Name.Count() < 5 || Name.Count() > 40)
            {
                MessageBox.Show("Society Name should be between 5 and 20 Characters", "Please Fix and Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Slogan.Count() < 5 || Slogan.Count() > 100)
            {
                MessageBox.Show("Society Slogan should be between 5 and 100 Characters", "Please Fix and Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Desc.Count() < 20 || Desc.Count() > 255)
            {
                MessageBox.Show("Society Description should be between 20 and 255 Characters", "Please Fix and Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
