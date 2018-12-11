using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace H1Projekt
{
    static class DBConnection
    {
        private static readonly string connectionString = "Data Source=" + Environment.MachineName + ";Initial Catalog=BKbase;Integrated Security=True;";

        public static void Insert(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }
        public static int Delete(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                return cmd.ExecuteNonQuery();
            }
        }


        public static void Select(string query)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(table);

                foreach (DataRow item in table.Rows)
                {
                    Console.WriteLine(item["id"].ToString());
                    Console.WriteLine();
                }
            }
        }

        //public static void Update(string query)
        //{
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand(query, con);
        //        cmd.ExecuteNonQuery();
        //    }
        //}
    }
}
