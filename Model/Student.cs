using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusNex.Model
{
    internal class Student : User
    {
        // Properties specific to Student
        public int StudentId { get; set; }
        public string RollNo { get; set; }
        // As one Student Can be a Member of atleast two societies
        public int nOfm = 0;
        public List<Member> Members { get; set; } = new List<Member>();
        // Constructor
        public Student(string user_id)
        {
            // Initialize SuperClass Attributes
            base.initialize(user_id);

            // Initialize Student Attributes
            this.FetchSData();

            // Check for membership
            this.nOfm = Member.IsMember(this.StudentId);
         
            for(int i = 0; i < this.nOfm; i++)
            {
                Member m = new Member(this.StudentId, i);
                Members.Add(m);
            }

        }

        // Methods
        // Other methods specific to Student can be added here
        private void FetchSData()
        {
            string query = "Select * From Students where user_id = " + base.GetUserId().ToString();
            List<List<object>> selectResult = dbConnector.executeSelect(query);

            this.StudentId = int.Parse(selectResult[0][0].ToString());
            this.RollNo = selectResult[0][2].ToString();
        }
        // Method to register for a society
        public void RegisterSociety(object society)
        {
            // Implement society registration logic here
        }
    }
}
