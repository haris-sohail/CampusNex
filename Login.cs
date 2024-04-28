/*
 *              CAMPUSNEX CONTROLLER CLASSES: Login.cs
 *              
 *              Coded By ACECODERS:
 *              
 *                      -> Kalsoom Tariq (i21-2487)
 *                      -> Haris Sohail (i21-0531)
 *                      -> Aiman Safdar (i21-0588)
 *                      
 */
using System;
using System.Windows.Forms;
using CampusNex.Model;

namespace CampusNex
{
    public partial class Login : Form
    {
        // Constructor
        public Login()
        {
            InitializeComponent();
        }

        // Screen Navigation Function
        public void openRelevantScreen(string role, string user_id)
        {
            if (role.Equals("mentor"))
            {
                Mentor m = new Mentor(user_id);

                m.FormClosed += studentFormClosed;

                m.Show();
            }

            else
            {
                Student s = new Student(user_id);
                s.FormClosed += studentFormClosed;
                s.Show();
            }
        }

        // Login Button Handler
        private void loginBtn_Click(object sender, EventArgs e)
        {
            string usernameEntered = usernameTxt.Text;
            string passEntered = passTxt.Text;

            if (User.ValidateUser(usernameEntered, passEntered, this))
            {
                clearInputFields();
                this.Hide();
            }

            else
            {
                clearInputFields();
            }
        }

        // Function to Clear Fields
        private void clearInputFields()
        {
            usernameTxt.Text = "";
            passTxt.Text = "";
        }
        // Function to Show login Screen
        private void studentFormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        // Dismiss Button Handler
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}