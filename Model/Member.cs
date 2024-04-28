/*
 *              CAMPUSNEX MODEL CLASS: Member.cs
 *              
 *              Coded By ACECODERS:
 *              
 *                      -> Kalsoom Tariq (i21-2487)
 *                      -> Haris Sohail (i21-0531)
 *                      -> Aiman Safdar (i21-0588)
 *                      
 */
using System;
using System.Collections.Generic;

namespace CampusNex.Model
{
    public class Member
    {
        // Data Members
        public int MemberId { get; set; }
        public DateTime JoinedDate { get; set; }
        public bool IsHead { get; set; }
        public int StudentId { get; set; }
        public int SocietyId { get; set; }
        public string status { get; set; }
        public string Comments { get; set; }
        protected static DB_Connection dbConnector = new DB_Connection();
        // Constructors
        public Member() { }
        public Member(int student_id, int index)
        {
            this.StudentId = student_id;
            FetchDatabyStId(index);
        }
        public Member(int memberId)
        {
            this.MemberId = memberId;
            FetchDatabyMemId();
        }

        // Fetch Member By Member ID
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

        // Fetch Members By Student Id
        private void FetchDatabyStId(int index)
        {
            string query = "Select * from Members where student_id = " + this.StudentId.ToString();
            List<List<object>> selectResult = dbConnector.executeSelect(query);
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

        // Return the No Of Societies A Student is Member of
        public static int IsMember(int student_id)
        {
            string query = "Select Count(*) from Members where student_id = " + student_id.ToString();
            List<List<object>> selectResult = dbConnector.executeSelect(query);
            return int.Parse(selectResult[0][0].ToString());
        }

        // Overload ToString Operator for debugging
        public override string ToString()
        {
            return $"\nMember: MemberId: {this.MemberId}\nStudentId: {this.StudentId}\n"
                +$"SocietyId: {this.SocietyId}\nIsHead: {this.IsHead}\nStatus: {this.status}\n";
        }

        // Delete Member From Database
        public void DeleteMember()
        {
            DB_Connection dbConnector = new DB_Connection();
            dbConnector.DeleteRejectedMember(this.MemberId);
        }

        // Reject Member
        public static void rejectMember(int mid, string reason)
        {
            DB_Connection DB_Connector = new DB_Connection();
            string tableName = "Members";
            string[] scolumns = { "status", "comments" };
            string[] wcolumns = { "member_id" };
            object[] values = { "rejected", reason, mid };
            bool success = DB_Connector.UpdateData(tableName, scolumns, wcolumns, values);
        }
    }
}