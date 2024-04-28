using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CampusNex.Model
{
    // Changed Accessibility
    public class Member
    {
        // Properties
        public int MemberId { get; set; }
        public DateTime JoinedDate { get; set; }
        public bool IsHead { get; set; }
        public int StudentId { get; set; }
        public int SocietyId { get; set; }
        public string status { get; set; }
        public string Comments { get; set; }
        protected static DB_Connection dbConnector = new DB_Connection();
        // Constructor
        public Member()
        {

        }
        public Member(int student_id, int index)
        {
            // Initialize all Member Related 
            // Attributes
            this.StudentId = student_id;
            FetchDatabyStId(index);
        }
        public Member(int memberId)
        {
            this.MemberId = memberId;
            FetchDatabyMemId();
        }
        private void FetchDatabyMemId()
        {
            string query = "Select * from Members where member_id = " + this.MemberId.ToString();
            List<List<object>> selectResult = dbConnector.executeSelect(query);
            if (selectResult.Count == 0)
            {
                return;
            }
            this.StudentId = int.Parse(selectResult[0][1].ToString());
            this.SocietyId = int.Parse(selectResult[0][2].ToString());
            this.JoinedDate = DateTime.Parse(selectResult[0][3].ToString());
            this.IsHead = Boolean.Parse(selectResult[0][4].ToString());
            this.status = selectResult[0][6].ToString();
            this.Comments = selectResult[0][7].ToString();
        }

        // Methods
        private void FetchDatabyStId(int index)
        {
            string query = "Select * from Members where student_id = " + this.StudentId.ToString();
            List<List<object>> selectResult = dbConnector.executeSelect(query);
            // Correct Later
            // Change datatype
            if (selectResult.Count == 0)
            {
                return;
            }
            this.MemberId = int.Parse(selectResult[index][0].ToString());
            this.SocietyId = int.Parse(selectResult[index][2].ToString());
            this.JoinedDate = DateTime.Parse(selectResult[index][3].ToString());
            this.IsHead = Boolean.Parse(selectResult[index][4].ToString());
            this.status = selectResult[index][6].ToString();
            this.Comments = selectResult[0][7].ToString();


        }
        public static int IsMember(int student_id)
        {
            string query = "Select Count(*) from Members where student_id = " + student_id.ToString();
            List<List<object>> selectResult = dbConnector.executeSelect(query);

            return int.Parse(selectResult[0][0].ToString()); // Returns Number Of Society Memberships
        }

        // Overload ToString Operator for debugging
        public override string ToString()
        {
            // Customize the string representation of the object
            return $"\nMember: MemberId: {this.MemberId}\nStudentId: {this.StudentId}\n"
                +$"SocietyId: {this.SocietyId}\nIsHead: {this.IsHead}\nStatus: {this.status}\n";
        }

        public void DeleteMember()
        {
            DB_Connection dbConnector = new DB_Connection();
            dbConnector.DeleteRejectedMember(this.MemberId);
        }

        public static void rejectMember(int mid, string reason)
        {
            // Update Database
            DB_Connection DB_Connector = new DB_Connection();

            string tableName = "Members";
            string[] scolumns = { "status", "comments" };
            string[] wcolumns = { "member_id" };
            object[] values = { "rejected", reason, mid };

            // Call the UpdateData method
            bool success = DB_Connector.UpdateData(tableName, scolumns, wcolumns, values);

        }
    }
}
