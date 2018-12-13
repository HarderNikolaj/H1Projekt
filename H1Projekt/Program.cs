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
            Console.Title = "Willys Værksted";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hovedmenu:\n\n1: Gå til kundemenu\n2: Gå til bilmenu\n3: Gå til værkstedsbesøg\n4: Afslut program");
                var svar = Console.ReadKey().KeyChar;
                switch (svar)
                {
                    case '1':
                        KundeMenu();
                        break;
                    case '2':
                        BilMenu();
                        break;
                    case '3':
                        break;
                    case '4':
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }
            }
            
        }
        private static void KundeMenu()
        {
            Console.Clear();
            Console.WriteLine("Kundemenu:\n\n1: Vis kundeoversigt\n2: Vis enkelt kunde\n3: Opret kunde");
            var svar = Console.ReadKey().KeyChar;
            switch (svar)
            {
                case '1':
                    Console.Clear();
                    Console.WriteLine("Kundeoversigt:\n");
                    DBConnection.Select("select * from kunde");
                    Console.WriteLine($"Kunder i alt: {DBConnection.ReturnerAntal("kunde")}");
                    Console.ReadKey();
                    break;
                case '2':
                    //vi skal have en metoder der udskriver alle biler
                    Console.Clear();
                    int id = 0;
                    Console.WriteLine("Indtast kunde ID og afslut med enter");
                    int.TryParse(Console.ReadLine(),out id);
                    Console.WriteLine($"Kunde {id}:\n");
                    Kunde.SelectSingle(id);
                    Console.WriteLine("Kundens biler:\n");
                    Bil.BilListe(id);
                    Console.ReadKey();
                    break;
                case '3':
                    Console.Clear();
                    Console.WriteLine("Indtast venligst fornavn");
                    var fornavn = Console.ReadLine();
                    Console.WriteLine("Indtast venligst efternavn");
                    var efternavn = Console.ReadLine();
                    Console.WriteLine("Indtast venlgist adresse");
                    var adresse = Console.ReadLine();
                    Console.WriteLine("Indtast venlgist e-mail");
                    var email = Console.ReadLine();
                    Kunde.OpretKunde(fornavn,efternavn,adresse,email);
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        }
        private static void BilMenu()
        {
            Console.Clear();
            Console.WriteLine("Bil menu:\n\n1: Vis biloversigt\n2: Vis enkelt bil\n3: Opret bil");
            var svar = Console.ReadKey().KeyChar;
            switch (svar)
            {
                case '1':
                    Console.Clear();
                    Bil.BilListe();
                    Console.WriteLine($"Biler i alt: {DBConnection.ReturnerAntal("bil")}");
                    Console.ReadKey();
                    break;
                case '2':
                    Console.Clear();
                    break;
                case '3':
                    break;
                default:
                    break;
            }
        }
    }
}
