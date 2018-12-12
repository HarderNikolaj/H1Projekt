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
            //var kunde = new Kunde("Anna", "Mørkeberg", "Sverige", "nikolajerflot@hotmail.dk");
            //var bil = new Bil("Chevrolet", "Spark", 2010, "CW38646", 120000, 1, 3);
            //Console.WriteLine(bil.ID);
            //var besog = new Vaerkstedsbesoeg(DateTime.Now, 2, 2000); 
            DBConnection.Select("select * from bil");

            
        }
    }
}
