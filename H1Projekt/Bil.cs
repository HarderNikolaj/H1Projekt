using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Projekt
{
    public class Bil
    {
        public int ID { get; set; }
        public DateTime Oprettelsesdato { get; set; }
        public string Maerke { get; set; }
        public string Model { get; set; }
        public int Aargang { get; set; }
        public string Registreringsnummer { get; set; }
        public int Km { get; set; }
        public int BraendstoftypeID { get; set; }
        public int KundeID { get; set; }

        public Bil()
        {

        }
        public Bil(string maerke, string model, int aargang, string regnr, int km, int bTypeId, int kundeId)
        {
            Maerke = maerke;
            Model = model;
            Aargang = aargang;
            Registreringsnummer = regnr;
            Km = km;
            BraendstoftypeID = bTypeId;
            KundeID = kundeId;
            //OpretBil(maerke, model, aargang, regnr, km, bTypeId, kundeId);
        }

        public void OpretBil(string maerke, string model, int aargang, string regnr, int km, int bTypeId, int kundeId)
        {
            string query = $"insert into bil (Maerke, Model, Aargang,Registreringsnummer,Kilometer,BraendstoftypeID,KundeID) values('{maerke}', '{model}', {aargang}, '{regnr}', {km}, {bTypeId}, {kundeId})";
            DBConnection.Insert(query);
        }

        public void OpretBil(Bil bil)
        {
            string query = $"insert into bil (Maerke, Model, Aargang,Registreringsnummer,Kilometer,BraendstoftypeID,KundeID) values('{bil.Maerke}','{bil.Model}',{bil.Aargang},'{bil.Registreringsnummer}',{bil.Km},{bil.BraendstoftypeID},{bil.KundeID})";
            DBConnection.Insert(query);
        }
        public static void SletBil(string soegning)
        {
            try
            {
                string query = $"delete from bil where id = {soegning}";
                if (DBConnection.Delete(query)>0)
                {
                    Console.WriteLine($"Bilen med ID {soegning} blev slettet");
                }
                else
                {
                    Console.WriteLine("Der blev ikke fundet en bil med det ID");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("");
            }
        }
    }
}
