using System;
using System.Collections.Generic;
using System.Data;

namespace H1ProjektNy
{
    public class Værkstedsbesøg : IDbObject
    {
        public int Id { get; set; }
        public DateTime Aftaletidspunkt { get; set; }
        public int BilId { get; set; }
        public decimal Pris { get; set; }

        private static readonly string table = "vaerkstedsbesoeg";

        public Værkstedsbesøg(DateTime aftaletidspunkt, int bilId, decimal pris)
        {
            Aftaletidspunkt = aftaletidspunkt;
            BilId = bilId;
            Pris = pris;
        }

        public static List<Værkstedsbesøg> Select()
        {
            var datatable = DBConnection.Select(table);
            var værkstedsbesøg = new List<Værkstedsbesøg>();

            foreach (DataRow item in datatable.Rows)
            {
                Værkstedsbesøg besøg = new Værkstedsbesøg(DateTime.Parse(item[1].ToString()), int.Parse(item[2].ToString()), int.Parse(item[3].ToString()));
                besøg.Id = int.Parse(item[0].ToString());
                værkstedsbesøg.Add(besøg);
            }
            return værkstedsbesøg;
        }

        public void Delete()
        {
            DBConnection.Delete(table, Id);
        }

        public void Insert()
        {
            string values = "(aftaletidspunkt, bilid, pris) " +
                $"values ('{Aftaletidspunkt}', {BilId}, {Pris})";
            DBConnection.Insert(table, values);
        }

        public void Update(string column, string newValue)
        {
            if (column.ToLower() == "aftaletidspunkt")
            {
                newValue = "'" + newValue + "'";
            }
            DBConnection.Update(table, column, newValue, Id);
        }
    }
}
