using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusNex.Model
{
    // Changed Accessibility
    public class Announcement
    {
        // Properties
        public int AnnouncementId { get; set; }
        public string announcementTitle { get; set; }
        public string announcementBody { get; set; }
        public string societyName { get; set; }
        public DateTime postedAt { get; set; }
        public DateTime validTill { get; set; }
        public string priority { get; set; }

        // Constructor
        public Announcement()
        {
            // Default constructor
        }

        // Methods

        public void initialize(List<object> announcementDetails)
        {
            this.AnnouncementId = int.Parse(announcementDetails[0].ToString());
            this.announcementTitle = announcementDetails[1].ToString();
            this.announcementBody = announcementDetails[2].ToString();
            this.postedAt = DateTime.Parse(announcementDetails[3].ToString());
            this.validTill = DateTime.Parse(announcementDetails[4].ToString());
            this.priority = announcementDetails[5].ToString();
            this.societyName = announcementDetails[6].ToString();
        }
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
