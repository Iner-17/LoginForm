using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm
{
    internal class DBConnection
    {
        private static readonly String connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;";

        public static MySqlConnection getConnection()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
    }
}
