using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _1.feladat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //2/3.Feladat
            Console.WriteLine("2 és 3 Feladat");
            List<Rendezveny> rendezveny = new List<Rendezveny>();
            string[] lines = File.ReadAllLines("rendezveny.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                Rendezveny rend_obj = new Rendezveny(values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
                rendezveny.Add(rend_obj);
            }

            //4.Feladat
            Console.WriteLine("4.Feladat");
            foreach (var item in rendezveny)
            {
                Console.WriteLine($"{item.sorszam};{item.nev};{item.helyszin};{item.fo};{item.nap};{item.fopernap}; {item.kedvezmenye}");

            }

            //5.Feladat
            Console.WriteLine("5.Feladat");
            Dictionary<string, int> osszegPerSzemely = new Dictionary<string, int>();

            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                int fopernap = int.Parse(values[5]);
                int nap = int.Parse(values[4]);
                int fo = int.Parse(values[3]);
                int osszeg = fopernap * fo * nap;
                bool kedvezmeny = values[6].ToLower() == "igen";
                string nev = values[1];

                if (osszegPerSzemely.ContainsKey(nev))
                {
                    osszegPerSzemely[nev] += kedvezmeny ? (int)(osszeg * 0.8) : osszeg;
                }
                else
                {
                    osszegPerSzemely.Add(nev, kedvezmeny ? (int)(osszeg * 0.8) : osszeg);
                }
            }


            Console.WriteLine("6.Feladat");
            var rendezettList = osszegPerSzemely.ToList();
            rendezettList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value)); // Változtatás itt

            // Kiírjuk a rendezett listát
            foreach (var pair in rendezettList)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} Ft");
            }

            Console.WriteLine("7.Feladat");
            // Legtöbbet költő személy meghatározása
            string legtobbetKoltoSzemely = "";
            int legtobbetKoltottOsszeg = 0;

            foreach (var pair in osszegPerSzemely)
            {
                if (pair.Value > legtobbetKoltottOsszeg)
                {
                    legtobbetKoltoSzemely = pair.Key;
                    legtobbetKoltottOsszeg = pair.Value;
                }
            }

            // Kiírjuk a legtöbbet költő személyt és az általa költött összeget
            Console.WriteLine($"A legtöbbet költő személy: {legtobbetKoltoSzemely}, összeg: {legtobbetKoltottOsszeg} Ft");

            Console.WriteLine("8.Feladat");
            // Személyek előfordulási számának nyomon követése
            Dictionary<string, int> szemelyElfordulasok = new Dictionary<string, int>();

            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                string nev = values[1];

                if (szemelyElfordulasok.ContainsKey(nev))
                {
                    szemelyElfordulasok[nev]++;
                }
                else
                {
                    szemelyElfordulasok.Add(nev, 1);
                }
            }

            // Azok a személyek, akiknek a neve kétszer szerepelt a listában
            List<string> kettoSzereploNevek = szemelyElfordulasok.Where(pair => pair.Value == 2).Select(pair => pair.Key).ToList();

            // Kiírjuk azoknak a személyeknek a nevét, akiknek a neve kétszer szerepelt a listában
            Console.WriteLine("Azok a személyek, akiknek a neve kétszer szerepelt a listában:");
            foreach (var nev in kettoSzereploNevek)
            {
                Console.WriteLine(nev);
            }


            Console.ReadKey();
            
        }
    }
}
