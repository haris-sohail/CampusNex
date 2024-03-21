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

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            //DB_Connection dbConnector = new DB_Connection();
            //string query = "SELECT * FROM your_table;";
            //dbConnector.ExecuteQuery(query);
            this.Hide();
            Student s = new Student();
            // Subscribe to the FormClosed event of Form2
            s.FormClosed += studentFormClosed;
            s.Show();
        }


        private void studentFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
