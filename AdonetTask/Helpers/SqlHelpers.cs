using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdonetTask.Helpers
{
    internal  static class SqlHelpers
    {
        private const string _connectionString = @"Server= DESKTOP-2DRTN1J\RS;Database = adonettask;Trusted_Connection=true";
        public static DataTable GetDatas(string query)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            DataTable dt = new DataTable();
            using SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            sda.Fill(dt);
            connection.Close();
            return dt;
        }
        public static int Exec(string query)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand command = new SqlCommand(query, connection);
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;

        }
    }
}
