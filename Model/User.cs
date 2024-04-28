/*
 *              CAMPUSNEX MODEL CLASS: User.cs
 *              
 *              Coded By ACECODERS:
 *              
 *                      -> Kalsoom Tariq (i21-2487)
 *                      -> Haris Sohail (i21-0531)
 *                      -> Aiman Safdar (i21-0588)
 *                      
 */

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CampusNex.Model
{

    internal abstract class User
    {
        // Data Members
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public Image UserImage { get; set; }

        // Helping Members
        protected static DB_Connection dbConnector;
        protected Util utilObj;

        // Initializors and Mutators
        public string GetUsername()
        {
            return Username;
        }
        public string GetPassword()
        {
            return Password;
        }
        public int GetUserId()
        {
            return UserId;
        }
        public string GetRole()
        {
            return Role;
        }
        public string GetEmail()
        {
            return Email;
        }
        public Image GetUserImage()
        {
            return UserImage;
        }
        public void SetUsername(string username)
        {
            Username = username;
        }
        public void SetPassword(string password)
        {
            Password = password;
        }
        public void SetUserId(int userId)
        {
            UserId = userId;
        }
        public void SetRole(string role)
        {
            Role = role;
        }
        public void SetEmail(string email)
        {
            Email = email;
        }
        public void SetUserImage(Image image)
        {
            UserImage = image;
        }

        // Initialize Function
        public void initialize(string user_id)
        {
            this.UserId = int.Parse(user_id);
            this.utilObj = new Util();
            this.FetchData();
        }

        // User Validation
        public static bool ValidateUser(string username, string password, Login loginForm)
        {
            if (!Util.checkUsername(username))
            {
                return false;
            }

            if (!Util.checkPassword(password))
            {
                return false;
            }

            dbConnector = new DB_Connection();
            string query = "SELECT user_id, role, username FROM CUSERS WHERE CUSERS.username = '" + username
                + "' AND CUSERS.password = '" + password + "'";

            List<List<object>> user = dbConnector.executeSelect(query);
            if (user.Count != 0)
            {
                MessageBox.Show("Welcome " + user[0][2], "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loginForm.openRelevantScreen(user[0][1].ToString(), user[0][0].ToString());
                return true;
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Fetch Data from Database
        public void FetchData()
        {
            string query = "Select * From CUsers where user_id = " + this.GetUserId().ToString();
            List<List<object>> selectResult = dbConnector.executeSelect(query);
            SetUsername(selectResult[0][1].ToString());
            SetPassword(selectResult[0][2].ToString());
            SetEmail(selectResult[0][3].ToString());
            SetRole(selectResult[0][4].ToString());
            SetUserImage(utilObj.getImage((selectResult[0][5] as byte[])));

        }
    }
}