using lotto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Lotto> sorsolasok = Lotto.Beolvas("C:/Users/marti/OneDrive/Asztali gép/lotto/sorsolas.txt");

            int hetSzam;

            do
            {
                Console.Write("Adj meg egy 1-52-ig terjedő számot: ");
            } while (!int.TryParse(Console.ReadLine(), out hetSzam) || hetSzam < 1 || hetSzam > 52);

            Lotto keresettSorsolas = sorsolasok.FirstOrDefault(s => s.Het == hetSzam);
            if (keresettSorsolas != null)
            {
                Console.WriteLine($"A(z) {hetSzam}. hét nyerőszámai: {string.Join(", ", keresettSorsolas.NyeroSzamok)}");
            }

            int legkevesebbszerHuzottSzam = sorsolasok.SelectMany(s => s.NyeroSzamok).GroupBy(szam => szam)
                                                           .OrderBy(group => group.Count())
                                                           .First().Key;
            Console.WriteLine($"A legkevesebbszer húzott szám az évben: {legkevesebbszerHuzottSzam}");

            int parosSzamokSzama = sorsolasok.SelectMany(s => s.NyeroSzamok).Count(szam => szam % 2 == 0);
            Console.WriteLine($"Az évben összesen {parosSzamokSzama} páros számot húztak ki.");

            int otosSzamHuzasokSzama = sorsolasok.Count(s => s.NyeroSzamok.Contains(5));
            Console.WriteLine($"Az évben összesen {otosSzamHuzasokSzama} alkalommal húzták ki az 5-ös számot.");

            int negyvenhatosSzamHuzasokSzama = sorsolasok.Count(s => s.NyeroSzamok.Contains(46));
            Console.WriteLine($"Az évben összesen {negyvenhatosSzamHuzasokSzama} alkalommal húzták ki a 46-os számot.");

            for (int szam = 1; szam <= 90; szam++)
            {
                int huzasokSzama = sorsolasok.SelectMany(s => s.NyeroSzamok).Count(nyeroSzam => nyeroSzam == szam);
                Console.WriteLine($"{szam}: {huzasokSzama} alkalommal húzták ki");
            }

            Console.ReadLine();
        }

    }
}

