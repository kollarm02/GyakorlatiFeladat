using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public class Book
    {
       
        
            public int sorszam;
            public string kategoria;
            public string cim;
            public int ar;
            public int darab;

            public Book(string sorszam, string kategoria, string cim, string ar, string darab)
            {
                this.sorszam = int.Parse(sorszam);
                this.kategoria = kategoria;
                this.cim = cim;
                this.ar = int.Parse(ar);
                this.darab = int.Parse(darab);
            }
        }
    }

