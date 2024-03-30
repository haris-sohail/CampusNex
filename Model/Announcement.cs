using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusNex.Model
{
    internal class Announcement
    {
        // Properties
        public int AnnouncementId { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public Member Head { get; set; }
        public Society Society { get; set; }

        // Constructor
        public Announcement()
        {
            // Default constructor
        }

        // Methods
        public void PostAnnouncement(Member head)
        {
            // Implement announcement posting logic here
        }

        public void ViewAnnouncement()
        {
            // Implement announcement viewing logic here
        }
    }

}
