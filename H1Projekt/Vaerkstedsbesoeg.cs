using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace H1Projekt
{
    public class Vaerkstedsbesoeg
    {
        public int ID { get; set; }
        public DateTime Aftaletidspunkt { get; set; }
        public int BilID { get; set; }
        public decimal Pris { get; set; }

        public Vaerkstedsbesoeg(DateTime aftaletidspunkt, int bilId, decimal pris)
        {
            Aftaletidspunkt = aftaletidspunkt;
            BilID = bilId;
            Pris = pris;
            OpretVaerkstedsbesoeg(aftaletidspunkt, bilId, pris);
        }

        private static void OpretVaerkstedsbesoeg(DateTime aftaletidspunkt, int bilId, decimal pris)
        {
            try
            {
                //Af uransagelige årsager resulterer tostring("yyyy-MM-dd HH:mm") i resultatet "yyyy-MM-dd HH.mm". Vi erstatter derfor ''.' med ':' for at ms sql skal kunne læse det
                string tidspunkt = aftaletidspunkt.ToString("yyyy-MM-dd HH:mm").Replace('.', ':');
                var query = $"insert into vaerkstedsbesoeg (Aftaletidspunkt,BilID,Pris) values('{tidspunkt}',{bilId},{pris})";
                DBConnection.Insert(query);
            }
            catch (Exception)
            {
                Console.WriteLine("Hov, der er sket en fejl. Værkstedsbesøget blev ikke oprettet");
            }
        }
    }
}
