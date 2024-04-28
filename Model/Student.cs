/*
 *              CAMPUSNEX MODEL CLASS: Student.cs
 *              
 *              Coded By ACECODERS:
 *              
 *                      -> Kalsoom Tariq (i21-2487)
 *                      -> Haris Sohail (i21-0531)
 *                      -> Aiman Safdar (i21-0588)
 *                      
 */
using System.Collections.Generic;
namespace CampusNex.Model
{
    internal class Student : User
    {
        // Data Members
        public int StudentId { get; set; }
        public string RollNo { get; set; }
        // Helping Member
        public int nOfm = 0;
        public List<Member> Members { get; set; } = new List<Member>();
        // Constructor
        public Student(string user_id)
        {
            base.initialize(user_id);
            this.FetchSData();
            this.nOfm = Member.IsMember(this.StudentId);
            for(int i = 0; i < this.nOfm; i++)
            {
                Member m = new Member(this.StudentId, i);
                Members.Add(m);
            }
        }

        // Fetch Student Data from Database
        private void FetchSData()
        {
            string query = "Select * From Students where user_id = " + base.GetUserId().ToString();
            List<List<object>> selectResult = dbConnector.executeSelect(query);

            this.StudentId = int.Parse(selectResult[0][0].ToString());
            this.RollNo = selectResult[0][2].ToString();
        }
    }
}