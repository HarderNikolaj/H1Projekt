using System;

namespace H1ProjektNy.Menuer
{
    class Værkstedsmenu : Menu
    {
        public void Menu()
        {
            bool check;
            char svar;
            do
            {
                check = false;
                Console.WriteLine("1: Opret værkstedsbesøg\n2: Opdater værkstedsbesøg\n3: Slet værkstedsbesøg\n4: Afslut");
                svar = Console.ReadKey().KeyChar;
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
                    case '4':
                        break;
                    default:
                        check = true;
                        Console.WriteLine("Forkert input. Prøv igen.");
                        Console.ReadKey();
                        break;
                }

            } while (check == true);
        }

        public Værkstedsbesøg OpretVærkstedsbesøg()
        {
            try
            {
            Console.WriteLine("Indtast venligst Aftaletidspunkt (yyyy-mm-dd hh:mm)");
            DateTime tidspunkt = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Indtast venligst BilID");
            int bilid = int.Parse(Console.ReadLine());
            Console.WriteLine("Indtast venligst pris");
            decimal pris = decimal.Parse(Console.ReadLine());

            værkstedsbesøg = new Værkstedsbesøg(tidspunkt, bilid, pris);
            værkstedsbesøg.Insert();
            }
            catch (FormatException)
            {
                Console.WriteLine("Data er blevet indtastet i et forkert format. Prøv igen.");
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Det var en upser! Smut pomfrit");
                Console.ReadKey();
            }

            return værkstedsbesøg;
        }

        public void OpdaterVærkstedsbesøg()
        {
            try
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
            catch (FormatException)
            {
                Console.WriteLine("Forkert input. Tryk på en vilkårlig tast for at vende tilbage til hovedmenuen.");
                Console.ReadKey();

            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Det valgte ID eksisterer ikke");
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Det var en upser! Smut pomfrit");
                Console.ReadKey();
            }
        }

        public void SletVærkstedsbesøg()
        {
            try
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
            catch (FormatException)
            {
                Console.WriteLine("Forkert input. Tryk på en vilkårlig tast for at vende tilbage til hovedmenuen.");
                Console.ReadKey();

            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Det valgte ID eksisterer ikke");
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Det var en upser! Smut pomfrit");
                Console.ReadKey();
            }
        }
    }
}
