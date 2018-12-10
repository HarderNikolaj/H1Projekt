using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Projekt
{
    public class Vaerkstedsbesoeg
    {
        public int ID { get; set; }
        public DateTime Aftaletidspunkt { get; set; }
        public int BilID { get; set; }
        public decimal Pris { get; set; }
    }
}
