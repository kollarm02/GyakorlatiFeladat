using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonyvesBolt
{
    public class Books
    {
        
        public int sorszam;
        public string kategoria;
        public string cim;
        public int ar;
        public int darab;

        public Books(string sorszam, string kategoria, string cim, string ar, string darab)
        {
            this.sorszam = int.Parse(sorszam);
            this.kategoria = kategoria;
            this.cim = cim;
            this.ar = int.Parse(ar);
            this.darab = int.Parse(darab);
        }

    }
}
