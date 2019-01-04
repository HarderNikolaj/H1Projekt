using System;
using System.Collections.Generic;
using static H1ProjektNy.Bil;

namespace H1ProjektNy.Menuer
{
    class Bilmenu : Menu
    {
        public void Menu()
        {
            char svar = '0';
            bool check;
            do
            {
                check = false;
                Console.Clear();
                Console.WriteLine("1: Opret bil\n2: Opdater bil\n3: Slet bil\n4: Vis bil\n5: Vis værkstedsbesøg\n6: Afslut");
                svar = Console.ReadKey().KeyChar;

                switch (svar)
                {
                    case '1':
                        bil = OpretBil();
                        Console.WriteLine($"Kunde nr {bil.KundeId}s {bil.Mærke} {bil.Model} er blevet oprettet i systemet");
                        break;
                    case '2':
                        OpdaterBil(); //metoden kaldes på instansen af bilmenu, som blev oprettet i menu.. Derfor kan den kaldes på denne måde uden at være statisk
                        break;
                    case '3':
                        SletBil();
                        break;
                    case '4':
                        VisBil();
                        break;
                    case '5':
                        VisVærkstedsbesøg(); 
                        break;
                    case '6': //Tom, så den ikke lander på default og looper.
                        break;
                    default:
                        check = true;
                        Console.SetCursorPosition(0, 5);
                        Console.WriteLine("Forkert. Prøv igen. Ellers vil ingen nogenside elske dig!");
                        Console.ReadKey();
                        break;
                }
            } while (check == true);
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
            try
            {
                Console.WriteLine("Indtast ID på den bil der skal opdateres");
                int id = int.Parse(Console.ReadLine());

                var biler = Select();
                bil = biler.Find(c => c.Id == id);

                Console.WriteLine($"Registreringsnummer: {bil.Registreringsnummer}\nMærke: {bil.Mærke}\nModel: {bil.Model}\nÅrgang: {bil.Årgang}\n" +
                    $"Antal km kørt: {bil.Km}\nBrændstoftype: {bil.brændstof}\nKundeID: {bil.KundeId}");
                Console.WriteLine("Hvilken kolonne vil du ændre?\nMaerke, Model, Aargang, Registreringsnummer, Kilometer, Braendstoftypeid, Kundeid");
                string column = Console.ReadLine();
                Console.WriteLine("Hvad skal den nye værdi være?");
                string newValue = Console.ReadLine();

                bil.Update(column, newValue);
                Console.WriteLine($"{column} er nu blevet ændret til {newValue}");
                Console.ReadKey();
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

        public void SletBil()
        {
            try
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
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Bilen blev ikke slettet");
                    Console.ReadKey();
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

        public void VisBil()
        {
            try
            {
                Console.WriteLine("Indtast ID på den bil du gerne vil se");
                int id = int.Parse(Console.ReadLine());

                var biler = Select();
                bil = biler.Find(c => c.Id == id);

                Console.WriteLine($"{bil.Mærke} {bil.Model} fra {bil.Årgang}\nHar kørt {bil.Km} km, registreringsnummer {bil.Registreringsnummer}\n");
                Console.ReadKey();
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

        public void VisVærkstedsbesøg()
        {
            try
            {

                Console.WriteLine("Indtast ID på den bil, hvis værkstedsbesøg du gerne vil se");
                int id = int.Parse(Console.ReadLine());

                List<Værkstedsbesøg> besøg = Værkstedsbesøg.Select();
                besøg = besøg.FindAll(c => c.BilId == id);

                foreach (var item in besøg)
                {
                    Console.WriteLine("Tid: " + item.Aftaletidspunkt + " Pris: {0:C}", item.Pris);
                }
                    Console.ReadKey();
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
