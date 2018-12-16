using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Projekt
{
    abstract class Databaseforekomst
    {
        public int ID { get; set; }

        public abstract void Menu(Bil bil, Værkstedsbesøg værkstedsbesøg, Kunde kunde);

        public abstract void Vælg(int id);

        public abstract void Udskriv();

        public abstract void UdskrivListe();

        public abstract void Delete();

        public abstract void Update(Kolonne kolonne, string nyVærdi);

        public abstract void OpdaterValgtForekomst();

        public enum Kolonne
        {
            ID, Oprettelsesdato, Maerke, Model, Aargang, RegNr, Km, FuelID, KundeID, Fornavn, Efternavn, Adresse, Email, Aftaletidspunkt, BilID, Pris
        }
        public enum Brændstof
        {
            benzin = 1, diesel = 2, hybrid = 3, el = 4
        }

    }
}
