using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace CampusNex.Model
{
    internal class Society
    {
        Util utilObj = new Util();
        // Properties
        public int SocietyId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int MentorId { get; set; }
        public string Slogan { get; set; }
        public byte[] Logo { get; set; }
        public string Description { get; set; }
        public int HeadId { get; set; }

        public string status { get; set; }
        public List<Member> Members { get; set; } = new List<Member>();
        public List<Event> Events { get; set; } = new List<Event>();
        public List<Announcement> Announcements { get; set; } = new List<Announcement>();

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
        }

    }
}
