using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace CampusNex.Model
{

    internal abstract class User
    {
        // Properties
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public Image UserImage { get; set; }

        protected static DB_Connection dbConnector;
        protected Util utilObj;

        // Constructor
        public User()
        {
            // Default constructor
        }

        // Methods
        // Getters
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

        // Setters
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

        // Other methods

        public void initialize(string user_id)
        {
            this.UserId = int.Parse(user_id);
            this.utilObj = new Util();
            this.FetchData();
        }

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

            // Implement validation logic here
            // run select query based on the entered username and password
            string query = "SELECT user_id, role, username FROM USERS WHERE USERS.username = '" + username
                + "' AND USERS.password = '" + password + "'";

            List<List<object>> user = dbConnector.executeSelect(query);

            if (user.Count != 0)
            {
                // successfully logged in
                MessageBox.Show("Welcome " + user[0][2], "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // open the relevant screen according to user
                loginForm.openRelevantScreen(user[0][1].ToString(), user[0][0].ToString());

                return true;
            }
            else
            {
                // login failed
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }
        public void FetchData()
        {
            // Populate the User Class
            // By fetching data from DB
            string query = "Select * From Users where user_id = " + this.GetUserId().ToString();
            List<List<object>> selectResult = dbConnector.executeSelect(query);

            // Set all Values
            SetUsername(selectResult[0][1].ToString());
            SetPassword(selectResult[0][2].ToString());
            SetEmail(selectResult[0][3].ToString());
            SetRole(selectResult[0][4].ToString());
            SetUserImage(utilObj.getImage((selectResult[0][5] as byte[])));

        }

        public void SearchSociety(string keyword)
        {
            // Implement society search logic here
        }
    }

}
