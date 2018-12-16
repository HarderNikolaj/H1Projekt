using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            var bil = new Bil();
            var kunde = new Kunde();
            var værkstedsbesøg = new Værkstedsbesøg();
            //Kunde.OpretForekomstIDatabasen("Jesus", "of Nazareth", "On the Cross", "savior@holymail.com");
            //kunde.Vælg(4);
            //kunde.Udskriv();
            //Console.ReadKey();

            //kunde.UdskrivListe();
            char svar = default(char);
            Console.Title = "Willys Værksted";
            while (svar != '5')
            {
                Console.Clear();
                Console.WriteLine("Willys Værksted:\n\n1: Vælg kunde fra liste\n2: Vælg bil fra liste\n3: Vælg værkstedsbesøg fra liste\n4: Opret ny kunde\n5: Afslut program");
                svar = Console.ReadKey().KeyChar;

                switch (svar)
                {
                    case '1':
                        kunde.UdskrivListe();
                        Console.Write("Indtast ID på den ønskede kunde: ");
                        int valg1 = default(int);
                        while (!int.TryParse(Console.ReadLine(), out valg1))
                        {
                            Console.WriteLine("Du skal indtaste et heltal");
                        }
                        Console.Clear();
                        kunde.Vælg(valg1);
                        kunde.Menu(bil, værkstedsbesøg, kunde);
                        break;
                    case '2':
                        bil.UdskrivListe();
                        Console.Write("Indtast ID på den ønskede bil: ");
                        int valg2 = default(int);
                        while (!int.TryParse(Console.ReadLine(), out valg2))
                        {
                            Console.WriteLine("Du skal indtaste et heltal");
                        }
                        Console.Clear();
                        bil.Vælg(valg2);
                        Console.WriteLine("Valgt bil:");
                        bil.Menu(bil, værkstedsbesøg, kunde);
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
