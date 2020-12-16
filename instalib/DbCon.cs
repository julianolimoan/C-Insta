using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace instalib
{
     public class DbCon
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "instadb";
            string username = "root";
            string password = "";

            return DbConnect.GetDBConnection(host, port, database, username, password);

        }
    }
}
