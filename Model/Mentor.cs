/*
 *              CAMPUSNEX MODEL CLASS: Mentor.cs
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
    internal class Mentor : User
    {
        // Data Members
        public int MentorId { get; set; }
        public string Designation { get; set; }
        public string Info { get; set; }

        // Constructor
        public Mentor(string user_id)
        {
            base.initialize(user_id);
            this.FetchMData();   
        }
        // Fetch Mentor Data From Database
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
