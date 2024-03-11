using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonyvesBolt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Books> konyvlista = new List<Books>();
            string[] sor = File.ReadAllLines("books.txt");
            foreach (var item in sor)
            {
                string[] adatok = item.Split(',');
                Books books_object = new Books(adatok[0], adatok[1], adatok[2], adatok[3], adatok[4]);
                konyvlista.Add(books_object);
            }

            Console.WriteLine("4. Feladat");
            foreach (var item in konyvlista)
            {
                Console.WriteLine($"{item.sorszam} {item.kategoria} {item.cim} {item.ar} {item.darab}");
            }
            Console.WriteLine("5. Feladat");
            
            int osszdb = 0;
            foreach (var item in konyvlista)
            {

                osszdb += item.darab;


            }
            Console.WriteLine($"Az össz darabszám: {osszdb} db");

            Console.WriteLine("6. Feladat");
            foreach (var book in konyvlista)
            {
                if (book.kategoria.Equals("Regény"))
                {

                    Console.WriteLine($"A regény kategóriában lévő könyv címe és ára: {book.kategoria},  {book.cim}, {book.ar} ");
                }
            }

            Console.WriteLine("7. Feladat");
            Dictionary<string, int> kategoriak = new Dictionary<string, int>();

            foreach (var item in konyvlista)
            {
                if (kategoriak.ContainsKey(item.kategoria))
                {
                    kategoriak[item.kategoria]++;
                }
                else
                {
                    kategoriak[item.kategoria] = 1;
                }
            }

            Console.WriteLine("\nKategóriák és termékek száma:");
            foreach (var kvp in kategoriak)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} termék");
            }



            Console.WriteLine("8. Feladat");
            List<Books> legolcsobbak = new List<Books>(); 
            Books legolcsobb = konyvlista[0];
            legolcsobbak.Add(legolcsobb); 

            foreach (var termek in konyvlista)
            {
                if (termek.ar < legolcsobb.ar)
                {
                    legolcsobb = termek;
                    legolcsobbak.Clear(); 
                    legolcsobbak.Add(legolcsobb);
                }
                else if (termek.ar == legolcsobb.ar)
                {
                    legolcsobbak.Add(termek);
                }
            }

            Console.WriteLine("\nLegolcsóbb termek(ek) adatai:");
            foreach (var legolcsobbTermek in legolcsobbak)
            {
                Console.WriteLine($"Kategória: {legolcsobbTermek.kategoria}, {legolcsobbTermek.cim}, Ár: {legolcsobbTermek.ar}");
            }


            Console.ReadKey();
        }
    }
}
