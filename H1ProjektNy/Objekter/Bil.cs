using System;
using System.Collections.Generic;
using System.Data;

namespace H1ProjektNy
{
    public class Bil : IDbObject
    {
        public int Id { get; set; }
        public string Registreringsnummer { get; set; }
        public string Mærke { get; set; }
        public string Model { get; set; }
        public int Årgang { get; set; }
        public int Km { get; set; }
        public DateTime Oprettelsesdato { get; set; }
        public Brændstof brændstof { get; set; }
        public int KundeId { get; set; }

        private const string table = "bil";

        public Bil(string registreringsnummer, string mærke, string model, int årgang, int km, Brændstof brændstof, int kundeId)
        {
            Registreringsnummer = registreringsnummer;
            Mærke = mærke;
            Model = model;
            Årgang = årgang;
            Km = km;
            this.brændstof = brændstof;
            KundeId = kundeId;
        }

        public static List<Bil> Select()
        {
            var dataTable = DBConnection.Select(table);
            var biler = new List<Bil>();

            foreach (DataRow item in dataTable.Rows)
            {
                //Kalder constructoren og smidder værdierne fra databasen ind i et objekt.
                Bil bil = new Bil(item[5].ToString(), item[2].ToString(), item[3].ToString(), int.Parse(item[4].ToString()), 
                    int.Parse(item[6].ToString()), (Brændstof)int.Parse(item[7].ToString()), int.Parse(item[8].ToString()));
                bil.Id = int.Parse(item[0].ToString());
                bil.Oprettelsesdato = DateTime.Parse(item[1].ToString());

                biler.Add(bil);
            }
            return biler;
        }

        public void Insert()
        {
            string values = "(Maerke, Model, Aargang, Registreringsnummer, Kilometer, Braendstoftypeid, Kundeid) " +
                $"values ('{Mærke}', '{Model}', {Årgang}, '{Registreringsnummer}', {Km}, {(int)brændstof}, {KundeId})";

            DBConnection.Insert(table, values);
        }

        public void Update(string column, string newValue) 
        {
            if (column.ToLower()=="maerke" || column.ToLower() == "model" || column.ToLower() == "registreringsnummer")
            {
                newValue = "'" + newValue + "'";
            }
            DBConnection.Update(table, column, newValue, Id);
        }

        public void Delete()
        {
            DBConnection.Delete(table, Id);
        }

        public enum Brændstof
        {
            benzin = 1, diesel = 2, hybrid = 3, el = 4
        }
    }
}
