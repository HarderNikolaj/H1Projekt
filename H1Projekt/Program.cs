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
            var valgtBil = new Bil();
            var valgtKunde = new Kunde();
            var valgtVærkstedsbesøg = new Værkstedsbesøg();


            valgtVærkstedsbesøg.ID = 1;
            valgtVærkstedsbesøg.UdskrivListe();
        //    char svar = default(char);
        //    Console.Title = "Willys Værksted";
        //    while (svar != '5')
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Willys Værksted:\n\n1: Vælg kunde fra liste\n2: Vælg bil fra liste\n3: Vælg værkstedsbesøg fra liste\n4: Opret ny kunde\n5: Afslut program");
        //        svar = Console.ReadKey().KeyChar;

        //        switch (svar)
        //        {
        //            case '1':
        //                valgtKunde.UdskrivListe();
        //                Console.Write("Indtast ID på den ønskede kunde: ");
        //                int valg1 = default(int);
        //                while (!int.TryParse(Console.ReadLine(), out valg1))
        //                {
        //                    Console.WriteLine("Du skal indtaste et heltal");
        //                }
        //                Console.Clear();
        //                valgtKunde.Vælg(valg1);
        //                valgtKunde.Menu(valgtBil, valgtVærkstedsbesøg, valgtKunde);
        //                break;
        //            case '2':
        //                valgtBil.UdskrivListe();
        //                Console.Write("Indtast ID på den ønskede bil: ");
        //                int valg2 = default(int);
        //                while (!int.TryParse(Console.ReadLine(), out valg2))
        //                {
        //                    Console.WriteLine("Du skal indtaste et heltal");
        //                }
        //                Console.Clear();
        //                valgtBil.Vælg(valg2);
        //                Console.WriteLine("Valgt bil:");
        //                valgtBil.Menu(valgtBil, valgtVærkstedsbesøg, valgtKunde);
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        }

    }
}
