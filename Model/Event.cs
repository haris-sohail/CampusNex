using Google.Protobuf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusNex.Model
{
    // Changed Accessibility
    public class Event
    {
        // Properties
        public int EventId { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int OrganizerId { get; set; }
        public int SocietyId { get; set; }
        public string Status { get; set; }
        public byte[] EventImg { get; set; }

        private static DB_Connection dbConnector = new DB_Connection();
        // Constructor
        public Event(int eventId)
        {
            // Fetch Event Data From Database
            this.EventId = eventId;
            FetchEvent();
        }
        public Event() { }

        // Methods
        public void FetchEvent()
        {
            // Implement event fetching logic here
            string query = "Select * From Events where event_id = " + EventId.ToString();
            List<List<object>> selectResult = dbConnector.executeSelect(query);

            this.SocietyId = int.Parse(selectResult[0][1].ToString());
            this.Title = selectResult[0][2].ToString();
            this.Date = DateTime.Parse(selectResult[0][3].ToString()).ToShortDateString();
            this.Time = TimeSpan.Parse(selectResult[0][4].ToString());
            this.Location = selectResult[0][5].ToString();
            this.Description = selectResult[0][6].ToString();
            this.Type = selectResult[0][7].ToString();
            this.OrganizerId = int.Parse(selectResult[0][8].ToString());
            this.Status = selectResult[0][9].ToString();
            this.EventImg = (byte[])selectResult[0][10];

        }

        public static void AddEvent(Event e)
        {
            Console.WriteLine(e.Time);
            Console.WriteLine(e.Date);
            string query = "INSERT INTO Events (society_id, title, event_date, " +
                "event_time, location, description, event_type, organizer_id, status,event_Img)" +
                " VALUES ('"+ e.SocietyId.ToString() +"','"+e.Title +"','"+e.Date+"','"+
                e.Time+"','"+e.Location+"','"+e.Description+"','"+ e.Type+ "','" +
                e.OrganizerId + "','pending', @logoBlob);";
            // Execute Insert
            if (dbConnector.OpenConnection())
            {

                SqlCommand cmd = new SqlCommand(query, dbConnector.connection);
                cmd.Parameters.Add("@logoBlob", MySqlDbType.Blob).Value = e.EventImg;

                cmd.ExecuteNonQuery();
                dbConnector.connection.Close();
            }
           
        }

        public void rejectEvent(string reason)
        {
            // Update Database
            DB_Connection DB_Connector = new DB_Connection();
            // Set status to accepted
            string tableName = "Events";
            string[] scolumns = { "status","comments"};
            string[] wcolumns = { "event_id" };
            object[] values = { "rejected",reason, this.EventId };

            // Call the UpdateData method
            bool success = DB_Connector.UpdateData(tableName, scolumns, wcolumns, values);

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
