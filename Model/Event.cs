/*
 *              CAMPUSNEX MODEL CLASS: Event.cs
 *              
 *              Coded By ACECODERS:
 *              
 *                      -> Kalsoom Tariq (i21-2487)
 *                      -> Haris Sohail (i21-0531)
 *                      -> Aiman Safdar (i21-0588)
 *                      
 */
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CampusNex.Model
{
    public class Event
    {
        // Data Members
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
        public string Comments { get; set; }
        public byte[] EventImg { get; set; }

        private static DB_Connection dbConnector = new DB_Connection();

        // Constructors
        public Event() { }
        public Event(int eventId)
        {
            this.EventId = eventId;
            FetchEvent();
        }


        // Fetch Events From Database
        public void FetchEvent()
        {
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
            this.Comments = selectResult[0][11].ToString();
        }

        // Insert Event to Database
        public static void AddEvent(Event e)
        {
            string query = "INSERT INTO Events (society_id, title, event_date, " +
                "event_time, location, description, event_type, organizer_id, status,event_Img)" +
                " VALUES ('"+ e.SocietyId.ToString() +"','"+e.Title +"','"+e.Date+"','"+
                e.Time+"','"+e.Location+"','"+e.Description+"','"+ e.Type+ "','" +
                e.OrganizerId + "','pending', @logoBlob);";
            if (dbConnector.OpenConnection())
            { 
                SqlCommand cmd = new SqlCommand(query, dbConnector.connection);
                cmd.Parameters.AddWithValue("@logoBlob", MySqlDbType.Blob).Value = e.EventImg;

                cmd.ExecuteNonQuery();
                dbConnector.connection.Close();
            }
        }

        // Reject Event
        public void rejectEvent(string reason)
        {
            DB_Connection DB_Connector = new DB_Connection();
            string tableName = "Events";
            string[] scolumns = { "status","comments"};
            string[] wcolumns = { "event_id" };
            object[] values = { "rejected",reason, this.EventId };
            bool success = DB_Connector.UpdateData(tableName, scolumns, wcolumns, values);
        }

        // Delete Event From Database
        public void DeleteEvent()
        {
            dbConnector.DeleteRejectedEvent(this.EventId);
        }
    }
}
