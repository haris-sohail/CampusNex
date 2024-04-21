using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            string query = "SELECT * FROM Societies";

            List<List<object>> selectResult = dbConnector.executeSelect(query);

            return selectResult;
        }

        public List<List<object>> getAnnouncements(int user_id)
        {
            string query = "SELECT ANNOUNCEMENTS.announcement_id, ANNOUNCEMENTS.title, ANNOUNCEMENTS.body, ANNOUNCEMENTS.posted_at, ANNOUNCEMENTS.valid_till, ANNOUNCEMENTS.priority, \r\nSOCIETIES.society_name FROM ANNOUNCEMENTS\r\nINNER JOIN SOCIETIES ON\r\nSOCIETIES.society_id = ANNOUNCEMENTS.society_id\r\nINNER JOIN MEMBERS ON \r\nMEMBERS.society_id = SOCIETIES.society_id\r\nINNER JOIN STUDENTS ON\r\nSTUDENTS.student_id = MEMBERS.student_id\r\nINNER JOIN CUSERS ON\r\nCUSERS.user_id = STUDENTS.user_id\r\nWHERE CUSERS.user_id = " + user_id.ToString();
            
            List<List<object>> selectResult = dbConnector.executeSelect(query);

            return selectResult;
        }

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

        public string getCombinedDateTime(string validDate, string hours, string mins, string am_pm)
        {
            DateTime date = DateTime.Parse(validDate);

            int hoursInt = int.Parse(hours);
            int minsInt = int.Parse(mins);

            if (am_pm == "pm" && hoursInt < 12)
            {
                hoursInt += 12;
            }

            // Create the combined DateTime
            DateTime combinedDateTime = new DateTime(date.Year, date.Month, date.Day, hoursInt, minsInt, 0);

            return combinedDateTime.ToString();
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
            string query = " select username from CUsers " +
                "INNER JOIN Students " +
                "ON Students.user_id = CUsers.user_id " +
                "WHERE Students.student_id = " + headId;

            // each list contains an individual row's data

            List<List<object>> selectResult = dbConnector.executeSelect(query);

            string headName = selectResult[0][0].ToString();
            return headName;
        }

        public string getSocietyName(String societyId)
        {
            DB_Connection dbConnector = new DB_Connection();
            string query = " select society_name from Societies " +
               "WHERE society_id=" + societyId;

            List<List<object>> selectResult = dbConnector.executeSelect(query);

            string societyName = selectResult[0][0].ToString();
            return societyName;
        }

        public string getMentorName(String mentorId)
        {
            DB_Connection dbConnector = new DB_Connection();
            string query = " select username from CUsers " +
                "INNER JOIN Mentors " +
                "ON Mentors.user_id = CUsers.user_id " +
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

        public System.Drawing.Image getUserImage(int studentid)
        {
            string query = "Select user_pic from cusers u inner join" +
                " students s on u.user_id = s.user_id where student_id = " + studentid.ToString();
            List<List<object>> selectResult = dbConnector.executeSelect(query);
            return this.getImage(selectResult[0][0] as byte[]);
        }

        public string getUserName(int studentid)
        {
            DB_Connection dbConnector = new DB_Connection();
            string query = "SELECT username FROM cUsers u inner join" +
                " Students s ON u.user_id = s.user_id " +
                "WHERE s.student_id = " + studentid.ToString();

            // each list contains an individual row's data

            List<List<object>> selectResult = dbConnector.executeSelect(query);

            string userName = selectResult[0][0].ToString();
            return userName;
        }

        public System.Drawing.Image getSocietyImage(int societyid)
        {
            string query = "Select  society_logo from Societies " +
                " where  society_id = " + societyid.ToString();
            List<List<object>> selectResult = dbConnector.executeSelect(query);
            return this.getImage(selectResult[0][0] as byte[]);
        }

      

        public string getMemberInterest(int memberid)
        {
            DB_Connection dbConnector = new DB_Connection();
            string query = "SELECT interest FROM Members WHERE member_id = " + memberid.ToString();
            List<List<object>> selectResult = dbConnector.executeSelect(query);

            string memberInterest = selectResult[0][0].ToString();
            return memberInterest;

        }

       


        public string getMemberName(int memberid)
        {
            DB_Connection dbConnector = new DB_Connection();
            string query = "SELECT u.username AS student_name FROM Members m JOIN Students s ON m.student_id = s.student_id JOIN cUsers u ON s.user_id = u.user_id WHERE m.member_id = " + memberid.ToString();
            List<List<object>> selectResult = dbConnector.executeSelect(query);

            string memberName = selectResult[0][0].ToString();
            return memberName;
        }

        public System.Drawing.Image getMemberImage(int memberid)
        {
            string query = "SELECT u.user_pic " +
               "FROM Members m, Students s " +
               "JOIN cUsers u ON u.user_id = s.user_id " +
               "WHERE s.student_id = m.student_id AND m.member_id = " + memberid.ToString();
            List<List<object>> selectResult = dbConnector.executeSelect(query);
            return this.getImage(selectResult[0][0] as byte[]);
        }

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

        public static bool checkPassword(string password)
        {
            if (!checkPasswordLength(password))
            {
                return false;
            }

            return true;
        }

        // Society Registration Page
        // Validation
        public bool CheckRegistrationParams(string Name, string Slogan, string Desc)
        {
            // No leading or ending spaces
            if (Name[0] == ' ' || Name[Name.Length-1] == ' '|| Slogan[0] == ' ' || Slogan[Slogan.Length - 1] == ' ')
            {
                MessageBox.Show("One or More Field(s) has leading or ending White Spaces", "Please Fix and Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Check For Letters and Spaces only in Name
            string pattern = @"^[a-zA-Z\s]*$";
            Regex regex = new Regex(pattern);
           
            if (!regex.IsMatch(Name))
            {
                MessageBox.Show("Society Name Cannot Have any Special Characters or Numbers", "Please Fix and Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Check Length
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
