using System;
using static H1ProjektNy.Bil;

namespace H1ProjektNy.Menuer
{
    class Bilmenu : Menu
    {
        public void Menu()
        {
            System.Console.WriteLine("1: Opret bil\n2: Opdater bil\n3:Slet bil\n4: Vis bil");
            char svar = Console.ReadKey().KeyChar;

            switch (svar)
            {
                case '1':
                    bil = OpretBil();
                    Console.WriteLine($"Kunde nr {bil.KundeId}s {bil.Mærke} {bil.Model} er blevet oprettet i systemet");
                    break;
                case '2':
                    OpdaterBil();
                    break;
                case '3':
                    SletBil();
                    break;
                case '4':
                    VisBil();
                    break;
                default:
                    break;
            }
        }

        public Bil OpretBil()
        {
            Console.WriteLine("Indtast venligst registreringsnummer");
            string regnr = Console.ReadLine();
            Console.WriteLine("Indtast venligst mærke");
            string mærke = Console.ReadLine();
            Console.WriteLine("Indtast venligst model");
            string model = Console.ReadLine();
            Console.WriteLine("Indtast venligst årgang");
            int årgang = int.Parse(Console.ReadLine());
            Console.WriteLine("Indtast venligst antal kørte kilometer");
            int km = int.Parse(Console.ReadLine());
            Console.WriteLine("Indtast venligst brændstoftype (ID)");
            Brændstof brændstof = (Brændstof)int.Parse(Console.ReadLine());
            Console.WriteLine("Indtast venligst kundeID");
            int kundeid = int.Parse(Console.ReadLine());

            bil = new Bil(regnr,mærke, model, årgang, km, brændstof,kundeid);
            bil.Insert();
            return bil;
        }

        public void OpdaterBil()
        {
            Console.WriteLine("Indtast ID på den bil der skal opdateres");
            int id = int.Parse(Console.ReadLine());

            var biler = Select();
            bil = biler.Find(c => c.Id == id);

            Console.WriteLine($"Registreringsnummer: {bil.Registreringsnummer}\nMærke: {bil.Mærke}\nModel: {bil.Model}\nÅrgang: {bil.Årgang}\n" +
                $"Antal km kørt: {bil.Km}\nBrændstoftype: {bil.brændstof}\nKundeID: {bil.KundeId}");
            Console.WriteLine("Hvilken kolonne vil du ændre?");
            string column = Console.ReadLine();
            Console.WriteLine("Hvad skal den nye værdi være?");
            string newValue = Console.ReadLine();

            bil.Update(column, newValue);
            Console.WriteLine($"{column} er nu blevet ændret til {newValue}");
        }

        public void SletBil()
        {
            Console.WriteLine("Indtast ID på den bil der skal slettes");
            int id = int.Parse(Console.ReadLine());

            var biler = Select();
            bil = biler.Find(c => c.Id == id);

            Console.WriteLine($"Er du sikker på at du vil slette {bil.Mærke} {bil.Model} fra databasen? (y/n)");
            char svar = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (svar == 'y')
            {
                bil.Delete();
                Console.WriteLine("Bilen blev slettet");
            }
            else
            {
                Console.WriteLine("Bilen blev ikke slettet");
            }
        }

        public void VisBil()
        {
            Console.WriteLine("Indtast ID på den bil du gerne vil se");
            int id = int.Parse(Console.ReadLine());

            var biler = Select();
            bil = biler.Find(c => c.Id == id);

            Console.WriteLine($"{bil.Mærke} {bil.Model} fra {bil.Årgang}\nHar kørt {bil.Km}, registreringsnummer {bil.Registreringsnummer}\n");
        }
    }
}
