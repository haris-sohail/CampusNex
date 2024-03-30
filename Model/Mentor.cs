using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
