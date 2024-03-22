using System;
using System.Collections;
using System.Collections.Generic;
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

        public void executeInsert(List<object> toInsert, string tableName) {
            if (OpenConnection())
            {
                string query = "INSERT INTO " + tableName;
                foreach(var value in toInsert)
                {

                }
            }
        }
    }
}
