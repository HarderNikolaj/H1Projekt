using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace H1Projekt
{
    internal class Bil : Databaseforekomst
    {
        public string Regisreringsnummer { get; set; }
        public string Mærke { get; set; }
        public string Model { get; set; }
        public int Årgang { get; set; }
        public DateTime OprettelsesDato { get; set; }
        public int FuelID { get; set; }
        public int Km { get; set; }
        public int KundeID { get; set; }
        public string KundeNavn { get; set; }

        public Bil()
        {

        }

        public Bil(string regnr, string mærke, string model, int årgang, int fuelID, int km, int kundeID)
        {
            KundeID = kundeID;
            Regisreringsnummer = regnr;
            Mærke = mærke;
            Model = model;
            Årgang = årgang;
            FuelID = fuelID;
            List<string> idOgOprettelsesdato = OpretIDatabase(regnr, mærke, model, årgang, fuelID, km, kundeID);
            ID = int.Parse(idOgOprettelsesdato[0]);
            OprettelsesDato = DateTime.Parse(idOgOprettelsesdato[1]);
            KundeNavn = DBConnections.SelectSingleValue("select concat(fornavn,' ',efternavn) from kunde");

        }

        public static List<string> OpretIDatabase(string regnr, string mærke, string model, int årgang, int brændstof, int km, int kundeID)
        {
            var dataBus = new List<string>();
            DBConnections.InsertInto($"Insert into bil (Maerke,Model,Aargang,RegNr,km,FuelID,kundeid) values('{mærke}','{model}',{årgang},'{regnr}',{km},{brændstof},{kundeID})");
            var table = DBConnections.Select("select top 1 id,oprettelsesdato from bil order by id desc");


            foreach (DataRow item in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    dataBus.Add(item[i].ToString());
                }
            }
            //dataBus.Add(table.Rows[0]. ToString());
            return dataBus;
        }

        public override void Udskriv()
        {
            Console.WriteLine($"{Mærke} {Model} {Årgang}\nDatabase ID: {ID}\nEjer: {KundeNavn}\nReg.nr: {Regisreringsnummer}\nBrændstof: {(Brændstofstype)FuelID}");
        }

        public override void Delete()
        {
            //skal slette alle tilhørende værkstedsbesøg først

            DBConnections.Delete(ID, "Bil");
            Console.WriteLine("Bilen blev slettet fra databasen");
            Console.ReadKey();
        }

        public override void Update(Kolonne kolonne, string nyVærdi)
        {
            string query = "";
            switch (kolonne)
            {
                case Kolonne.ID:
                case Kolonne.KundeID:
                case Kolonne.FuelID:
                case Kolonne.Km:
                case Kolonne.Aargang:
                    query = $"Update Bil Set {kolonne} = {nyVærdi} where ID = {ID}";
                    break;
                case Kolonne.Maerke:
                case Kolonne.Model:
                case Kolonne.RegNr:
                case Kolonne.Oprettelsesdato:
                    query = $"Update Bil Set {kolonne} = '{nyVærdi}' where ID = {ID}";
                    break;
                default:
                    break;
            }
            DBConnections.Update(query);
            OpdaterValgtForekomst();
        }

        public override void OpdaterValgtForekomst()
        {
            DataTable table = DBConnections.Select($"select Maerke,Model,RegNr,Aargang,Km,FuelID,KundeID from bil where ID = {ID}");
            foreach (DataRow item in table.Rows)
            {
                Mærke = item[0].ToString();
                Model = item[1].ToString();
                Regisreringsnummer = item[2].ToString();
                Årgang = int.Parse(item[3].ToString());
                Km = int.Parse(item[4].ToString());
                FuelID = int.Parse(item[5].ToString());
                KundeID = int.Parse(item[6].ToString());
                KundeNavn = DBConnections.SelectSingleValue($"select concat(fornavn,' ',efternavn) from kunde where ID = {KundeID}");
            }
        }

        public override void Menu(Bil bil, Værkstedsbesøg værkstedsbesøg, Kunde kunde)
        {
            Console.Clear();
            Console.WriteLine($"Menu vedrørende {KundeNavn}'s {Mærke} {Model} fra {Årgang} (ID {ID})\n\n");
            Console.WriteLine("1: Opdater køretøj\n2: Tilføj værkstedsbesøg\n3: Se liste over bilens værkstedsbesøg\n4: Slet bil fra databasen");

            var svar = Console.ReadKey().KeyChar;
            Console.Clear();
            switch (svar)
            {

                case '1':
                    string tekst = "Indtast ny værdi";
                    Console.WriteLine("Vælg venligst hvilken værdi der skal ændres\n1: KundeID\n2: Registreringsnummer\n3: Kilometertal");
                    svar = Console.ReadKey().KeyChar;
                    Console.Clear();
                    switch (svar)
                    {
                        case '1':
                            int værdi1;
                            Console.WriteLine(tekst);
                            while (!int.TryParse(Console.ReadLine(), out værdi1))
                            {
                                Console.WriteLine("Den indtastede værdi skal være et heltal");
                            }
                            Update(Kolonne.KundeID, værdi1.ToString());
                            break;
                        case '2':
                            string værdi2;
                            Console.WriteLine(tekst);
                            værdi2 = Console.ReadLine();
                            while (værdi2.Length > 7 || værdi2.Length == 0)
                            {
                                Console.WriteLine("Nummerpladen skal være mellem 1 og 7 karakterer lang");
                                værdi2 = Console.ReadLine();
                            }
                            Update(Kolonne.RegNr, værdi2);
                            break;
                        case '3':
                            int værdi3;
                            Console.WriteLine(tekst);
                            while (!int.TryParse(Console.ReadLine(), out værdi3))
                            {
                                Console.WriteLine("Den indtastede værdi skal være et heltal");
                            }
                            Update(Kolonne.Km, værdi3.ToString());
                            break;
                        default:
                            break;
                    }
                    break;
                case '2':
                    break;
                case '3':
                    break;
                case '4':
                    Delete();
                    break;
                default:
                    break;
            }

        }

        public override void UdskrivListe()
        {
            string query = $"select ID from bil";
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


        public void UdskrivListe(int kundeID)
        {
            string query = $"select ID from bil where KundeID = {kundeID}";
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

        public override void Vælg(int id)
        {
            ID = id;
            OpdaterValgtForekomst();
        }

        enum Brændstofstype
        {
            benzin = 1, diesel = 2, hybrid = 3, el = 4
        }
    }
}
