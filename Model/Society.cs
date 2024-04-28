using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace CampusNex.Model
{
    // Changed Accessibility
    public class Society
    {
        Util utilObj = new Util();
        // Properties
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

        // Helping Properties
        public string headName { get; set; }
        public string mentorName { get; set; }
        public string acronym { get; set; }

        // Constructor
        public Society()
        {
            // Default constructor
        }

        // Methods
        public void FetchData()
        {
            // Implement data fetching logic here
        }

        public void UpdateStatus()
        {
            // Implement status updating logic here
        }

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

            // Initialize Head and Mentor Info
            this.mentorName = utilObj.getMentorName(this.MentorId.ToString());
            this.headName = utilObj.getHeadName(this.HeadId.ToString());
            this.acronym = utilObj.getAcronym(this.Name);


        }

        // Reject Society
        public void rejectSociety(string reason)
        {
            // Update Database
            DB_Connection DB_Connector = new DB_Connection();

            string tableName = "Societies";
            string[] scolumns = { "status", "comments" };
            string[] wcolumns = { "society_id" };
            object[] values = { "rejected", reason, this.SocietyId };

            // Call the UpdateData method
            bool success = DB_Connector.UpdateData(tableName, scolumns, wcolumns, values);

        }

        public void DeleteSociety()
        {
            DB_Connection DB_Connector = new DB_Connection();
            DB_Connector.DeleteSocietyAndMember(this.SocietyId);
        }

        // Overload ToString Operator for debugging
        public override string ToString()
        {
            // Customize the string representation of the object
            return $"\nSociety:{this.Name}\n SocietyId: {this.SocietyId}\nHeadname: {this.headName}\n"
                + $"Mentor Name: {this.mentorName}\nSlogan: {this.Slogan}\nStatus: {this.status}\n";
        }

    }
}
