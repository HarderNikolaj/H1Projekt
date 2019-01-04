using System.Data;
using System.Data.SqlClient;

namespace H1ProjektNy
{
    public static class DBConnection
    {
        //private static readonly string connectionString = "Data Source=" + Environment.MachineName + ";Initial Catalog=BKbase;Integrated Security=True;";
        private static readonly string connectionString = "Data Source=Localhost;Initial Catalog=BKbase;Integrated Security=True;";

        public static DataTable Select(string table)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = $"select * from {table}";
                conn.Open();
                var adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public static void Insert(string table, string values)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = $"Insert into {table} {values}"; 
                conn.Open();
                var cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(string table, string column, string newValue, int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = $"update {table} set {column} = {newValue} where id = {id}";
                conn.Open();
                var cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(string table, int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = $"delete from {table} where id = {id}";
                conn.Open();
                var cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
