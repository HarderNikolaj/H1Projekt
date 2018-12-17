using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace H1Projekt
{
    class DBConnections
    {
        public static readonly string connectionstring = "Data Source=" + Environment.MachineName + ";Initial Catalog=BKbase;Integrated Security=True;";

        public static DataTable Select(string query)
        {
            using (var conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                var adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
        public static string SelectSingleValue(string query)
        {
            string værdi = "";
            using (var conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                var cmd = new SqlCommand(query, conn);
                værdi = cmd.ExecuteScalar().ToString();
            }

            return værdi;
        }
        public static void InsertInto(string query)
        {
            using (var conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                var cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }
        public static void Delete(int id, string tabel)
        {
            using (var conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                var query = $"delete from {tabel} where id = {id}";
                var cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }
        public static void Update(string query)
        {
            using (var conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                var cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
