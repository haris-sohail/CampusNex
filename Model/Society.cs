/*
 *              CAMPUSNEX MODEL CLASS: Society.cs
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
    public class Society
    {
        // Data Members
        Util utilObj = new Util();
        public int SocietyId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int MentorId { get; set; }
        public string Slogan { get; set; }
        public string Comments { get; set; }
        public byte[] Logo { get; set; }
        public string Description { get; set; }
        public int HeadId { get; set; }
        public string status { get; set; }
        public List<Member> Members { get; set; } = new List<Member>();
        public List<Event> Events { get; set; } = new List<Event>();
        public List<Announcement> Announcements { get; set; } = new List<Announcement>();
        // Helping Data Members
        public string headName { get; set; }
        public string mentorName { get; set; }
        public string acronym { get; set; }

        // Constructors
        public Society() { }

        // Fetch Data From Database
        public void initialize(List<object> society)
        {
            this.SocietyId = int.Parse(society[0].ToString());
            this.Name = society[1].ToString();
            this.Slogan = society[2].ToString();
            this.Description = society[3].ToString();
            this.MentorId = int.Parse(society[4].ToString());
            this.HeadId = int.Parse(society[5].ToString());
            this.CreationDate = DateTime.Parse(society[6].ToString());
            this.Logo = (byte[])society[7];
            this.status = society[8].ToString();
            this.Comments = society[9].ToString();

            this.mentorName = utilObj.getMentorName(this.MentorId.ToString());
            this.headName = utilObj.getHeadName(this.HeadId.ToString());
            this.acronym = utilObj.getAcronym(this.Name);


        }

        // Reject Society
        public void rejectSociety(string reason)
        {
            DB_Connection DB_Connector = new DB_Connection();

            string tableName = "Societies";
            string[] scolumns = { "status", "comments" };
            string[] wcolumns = { "society_id" };
            object[] values = { "rejected", reason, this.SocietyId };
            bool success = DB_Connector.UpdateData(tableName, scolumns, wcolumns, values);
        }

        // Delete Society from Database
        public void DeleteSociety()
        {
            DB_Connection DB_Connector = new DB_Connection();
            DB_Connector.DeleteSocietyAndMember(this.SocietyId);
        }

        // Overload ToString Operator for debugging
        public override string ToString()
        {
            return $"\nSociety:{this.Name}\n SocietyId: {this.SocietyId}\nHeadname: {this.headName}\n"
                + $"Mentor Name: {this.mentorName}\nSlogan: {this.Slogan}\nStatus: {this.status}\n";
        }
    }
}
