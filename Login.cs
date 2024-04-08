using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlX.XDevAPI;
using CampusNex.Model;

namespace CampusNex
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

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
        private void loginBtn_Click(object sender, EventArgs e)
        {
            // get the username and password
            string usernameEntered = usernameTxt.Text;
            string passEntered = passTxt.Text;

            if(User.ValidateUser(usernameEntered, passEntered, this))
            {
                clearInputFields();
                this.Hide();
            }
        }

        // Function that Clears UserName and
        // Password Fields upon successful Login
        private void clearInputFields()
        {
            usernameTxt.Text = "";
            passTxt.Text = "";
        }


        private void studentFormClosed(object sender, FormClosedEventArgs e)
        {
            // Stop Code Execution Manually
            this.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }
}
