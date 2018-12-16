using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Projekt
{
    class Kunde : Databaseforekomst
    {
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }

        public Kunde()
        {

        }
        public Kunde(int id, string fornavn, string efternavn, string adresse, string email)
        {
            ID = id;
            Fornavn = fornavn;
            Efternavn = efternavn;
            Adresse = adresse;
            Email = email;
        }

        public override void Delete()
        {
            //skal slette alle tilhørende biler først
            DBConnections.Delete(ID, "Kunde");
        }

        public static void OpretForekomstIDatabasen(string fornavn, string efternavn, string adresse, string email)
        {
            string query = $"Insert into Kunde (fornavn,efternavn,adresse,email) values ('{fornavn}','{efternavn}','{adresse}','{email}')";
            DBConnections.InsertInto(query);
        }

        public override void Menu(Bil bil, Værkstedsbesøg værkstedsbesøg, Kunde kunde)
        {
            Console.WriteLine($"Menu vedrørende {Fornavn} {Efternavn} (ID {ID})\n\n");
            Console.WriteLine("1: Opdater Kunde\n2: Tilføj bil\n3: Vis liste over biler\n4: Slet kunde");
            char valg = Console.ReadKey().KeyChar;
            switch (valg)
            {
                case '1':
                    Console.Clear();
                    Console.WriteLine("Vælg hvilken kolonne der skal opdateres:\n1: Fornavn\n2: Efternavn\n3: Adresse\n4: Email");
                    valg = Console.ReadKey().KeyChar;
                    Console.WriteLine("Indtast den nye værdi");
                    string værdi = Console.ReadLine();
                    switch (valg)
                    {
                        case '1':
                            Update(Kolonne.Fornavn, værdi);
                            break;
                        case '2':
                            Update(Kolonne.Efternavn, værdi);
                            break;
                        case '3':
                            Update(Kolonne.Adresse, værdi);
                            break;
                        case '4':
                            Update(Kolonne.Email, værdi);
                            break;
                        default:
                            break;
                    }
                    break;
                case '2':
                    Console.WriteLine("Indtast venligst bilens registreringsnummer");
                    string regnr = Console.ReadLine();
                    Console.WriteLine("Indtast venligst bilens mærke");
                    string mærke = Console.ReadLine();
                    Console.WriteLine("Indtast venligst bilens model");
                    string model = Console.ReadLine();
                    Console.WriteLine("Indtast venligst bilens årgang");
                    int årgang;
                    while (!int.TryParse(Console.ReadLine(), out årgang))
                    {
                        Console.WriteLine("Du skal indtaste et heltal");
                    }
                    Console.WriteLine("Indtast venligst bilens kilometertal");
                    int km;
                    while (!int.TryParse(Console.ReadLine(), out km))
                    {
                        Console.WriteLine("Du skal indtaste et heltal");
                    }
                    int fuelID;
                    Console.WriteLine("Indtast venligst bilens brændstofstype (benzin = 1, diesel = 2, hybrid = 3, el = 4)");
                    while (!int.TryParse(Console.ReadLine(), out fuelID))
                    {
                        Console.WriteLine("Du skal indtaste et heltal");
                    }
                    List<string> liste = Bil.OpretIDatabase(regnr, mærke, model, årgang, fuelID, km, ID);
                    Console.WriteLine($"Bilen blev oprettet med ID {liste[1]}");
                    break;
                    case '3':
                    Console.Clear();
                    bil.UdskrivListe(ID);
                    Console.ReadKey();
                    break;
                default:
                    break;
            }

        }

        public override void OpdaterValgtForekomst()
        {
            DataTable table = DBConnections.Select($"Select {Kolonne.Fornavn},{Kolonne.Efternavn},{Kolonne.Adresse},{Kolonne.Email} from kunde where ID = {ID}");
            foreach (DataRow item in table.Rows)
            {
                Fornavn = item[0].ToString();
                Efternavn = item[1].ToString();
                Adresse = item[2].ToString();
                Email = item[3].ToString();
            }
        }

        public override void Udskriv()
        {
            Console.WriteLine($"{Efternavn}, {Fornavn}\n{Adresse}\n{Email}\nKunde ID: {ID}");
        }

        public override void UdskrivListe()
        {
            string query = $"select ID from kunde";
            DataTable table = DBConnections.Select(query);
            Console.Clear();
            foreach (DataRow item in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    Vælg(int.Parse(item[i].ToString()));
                    Udskriv();
                    Console.WriteLine("");
                }
            }
        }

        public override void Update(Kolonne kolonne, string nyVærdi)
        {
            string query = $"Update Kunde set {kolonne} = '{nyVærdi}' where ID = {ID}";
            DBConnections.Update(query);
        }

        public override void Vælg(int id)
        {
            ID = id;
            OpdaterValgtForekomst();
        }
    }
}
