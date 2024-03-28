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

namespace CampusNex
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        public void openRelevantScreen(string role, string user_id)
        {
            if (role.Equals("mentor"))
            {
                Mentor m = new Mentor();

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
        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            // get the username and password
            string usernameEntered = usernameTxt.Text;
            string passEntered = passTxt.Text;

            // run select query based on the entered username and password
            DB_Connection dbConnector = new DB_Connection();
            string query = "SELECT user_id, role, username FROM USERS WHERE USERS.username = '" + usernameEntered
                + "' AND USERS.password = '" + passEntered + "'";

            List<List<object>> user = dbConnector.executeSelect(query);
            
            if(user.Count != 0)
            {
                // successfully logged in
                MessageBox.Show("Welcome " + user[0][2], "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();

                // open the relevant screen according to user
                openRelevantScreen(user[0][1].ToString(), user[0][0].ToString());
            }
            else
            {
                // login failed
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void studentFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
