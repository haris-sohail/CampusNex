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
        public Mentor()
        {
            // Default constructor
            
        }

        // Methods
        // Other methods specific to Mentor can be added here

        // Method to approve a society
        public void ApproveSociety(object society)
        {
            // Implement society approval logic here
        }

        internal void setMentorId()
        {
            // Set Mentor Id:
            string mID_query = "Select mentor_id from MENTORS m INNER JOIN USERS u ON" +
                " m.user_id = u.user_id where u.user_id = " + base.GetUserId();

            List<List<object>> selectResult = dbConnector.executeSelect(mID_query);
            this.MentorId = int.Parse(selectResult[0][0].ToString());

        }
    }
}
