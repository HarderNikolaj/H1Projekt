using System;

namespace H1ProjektNy.Menuer
{
    class Værkstedsmenu : Menu
    {
        public void Menu()
        {
            Console.WriteLine("1: Opret værkstedsbesøg\n2:Opdater værkstedsbesøg\n3:Slet værkstedsbesøg");
            char svar = Console.ReadKey().KeyChar;
            switch (svar)
            {
                case '1':
                    værkstedsbesøg = OpretVærkstedsbesøg();
                    Console.WriteLine($"Værkstedsbesøg {værkstedsbesøg.Id} d. {værkstedsbesøg.Aftaletidspunkt} blev oprettet i databasen");
                    break;
                case '2':
                    OpdaterVærkstedsbesøg();
                    break;
                case '3':
                    SletVærkstedsbesøg();
                    break;
                default:
                    break;
            }
        }

        public Værkstedsbesøg OpretVærkstedsbesøg()
        {
            Console.WriteLine("Indtast venligst Aftaletidspunkt (yyyy-mm-dd hh:mm)");
            DateTime tidspunkt = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Indtast venligst BilID");
            int bilid = int.Parse(Console.ReadLine());
            Console.WriteLine("Indtast venligst pris");
            decimal pris = decimal.Parse(Console.ReadLine());

            værkstedsbesøg = new Værkstedsbesøg(tidspunkt, bilid, pris);
            værkstedsbesøg.Insert();

            return værkstedsbesøg;
        }

        public void OpdaterVærkstedsbesøg()
        {
            Console.WriteLine("Indtast ID på det værkstedsbesøg der skal opdateres");
            int id = int.Parse(Console.ReadLine());

            var liste = Værkstedsbesøg.Select();
            var besøg = liste.Find(c => c.Id == id);

            Console.WriteLine($"Aftaletidspunkt: {besøg.Aftaletidspunkt}, BilID: {besøg.BilId}, pris: {besøg.Pris}");
            Console.WriteLine("Hvilken kolonne vil du ændre?");
            string column = Console.ReadLine();
            Console.WriteLine("Hvad skal den nye værdi være?");
            string newValue = Console.ReadLine();

            besøg.Update(column, newValue);
            Console.WriteLine($"{column} er nu blevet ændret til {newValue}");
        }

        public void SletVærkstedsbesøg()
        {
            Console.WriteLine("Indtast ID på det værkstedsbesøg der skal slettes");
            int id = int.Parse(Console.ReadLine());

            var liste = Værkstedsbesøg.Select();
            var besøg = liste.Find(c => c.Id == id);

            Console.WriteLine($"Er du sikker på at du vil slette aftalen d. {besøg.Aftaletidspunkt} fra databasen? (y/n)");
            char svar = Console.ReadKey().KeyChar;

            if (svar == 'y')
            {
                besøg.Delete();
                Console.WriteLine("Aftalen er blevet slettet");
            }
            else
            {
                Console.WriteLine("Aftalen blev ikke slettet");
            }
        }
    }
}
