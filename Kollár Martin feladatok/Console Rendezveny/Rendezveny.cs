using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.feladat
{
    internal class Rendezveny
    {
        public int sorszam;
        public string nev;
        public string helyszin;
        public int fo;
        public int nap;
        public int fopernap;
        public string kedvezmenye;

        public Rendezveny(string sorszam, string nev, string helyszin, string fo, string nap, string fopernap, string kedvezmenye)
        {
            this.sorszam = int.Parse(sorszam);
            this.nev = nev;
            this.helyszin = helyszin;
            this.fo = int.Parse(fo);
            this.nap = int.Parse(nap);
            this.fopernap = int.Parse(fopernap);
            this.kedvezmenye = kedvezmenye;
        }
    }
}
