/*
 *              CAMPUSNEX MODEL CLASS: Announcements.cs
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
    public class Announcement
    {
        // Data Members
        public int AnnouncementId { get; set; }
        public string announcementTitle { get; set; }
        public string announcementBody { get; set; }
        public string societyName { get; set; }
        public DateTime postedAt { get; set; }
        public DateTime validTill { get; set; }
        public string priority { get; set; }

        // Constructors
        public Announcement(){}

        // Initialize Object
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
    }

}
