using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;

namespace CampusNex
{
    internal class DB_Connection
    {
        private MySqlConnection connection;
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
        private bool OpenConnection()
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

            }
            return false;
            
        }
    

        public void executeInsert(List<object> toInsert, string tableName) {
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
            }
        }

        
    }
}
