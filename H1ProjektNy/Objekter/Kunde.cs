using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace H1ProjektNy
{
    public class Kunde : IDbObject
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }
        public DateTime Oprettelsesdato { get; set; }

        private static readonly string table = "kunde";

        public Kunde(string fornavn, string efternavn, string adresse, string email)
        {
            Fornavn = fornavn;
            Efternavn = efternavn;
            Adresse = adresse;
            Email = email;
        }

        public static List<Kunde> Select()
        {
            var datatable = DBConnection.Select(table);
            var kunder = new List<Kunde>();

            foreach (DataRow item in datatable.Rows)
            {
                Kunde kunde = new Kunde(item[1].ToString(), item[2].ToString(), item[3].ToString(), item[4].ToString());
                kunde.Id = int.Parse(item[0].ToString());
                kunde.Oprettelsesdato = DateTime.Parse(item[5].ToString());

                kunder.Add(kunde);
            }
            return kunder.OrderBy(c => c.Efternavn).ToList(); //Alle kunder sorteres efter efternavn
        }

        public void Delete()
        {
            DBConnection.Delete(table, Id);
        }

        public void Insert()
        {
            string values = "(fornavn, efternavn, adresse, email) " +
                $"values ('{Fornavn}', '{Efternavn}', '{Adresse}', '{Email}')";
            DBConnection.Insert(table, values);
        }

        public void Update(string column, string newValue)
        {
            newValue = "'" + newValue + "'";
            DBConnection.Update(table, column, newValue, Id);
        }
    }
}
