using H1ProjektNy.Menuer;
using System;

namespace H1ProjektNy
{
    public class Menu
    {
        public Kunde kunde { get; set; }
        public Bil bil { get; set; }
        public Værkstedsbesøg værkstedsbesøg { get; set; }


        public void Hovedmenu()
        {
            Console.Clear();
            Console.WriteLine("1: Kundeoversigt\n2: Kunder\n3: Biler\n4: Værkstedsbesøg");
            char valg = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (valg)
            {
                case '1':
                    Kundeoversigt();
                    break;
                case '2':
                    Kundemenu kundemenu = new Kundemenu();
                    kundemenu.Menu();
                    break;
                case '3':
                    Bilmenu bilmenu = new Bilmenu();
                    bilmenu.Menu();
                    break;
                case '4':
                    
                    break;
                default:
                    Console.WriteLine("Du bedes indtaste et tal mellem et og fire.");
                    Console.ReadKey();
                    break;
            }
        }
      
        public void Kundeoversigt()
        {
            var kunder = Kunde.Select();

            foreach (var kunde in kunder)
            {
                var biler = Bil.Select();
                var kundebiler = biler.FindAll(c => c.KundeId == kunde.Id);

                Console.WriteLine($"Kunde nr. {kunde.Id}: {kunde.Fornavn} {kunde.Efternavn}\nAdresse: {kunde.Adresse}\nEmail: {kunde.Email}\nOprettelsesdato: {kunde.Oprettelsesdato}\nBiler: ");
                foreach (var bil in kundebiler)
                {
                    Console.WriteLine($"{bil.Mærke} {bil.Model}");
                }
                Console.WriteLine();               
            }
        }        
    }
}
