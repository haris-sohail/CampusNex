using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CampusNex.Model
{
    internal class Mentor : User
    {
        // Properties specific to Mentor
        public int MentorId { get; set; }
        public string Designation { get; set; }
        public string Info { get; set; }

        // Constructor
        public Mentor(string user_id)
        {
            // Default constructor
            base.initialize(user_id);
            this.FetchMData();
            
        }

        // Methods
        // Other methods specific to Mentor can be added here

        // Method to approve a society
        public void ApproveSociety(object society)
        {
            // Implement society approval logic here
        }

        private void FetchMData()
        {
            string query = "Select * From Mentors where user_id = " + base.GetUserId().ToString();
            List<List<object>> selectResult = dbConnector.executeSelect(query);

            this.MentorId = int.Parse(selectResult[0][0].ToString());
            this.Designation = selectResult[0][2].ToString();
            this.Info = selectResult[0][3].ToString();
        }
    }
}
