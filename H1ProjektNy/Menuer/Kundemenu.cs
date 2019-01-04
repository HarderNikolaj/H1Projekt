using System;

namespace H1ProjektNy.Menuer
{
    class Kundemenu : Menu
    {
        public void Menu()
        {
            Console.WriteLine("1: Opret kunde\n2: Opdater kunde\n3: Slet kunde\n4: Vis kundes biler");
            char valg = Console.ReadKey().KeyChar;

            switch (valg)
            {
                case '1':
                    kunde = OpretKunde();
                    Console.WriteLine($"{kunde.Fornavn} {kunde.Efternavn} belv oprettet i systemet");
                    break;
                case '2':
                    OpdaterKunde();
                    break;
                case '3':
                    SletKunde();
                    break;
                case '4':
                    VisBiler();
                    break;
                default:
                    break;
            }
        }

        public Kunde OpretKunde()
        {
            Console.WriteLine("Indtast venligst fornavn");
            string fornavn = Console.ReadLine();
            Console.WriteLine("Indtast venligst efternavn");
            string efternavn = Console.ReadLine();
            Console.WriteLine("Indtast venligst adresse");
            string adresse = Console.ReadLine();
            Console.WriteLine("Indtast venligst email");
            string email = Console.ReadLine();

            kunde = new Kunde(fornavn, efternavn, adresse, email);
            kunde.Insert();
            return kunde;
        }

        public void OpdaterKunde()
        {
            Console.WriteLine("Indtast ID på den kunde der skal opdateres");
            int id = int.Parse(Console.ReadLine());

            var kunder = Kunde.Select();
            kunde = kunder.Find(c => c.Id == id); //Går listen med kunder igennem og returnerer kunden med det bestemte id

            Console.WriteLine($"Fornavn: {kunde.Fornavn}\nEfternavn: {kunde.Efternavn}\nAdresse: {kunde.Adresse}\nEmail: {kunde.Email}");
            Console.WriteLine("Hvilken kolonne vil du ændre?");
            string column = Console.ReadLine();
            Console.WriteLine("Hvad skal den nye værdi være?");
            string newValue = Console.ReadLine();

            kunde.Update(column, newValue);
            Console.WriteLine($"{column} er nu blevet ændret til {newValue}");
        }

        public void SletKunde()
        {
            Console.WriteLine("Indtast ID på den kunde der skal slettes");
            int id = int.Parse(Console.ReadLine());

            var kunder = Kunde.Select();
            kunde = kunder.Find(c => c.Id == id);

            Console.WriteLine($"Er du sikker på at du vil slette {kunde.Fornavn} {kunde.Efternavn} fra databasen? (y/n)");
            char svar = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (svar == 'y')
            {
                kunde.Delete();
                Console.WriteLine("Kunden blev slettet");
            }
            else
            {
                Console.WriteLine("Kunden blev ikke slettet");
            }
        }

        public void VisBiler()
        {
            Console.WriteLine("Indtast kundeID");
            int id = int.Parse(Console.ReadLine());

            var kunder = Kunde.Select();
            kunde = kunder.Find(c => c.Id == id);

            var biler = Bil.Select();
            var kundebiler = biler.FindAll(c => c.KundeId == id);
            foreach (var bil in kundebiler)
            {
                Console.WriteLine($"{bil.Mærke} {bil.Model} fra {bil.Årgang}\nHar kørt: {bil.Km} km\n");
            }
        }
    }
}
