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
                        VaerkstedsMenu();
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
                    int id = 0;
                    Console.WriteLine("Indtast bil ID og afslut med enter");
                    int.TryParse(Console.ReadLine(), out id);
                    Console.Clear();
                    Bil.BilEnkelt(id);
                    Console.ReadKey();
                    break;
                case '3':
                    Console.Clear();
                    Console.WriteLine("Indtast venligst ejerens kunde ID");
                    var kundeId = int.Parse(Console.ReadLine());
                    while (!Kunde.KontrollerOmKundeFindes(kundeId))
                    {
                        Console.Clear();
                        Console.WriteLine("Den kunde kunne ikke findes i vores database.\nPrøv igen.");
                        kundeId = int.Parse(Console.ReadLine());
                    }

                    string registreringsnummer;
                    do
                    {
                        Console.WriteLine("Indtast venligst bilens registreringsnummer");
                        registreringsnummer = Console.ReadLine();
                    } while (registreringsnummer.Length>7);

                    Console.WriteLine("Indtast venligst bilens mærke");
                    var maerke = Console.ReadLine();
                    Console.WriteLine("Indtast venligst bilens model");
                    var model = Console.ReadLine();
                    Console.WriteLine("Indtast venligst bilens årgang");
                    int årgang;
                    while (!int.TryParse(Console.ReadLine(),out årgang))
                    {
                        Console.WriteLine("Du har tastet forkert, prøv igen.");
                    }
                    int km;
                    Console.WriteLine("Indtast venligst bilens kilometertal");
                    while (!int.TryParse(Console.ReadLine(), out km))
                    {
                        Console.WriteLine("Du har tastet forkert, prøv igen.");
                    }
                    Console.WriteLine("Indtast venligst bilens brændstofstype\n\n1: Benzin\n2: El\n3: Diesel\n4: Hybrid\n");

                    int braendstofId;
                    {
                        while (!int.TryParse(Console.ReadLine(), out braendstofId))
                        {
                            Console.WriteLine("Du skal indtaste et heltal, prøv igen.");
                        }

                        while (!Braendstoftype.KontrollerOmBraendstofFindes(braendstofId))
                        {
                            Console.Clear();
                            Console.WriteLine("Den brændstofstype kunne ikke findes i vores database.\nPrøv igen.");
                            while (!int.TryParse(Console.ReadLine(), out braendstofId))
                            {
                                Console.WriteLine("Du skal indtaste et heltal, prøv igen.");
                            }
                        }
                    }
                    var nybil = new Bil(maerke,model,årgang,registreringsnummer,km,braendstofId,kundeId);
                    break;
                default:
                    break;
            }
        }
        private static void VaerkstedsMenu()
        {
            Console.Clear();
            Console.WriteLine("Willys værkstedsmenu:\n\n1: Opret værkstedbesøg\n2: Vis enkelt værkstedsbesøg\n3: Vis bils værkstedsbesøg\n4: Vis fremtidige værkstedsbesøg\n5: Vis alle værkstedsbesøg.");
            var svar = Console.ReadKey().KeyChar;
            switch (svar)
            {
                case '1':
                    Console.Clear();
                    Console.WriteLine("Indtast dato og tidspunkt for kundens værkstedsbesøg (yyyy-MM-dd HH:mm)");
                    var aftaletidspunkt = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Indtast bil-ID for den bil som skal på værkstedsbesøg");
                    var bilId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Indtast prisen for besøget");
                    var pris = decimal.Parse(Console.ReadLine());
                    var aftale = new Vaerkstedsbesoeg(aftaletidspunkt,bilId,pris);
                    Console.ReadKey();
                    break;
                case '2':
                    Console.Clear();
                    int id = 0;
                    Console.WriteLine("Indtast Værstedsbesøg ID og afslut med enter");
                    int.TryParse(Console.ReadLine(), out id);
                    Console.Clear();
                    Vaerkstedsbesoeg.VaerkstedsbesoegEnkelt(id);
                    Console.ReadKey();
                    break;
                case '3':
                    Console.Clear();
                    id = 0;
                    Console.WriteLine("Indtast bil ID og afslut med enter");
                    int.TryParse(Console.ReadLine(), out id);
                    Console.Clear();
                    Console.WriteLine($"Bil {id}:\n");
                    Vaerkstedsbesoeg.VaerkstedsbesoegListe(id);
                    Console.ReadKey();                 
                    break;
                case '4':
                    Console.Clear();
                    Console.WriteLine("Fremdtidige værkstedsbesøg:\n\n");
                    Vaerkstedsbesoeg.SelectFremtidigeVaerkestedbesoeg();
                    Console.ReadKey();
                    break;
                case '5':
                    Console.Clear();
                    Console.WriteLine("Alle værkstedsbesøg\n\n");
                    Vaerkstedsbesoeg.VaerkstedsbesoegListe();
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        }
    }
}
