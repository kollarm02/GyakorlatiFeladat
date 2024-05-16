using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza
{
    internal class Pizza
    {
        public int sorszam;
        public string nev;
        public string pizza;
        public int ar;
        public string csaladi;
        public int db;

        public Pizza(string sorszam, string nev, string pizza, string ar, string csaladi, string db)
        {
            this.sorszam =int.Parse(sorszam);
            this.nev = nev;
            this.pizza = pizza;
            this.ar = int.Parse(ar);
            this.csaladi = csaladi;
            this.db = int.Parse(db);
        }
    }
}
