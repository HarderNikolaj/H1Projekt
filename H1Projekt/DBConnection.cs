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
                    //looper igennem alle kolonner og udskriver værdierne
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        string f = table.Columns[i].ToString();
                        if (table.Columns[i].ToString().Length>20)
                        {
                            f = table.Columns[i].ToString().Substring(0, 20);
                        }
                        Console.WriteLine(string.Format("{0,-20}: {1,30}",f, item[i].ToString()));
                    }
                    Console.WriteLine();
                }
            }
        }
        public static bool CheckForEksistens(int id, string tabel)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var query = $"select count(id) from {tabel} where id = {id} ";
                var cmd = new SqlCommand(query, con);
                var num = (int) cmd.ExecuteScalar();
                if (num > 0)
                    return true;
                else
                    return false;

            }
        }

        public static int SelectNewestIdFromBil()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select top 1 * from bil order by id desc";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                int id = (int)cmd.ExecuteScalar();
                return id;
            }
        }

        public static void Update(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }

        public static int ReturnerAntal(string tabel)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"select count(id) from {tabel}", con);
                return (int) cmd.ExecuteScalar();
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
