using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Connessione
    {
        public static SqlConnection GetConnection()
        {
            string con = ConfigurationManager.ConnectionStrings["DBHotel"].ToString();
            SqlConnection sql = new SqlConnection(con);
            return sql;
        }
        public static SqlDataReader GetReader(string CommandText, SqlConnection con)
        {
            SqlCommand sqlCommand = new SqlCommand(CommandText, con);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            return reader;
        }
    }
}