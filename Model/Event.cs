using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusNex.Model
{
    internal class Event
    {
        // Properties
        public int EventId { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Member Organizer { get; set; }
        public Society Society { get; set; }

        // Constructor
        public Event()
        {
            // Default constructor
        }

        // Methods
        public void FetchEvent()
        {
            // Implement event fetching logic here
        }

        public void CreateEvent()
        {
            // Implement event creation logic here
        }

        public void UpdateStatus()
        {
            // Implement status updating logic here
        }
    }
}
