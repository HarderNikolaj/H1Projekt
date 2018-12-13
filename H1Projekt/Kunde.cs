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
            OpretKunde(fornavn, efternavn, adresse, email);
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
        public static void SletKunde(string id)
        {
            try
            {
                var query = $"delete from bil where KundeID = {id} delete from kunde where ID = {id}";
                if (DBConnection.Delete(query) > 0)
                {
                    Console.WriteLine($"Kunden med ID {id} og alle kundens biler blev slettet");
                }
                else
                {
                    Console.WriteLine($"Kunden med ID {id} kunne ikke findes.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void Update(int id)
        {
            DBConnection.Select($"select * from kunde where id = {id}");

            Console.WriteLine("Indtast venligst nyt fornavn");
            string fornavn = Console.ReadLine();
            Console.WriteLine("Indtast venligst nyt efternavn");
            string efternavn = Console.ReadLine();
            Console.WriteLine("Indtast venligst ny adresse");
            string adresse = Console.ReadLine();
            Console.WriteLine("Indtast venligst ny e-mail");
            string email = Console.ReadLine();

            string query = $"update kunde set Fornavn = '{fornavn}', Efternavn = '{efternavn}', Adresse = '{adresse}', Email = '{email}' where ID = {id}";
            DBConnection.Update(query);
        }
        public static void SelectSingle(int id)
        {
            DBConnection.Select($"select * from kunde where id = {id}");
        }
    }
}
