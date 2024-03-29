using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lotto
{
    public class Lotto
    {
        public int Het { get; }
        public List<int> NyeroSzamok { get; }

        public Lotto(int het, List<int> nyeroSzamok)
        {
            this.Het = het;
            this.NyeroSzamok = nyeroSzamok;

        }

        public static List<Lotto> Beolvas(string filename)
        {
            List<Lotto> sorsolasok = new List<Lotto>();
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string sor;
                    while ((sor = sr.ReadLine()) != null)
                    {
                        string[] adatok = sor.Split(';');
                        int het = int.Parse(adatok[0]);
                        List<int> nyeroSzamok = adatok.Skip(1).Select(int.Parse).ToList();
                        sorsolasok.Add(new Lotto(het, nyeroSzamok));
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Hiba történt a fájl olvasása közben!");
            }
            return sorsolasok;

        }
    }
}

