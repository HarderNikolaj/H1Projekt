using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Projekt
{
    public class Braendstoftype
    {
        public int ID { get; set; }
        public string Type { get; set; }


        public static bool KontrollerOmBraendstofFindes(int braendstofId)
        {
            return DBConnection.CheckForEksistens(braendstofId, "Braendstoftype");
        }
    }
}
