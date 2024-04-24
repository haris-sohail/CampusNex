using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusNex
{
    internal class Credentials
    {
        public string server;
        public string database;
        public string uid;

        public Credentials()
        {
            server = "SOMALSPC\\SQLEXPRESS";
            database = "campusnex";
        }
    }
}
