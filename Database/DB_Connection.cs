/*
 *              CAMPUSNEX DATABASE CLASS: DB_Connection.cs
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
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace CampusNex
{
    public class DB_Connection
    {
        // Data Members
        public SqlConnection connection;
        private string server;
        private string database;

        // Constructor
        public DB_Connection()
        {
            Initialize();
        }

        // Initialize values
        private void Initialize()
        {
            Credentials c = new Credentials();
            this.server = c.server;
            this.database = c.database;
            string connectionString = $"Data Source={this.server};Initial Catalog={this.database};Integrated Security=True;";
            connection = new SqlConnection(connectionString);
        }

        // Open connection to the database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Generic Select Statement
        public List<List<object>> executeSelect(string query)
        {
            if (OpenConnection())
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                List<List<object>> selectResult = new List<List<object>>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        List<object> row = new List<object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row.Add(reader[i]);
                        }
                        selectResult.Add(row);
                    }
                }
                CloseConnection();
                return selectResult;
            }
            else
            {
                return null;
            }
        }

        // Fetch Mentor ID From Name
        public string GetMentorId(string mentorName)
        {
            DB_Connection dbConnector = new DB_Connection();
            string query = "SELECT Mentors.mentor_id FROM Mentors " +
                           "INNER JOIN CUsers ON Mentors.user_id = CUsers.user_id " +
                           $"WHERE CUsers.username = '{mentorName}'";

            List<List<object>> selectResult = dbConnector.executeSelect(query);

            if (selectResult[0].Count > 0 && selectResult.Count > 0)
            {
                string mentorId = selectResult[0][0].ToString();
                return mentorId;
            }
            else
            {
                return null;
            }
        }

        // Generic Update Function
        public bool UpdateData(string tableName, string[] setColumns, string[] whereColumns, object[] values)
        {
            StringBuilder queryBuilder = new StringBuilder($"UPDATE {tableName} SET ");

            int j = 0;
            for (int i = 0; i < setColumns.Length; i++)
            {
                queryBuilder.Append($"{setColumns[i]} = @param{i}");
                j++;
                if (i < setColumns.Length - 1)
                {
                    queryBuilder.Append(", ");
                }
            }

            queryBuilder.Append($" WHERE ");

            for (int i = 0; i < whereColumns.Length; i++)
            {
                queryBuilder.Append($"{whereColumns[i]} = @param{i + j}");
                if (i < whereColumns.Length - 1)
                {
                    queryBuilder.Append(", ");
                }
            }

            Console.WriteLine(queryBuilder);

            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine(values[i]);
            }

            if (OpenConnection())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(queryBuilder.ToString(), connection))
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            command.Parameters.AddWithValue($"@param{i}", values[i]);
                        }

                        command.ExecuteNonQuery();
                        CloseConnection();
                        return true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                } 
            }
            CloseConnection();
            return false;
        }

        // Insert Data Into Society Table
        public void InsertSocietyAndMember(List<object> toInsert, string tableName)
        {
            if (OpenConnection())
            {
                string mentorName = toInsert[3].ToString();
                int mentorId = int.Parse(GetMentorId(mentorName));

                string query = $"INSERT INTO {tableName} (society_name, society_slogan, society_description, " +
                    "mentor_id, head_id, creation_date, society_logo, status) VALUES (@societyName, @societySlog, " +
                    "@societyDesc, @mentorId, @headId, @creationDate, @logoBlob, @status)";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.Add("@societyName", SqlDbType.VarChar).Value = toInsert[0];
                cmd.Parameters.Add("@societySlog", SqlDbType.VarChar).Value = toInsert[1];
                cmd.Parameters.Add("@societyDesc", SqlDbType.VarChar).Value = toInsert[2];
                cmd.Parameters.Add("@mentorId", SqlDbType.Int).Value = mentorId;
                cmd.Parameters.Add("@headId", SqlDbType.Int).Value = int.Parse(toInsert[5].ToString());
                cmd.Parameters.Add("@creationDate", SqlDbType.Date).Value = DateTime.Today;
                cmd.Parameters.Add("@logoBlob", SqlDbType.VarBinary).Value = toInsert[4];
                cmd.Parameters.Add("@status", SqlDbType.NVarChar).Value = "pending";

                cmd.ExecuteNonQuery();
                CloseConnection();
            }

            string query1 = $"INSERT INTO Members (student_id, society_id, join_date, is_head, interest, status) " +
               $"VALUES ({int.Parse(toInsert[5].ToString())}, {GetSocietyId(toInsert[0].ToString())}, " +
               $"@date, 1, '', 'pending')";

            if (OpenConnection())
            {
                SqlCommand cmd = new SqlCommand(query1, connection);
                cmd.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Today;
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        // Delete Society And Member
        public void DeleteSocietyAndMember(int societyId)
        {
            if (OpenConnection())
            {
                string deleteMemberQuery = "DELETE FROM Members WHERE society_id = @societyId and is_head = 1";
                SqlCommand deleteMemberCmd = new SqlCommand(deleteMemberQuery, connection);
                deleteMemberCmd.Parameters.AddWithValue("@societyId", societyId);
                deleteMemberCmd.ExecuteNonQuery();
                string deleteSocietyQuery = "DELETE FROM Societies WHERE society_id = @societyId";
                SqlCommand deleteSocietyCmd = new SqlCommand(deleteSocietyQuery, connection);
                deleteSocietyCmd.Parameters.AddWithValue("@societyId", societyId);
                deleteSocietyCmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        // Delete Event Entry
        public void DeleteRejectedEvent(int eventId)
        {
            if (OpenConnection())
            {
                string deleteSocietyQuery = "DELETE FROM events WHERE event_id = @eventId";
                SqlCommand deleteSocietyCmd = new SqlCommand(deleteSocietyQuery, connection);
                deleteSocietyCmd.Parameters.AddWithValue("@eventId", eventId);
                deleteSocietyCmd.ExecuteNonQuery();

                CloseConnection();
            }
        }

        // Delete Member Entry
        public void DeleteRejectedMember(int memId)
        {
            if (OpenConnection())
            {
                string deleteSocietyQuery = "DELETE FROM members WHERE member_id = @memId";
                SqlCommand deleteSocietyCmd = new SqlCommand(deleteSocietyQuery, connection);
                deleteSocietyCmd.Parameters.AddWithValue("@memId", memId);
                deleteSocietyCmd.ExecuteNonQuery();

                CloseConnection();
            }
        }


        public void InsertMember(List<object> toInsert, string tableName)
        {
            if (OpenConnection())
            {
                string query = $"INSERT INTO {tableName} (student_id, society_id, join_date,  is_head, interest, status) " +
                 "VALUES (@userID, @societyID, @date, @head, @interest, 'pending')";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.Add("@userID", SqlDbType.Int).Value = toInsert[0];
                cmd.Parameters.Add("@societyID", SqlDbType.Int).Value = toInsert[1];
                cmd.Parameters.Add("@date", SqlDbType.Date).Value = toInsert[2];
                bool isHead = (bool)toInsert[3];
                cmd.Parameters.Add("@head", SqlDbType.Bit).Value = isHead ? 1 : 0;
                cmd.Parameters.Add("@interest", SqlDbType.VarChar).Value = toInsert[4];

                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        // Insert into Announcements Table
        public void ExecuteInsertAnnouncement(List<object> toInsert)
        {
            if (OpenConnection())
            {
                string query = "INSERT INTO ANNOUNCEMENTS (society_id, head_id, title, body, posted_at, valid_till, priority) " +
                    " VALUES (@societyId, @headId, @title, @body, @postedAt, @validTill, @priority)";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.Add("@societyId", SqlDbType.VarChar).Value = toInsert[0];
                cmd.Parameters.Add("@headId", SqlDbType.VarChar).Value = toInsert[1];
                cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = toInsert[2];
                cmd.Parameters.Add("@body", SqlDbType.VarChar).Value = toInsert[3];
                cmd.Parameters.Add("@postedAt", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@validTill", SqlDbType.DateTime).Value = DateTime.Parse(toInsert[4].ToString());
                cmd.Parameters.Add("@priority", SqlDbType.VarChar).Value = toInsert[5];

                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }
        
        // Function to get society id
        public string GetSocietyId(string societyName)
        {
            string societyId = null;
            string query = $"SELECT Societies.society_id FROM Societies WHERE Societies.society_name = '{societyName}'";
            try
            {
                List<List<object>> selectResult = executeSelect(query);

                if (selectResult != null && selectResult.Count > 0 && selectResult[0].Count > 0)
                {
                    societyId = selectResult[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return societyId;
        }

    }
}