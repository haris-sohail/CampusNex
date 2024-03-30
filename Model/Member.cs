using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusNex.Model
{
    internal class Member
    {
        // Properties
        public int MemberId { get; set; }
        public DateTime JoinedDate { get; set; }
        public bool IsHead { get; set; }
        public Student Student { get; set; }
        public Society Society { get; set; }

        // Constructor
        public Member()
        {
            // Default constructor
        }

        // Methods
        public bool IsMember()
        {
            // Implement membership check logic here
            return true; // Example: Always return true for now
        }
    }
}
