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
        // Properties
        public int SocietyId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int MentorId { get; set; }
        public string Slogan { get; set; }
        public byte[] Logo { get; set; }
        public string Description { get; set; }
        public Member Head { get; set; }
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

    }
}
