using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Projekt
{
    public class Kunde
    {
        public int ID { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }
        public DateTime Oprettelsesdato { get; private set; }


    }
}
