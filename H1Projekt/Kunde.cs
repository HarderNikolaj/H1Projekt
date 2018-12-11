using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Projekt
{
    public class Kunde
    {
        public int ID { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }
        public DateTime Oprettelsesdato { get; private set; }

        public Kunde()
        {

        }
        public Kunde(string fornavn, string efternavn, string adresse, string email)
        {
            Fornavn = fornavn;
            Efternavn = efternavn;
            Adresse = adresse;
            Email = email;
        }
        public static void OpretKunde(string fornavn, string efternavn, string adresse, string email)
        {
            var query = $"insert into Kunde (fornavn, efternavn, adresse, email) values ('{fornavn}','{efternavn}','{adresse}','{email}')";
            DBConnection.Insert(query);
        }
        public static void OpretKunde(Kunde kunde)
        {
            var query = $"insert into Kunde (fornavn, efternavn, adresse, email) values ('{kunde.Fornavn}','{kunde.Efternavn}','{kunde.Adresse}','{kunde.Email}')";
            DBConnection.Insert(query);
        }
        public static void SletKunde(string soegning)
        {
            try
            {
                var query = $"delete from kunde where ID = {soegning}";

            }
            catch (Exception)
            {
                Console.WriteLine("Der er indtasten en forkert værdi, der er ikke foretaget en sletning.");
            }
        }

    }
}
