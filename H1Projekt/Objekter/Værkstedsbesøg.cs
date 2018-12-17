using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace H1Projekt
{

    class Værkstedsbesøg : Databaseforekomst
    {
        private static readonly double Moms = 0.25;
        public DateTime Aftaletidspunkt { get; set; }
        public int BilID { get; set; }
        public double Pris { get; set; }

        public override void Delete()
        {
            DBConnections.Delete(ID, "Vaerkstedsbesoeg");
        }

        public override void Menu(Bil bil, Værkstedsbesøg værkstedsbesøg, Kunde kunde)
        {
            throw new NotImplementedException();
        }

        public override void OpdaterValgtForekomst()
        {
            DataTable table = DBConnections.Select($"Select {Kolonne.Aftaletidspunkt},{Kolonne.BilID},{Kolonne.Pris} from kunde where ID = {ID}");
            foreach (DataRow item in table.Rows)
            {
                Aftaletidspunkt= DateTime.Parse(item[0].ToString());
                BilID = int.Parse(item[1].ToString());
                Pris = double.Parse(item[2].ToString());
            }
        }

        public override void Udskriv()
        {
            string query = $"select concat({Kolonne.Fornavn},' ',{Kolonne.Efternavn})  as navn, concat({Kolonne.Maerke},' ',{Kolonne.Model},' ',{Kolonne.Aargang}) as bil from bil inner join kunde on bil.kundeid = kunde.id inner join vaerkstedsbesoeg on bil.id = vaerkstedsbesoeg.bilid where vaerkstedsbesoeg.id = {ID}";
            DataTable table = DBConnections.Select(query);

            foreach (DataRow item in table.Rows)
            {
                Console.WriteLine("Værkstedsbesøg: "+ID);
                Console.WriteLine("Ejer: "+item[0]);
                Console.WriteLine("Bil: "+item[1]);
                Console.WriteLine("Tidspunkt: "+Aftaletidspunkt);
                Console.WriteLine("Pris inklusiv moms: {0:c}",TilføjMoms(Pris));
            }
        }

        public override void UdskrivListe()
        {
            string query = $"select vaerkstedsbesoeg.id, concat({Kolonne.Fornavn},' ',{Kolonne.Efternavn})  as navn, concat({Kolonne.Maerke},' ',{Kolonne.Model},' ',{Kolonne.Aargang}) as bil from bil inner join kunde on bil.kundeid = kunde.id inner join vaerkstedsbesoeg on bil.id = vaerkstedsbesoeg.bilid";
            DataTable table = DBConnections.Select(query);

            foreach (DataRow item in table.Rows)
            {
                Vælg(ID); //det burde vist virke når vælg bliver implementeret, tror jeg nok :)
                Console.WriteLine("Værkstedsbesøg: " + ID);
                Console.WriteLine("Ejer: " + item[1]);
                Console.WriteLine("Bil: " + item[2]);
                Console.WriteLine("Tidspunkt: " + Aftaletidspunkt);
                Console.WriteLine("Pris inklusiv moms: {0:c}", TilføjMoms(Pris));
            }
        }

        public override void Update(Kolonne kolonne, string nyVærdi)
        {
            throw new NotImplementedException();
        }

        public override void Vælg(int id)
        {
            throw new NotImplementedException();
        }

        private double TilføjMoms(double pris)
        {
            return pris + pris * Moms;

        }
    }
}
