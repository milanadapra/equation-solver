using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WolframAlphaNETClient
{
    public class Rezultati
    {
        public string rezultat;
        public string Rezultat
        {
            get
            {
                return rezultat;
            }
            set 
            {
                rezultat = value;
            }
        }

        public string pitanje = "x^3-2*x^2=14";
        public string Pitanje
        {
            get
            {
                return pitanje;
            }
            set
            {
                pitanje = value;
            }
        }
    }
}
