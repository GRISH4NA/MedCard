using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public class db
    {
        public static string id = "";
        public static string ids = "";
        public static string idp = "";
        static string serverName = @"WIN-9OD1QE0BF4S";
        static string dbName = "Медицинская карта";

        public SqlConnection con = new SqlConnection("Data Source=WIN-9OD1QE0BF4S;Initial Catalog=Медицинская карта;Integrated Security=True;");
    }
}
