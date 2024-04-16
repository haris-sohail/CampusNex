using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;

namespace CampusNex
{
    internal class DB_Connection
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        // Constructor
        public DB_Connection()
        {
            Initialize();
        }

        // Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "campusnex";
            uid = "root";
            password = "choices";
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            connection = new MySqlConnection(connectionString);
        }

        // Open connection to the database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                // Handle exception
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
            catch (MySqlException ex)
            {
                // Handle exception
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public string getTypeOfQuery(string query)
        {

            string[] querySplit = query.Split(' ');


            string typeOfQuery = querySplit[0];

            return typeOfQuery;
        }

        static string[] GetColumnNames(MySqlDataReader reader)
        {
            var colNames = new List<string>();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                colNames.Add(reader.GetName(i));
            }

            return colNames.ToArray();
        }

        public List<List<object>> executeSelect(string query)
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                List<List<object>> selectResult = new List<List<object>>();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    var columnNames = GetColumnNames(reader);

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

        public string getMentorId(string mentorName)
        {
            DB_Connection dbConnector = new DB_Connection();
            string query = "SELECT Mentors.mentor_id FROM Mentors " +
                           "INNER JOIN Users ON Mentors.user_id = Users.user_id " +
                           "WHERE Users.username = '" + mentorName + "'";

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

        public bool UpdateData(string tableName, string[] setcolumns, string[] wherecolumns, object[] values)
        {
            StringBuilder queryBuilder = new StringBuilder($"UPDATE {tableName} SET ");

            int j = 0;
            for (int i = 0; i < setcolumns.Length; i++)
            {
                queryBuilder.Append($"{setcolumns[i]} = @param{i}");
                j++;
                if (i < setcolumns.Length - 1)
                {
                    queryBuilder.Append(", ");
                }
            }

            queryBuilder.Append($" WHERE ");
            
            for (int i = 0; i < wherecolumns.Length; i++)
            {
                queryBuilder.Append($"{wherecolumns[i]} = @param{i+j}");
                if (i < wherecolumns.Length - 1)
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

                    using (MySqlCommand command = new MySqlCommand(queryBuilder.ToString(), connection))
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            command.Parameters.AddWithValue($"@param{i}", values[i]);
                        }

                        command.ExecuteNonQuery();
                        return true;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                CloseConnection();
            }
            return false;
            
        }

        public void executeInsert(List<object> toInsert, string tableName) 
        {
            // Insert in Societies Table
            if (OpenConnection())
            {
                string mentorName = toInsert[3].ToString();
                int mentorId = int.Parse(getMentorId(mentorName));

                string query = "INSERT INTO " + tableName + "(society_name, society_slogan,society_description," +
                    "mentor_id, head_id, creation_date,society_logo) VALUES (@societyName, @societySlog, " +
                    "@societyDesc, @mentorId, @headId, @creationDate, @logoBlob)";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@societyName", MySqlDbType.String).Value = toInsert[0];
                cmd.Parameters.Add("@societySlog", MySqlDbType.String).Value = toInsert[1];
                cmd.Parameters.Add("@societyDesc", MySqlDbType.String).Value = toInsert[2];
                cmd.Parameters.Add("@mentorId", MySqlDbType.Int32).Value = mentorId;
                cmd.Parameters.Add("@headId", MySqlDbType.Int32).Value = int.Parse(toInsert[5].ToString());
                cmd.Parameters.Add("@creationDate", MySqlDbType.Date).Value = DateTime.Today;
                cmd.Parameters.Add("@logoBlob", MySqlDbType.Blob).Value = toInsert[4];

                cmd.ExecuteNonQuery();
                CloseConnection();
               
            }
            string query1 = "INSERT INTO Members (student_id, society_id, join_date, is_head, " +
                   "interest,status) VALUES (" + int.Parse(toInsert[5].ToString())
               + "," + getSocietyId(toInsert[0].ToString()) + "," +
               "@date, 1, '' ,'pending')";
            // Insert in Members Table
            if (OpenConnection())
            {
              
                MySqlCommand cmd = new MySqlCommand(query1, connection);
                cmd.Parameters.Add("@date", MySqlDbType.Date).Value = DateTime.Today;
                cmd.ExecuteNonQuery();
                CloseConnection();
            }

        }

     
        public void executeInsert2(List<object> toInsert, string tableName)     //purpose of this function is to insert data into db
        {                                                                         //this function will store student registration for member data in db
            if (OpenConnection())
            {
                string query = "INSERT INTO " + tableName + "(student_id, society_id, join_date,  is_head, interest, status) " +
                 " VALUES (@userID, @societyID, @date, @head, @interest, 'pending')";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@userID", MySqlDbType.Int32).Value = toInsert[0];
                cmd.Parameters.Add("@societyID", MySqlDbType.Int32).Value = toInsert[1];
                cmd.Parameters.Add("@date", MySqlDbType.Date).Value = toInsert[2];
                bool isHead = (bool)toInsert[3];
                cmd.Parameters.Add("@head", MySqlDbType.Bit).Value = isHead ? 1 : 0; // bool converted to 0 or 1
                cmd.Parameters.Add("@interest", MySqlDbType.String).Value = toInsert[4];

                cmd.ExecuteNonQuery();
                CloseConnection() ;  
            }
        }

        public void executeInsertAnnouncement(List<object> toInsert)
        {
            if (OpenConnection())
            {
                string query = "INSERT INTO ANNOUNCEMENTS (society_id, head_id, title, body, posted_at, valid_till, priority) " +
                    " VALUES (@societyId, @headId, @title, @body, @postedAt, @validTill, @priority)";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@societyId", MySqlDbType.String ).Value = toInsert[0];
                cmd.Parameters.Add("@headId", MySqlDbType.String ).Value = toInsert[1];
                cmd.Parameters.Add("@title", MySqlDbType.String ).Value = toInsert[2];
                cmd.Parameters.Add("@body", MySqlDbType.String ).Value = toInsert[3];
                cmd.Parameters.Add("@postedAt", MySqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@validTill", MySqlDbType.DateTime).Value = DateTime.Parse(toInsert[4].ToString());
                cmd.Parameters.Add("@priority", MySqlDbType.String).Value = toInsert[5];

                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }


        //function to get societyId
        public string getSocietyId(string societyName)
        {
                string societyId = null; // Default value if not found

                // SQL query to retrieve the society_id based on the society_name
                string query = "SELECT Societies.society_id FROM Societies WHERE Societies.society_name = '" + societyName + "'";

                try
                {
                    // Execute the select query
                    List<List<object>> selectResult = executeSelect(query);

                    // Check if a result is returned
                    if (selectResult != null && selectResult.Count > 0 && selectResult[0].Count > 0)
                    {
                        // Retrieve the society_id from the result
                        societyId = selectResult[0][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions
                    MessageBox.Show("Error: " + ex.Message);
                }

                return societyId;
            



        }

        


    }
}
