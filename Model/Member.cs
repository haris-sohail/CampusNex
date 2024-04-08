using System;
using System.Collections.Generic;
using System.Data.Common;
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
        public int StudentId { get; set; }
        public int SocietyId { get; set; }
        public string status { get; set; } 
        protected static DB_Connection dbConnector = new DB_Connection();
        // Constructor
        public Member(int student_id, int index)
        {
            // Initialize all Member Related 
            // Attributes
            this.StudentId = student_id;
            FetchData(index);
        }

        // Methods
        private void FetchData(int index)
        {
            string query = "Select * from Members where student_id = " + this.StudentId.ToString() + " and status = 'accepted'";
            List<List<object>> selectResult = dbConnector.executeSelect(query);
            this.MemberId = int.Parse(selectResult[index][0].ToString());
            this.SocietyId = int.Parse(selectResult[index][2].ToString());
            this.JoinedDate = DateTime.Parse(selectResult[index][3].ToString());
            this.IsHead = Boolean.Parse(selectResult[index][4].ToString());
            Console.WriteLine("Is Head: ", this.IsHead);
            this.status = selectResult[index][6].ToString();

        }
        public static int IsMember(int student_id)
        {
            string query = "Select Count(*) from Members where student_id = " + student_id.ToString() + " and status = 'accepted'";
            List<List<object>> selectResult = dbConnector.executeSelect(query);

            return int.Parse(selectResult[0][0].ToString()); // Returns Number Of Society Memberships
        }
    }
}
