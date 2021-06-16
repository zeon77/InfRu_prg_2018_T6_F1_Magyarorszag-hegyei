using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;

namespace HegyekMo
{
    class Program
    {
        static void Main(string[] args)
        {
            //2. feladat
            List<Hegy> hegyek = new List<Hegy>();
            foreach (var sor in File.ReadAllLines("hegyekMo.txt").Skip(1))
                hegyek.Add(new Hegy(sor));

            //3. feladat
            Console.WriteLine($"3. feladat: Hegycsúcsok száma: {hegyek.Count} db");

            //4. feladat
            Console.WriteLine($"4. feladat: Hegycsúcsok átlagos magassága: {hegyek.Average(x => x.Magasság):0.00} m");

            //5. feladat
            Console.WriteLine($"5. feladat: A legmagasabb hegycsúcs adatai:");
            //int maxMagasság = hegyek.Max(y => y.Magasság);
            //var legmagasabbHegy = hegyek.Single(x => x.Magasság == maxMagasság);
            var legmagasabbHegy = hegyek.OrderBy(x => x.Magasság).Last();
            Console.WriteLine($"\t Név: {legmagasabbHegy.Név}");
            Console.WriteLine($"\t Hegység: {legmagasabbHegy.Hegység}");
            Console.WriteLine($"\t Magasság: {legmagasabbHegy.Magasság} m");

            //6. feladat
            Console.Write($"6. feladat: Kérek egy magasságot: ");
            int magasság = int.Parse(Console.ReadLine());
            Console.WriteLine($"\t{(hegyek.Any(x => x.Magasság > magasság && x.Hegység == "Börzsöny") ? "Van" : "Nincs")} {magasság}m-nél magasabb hegycsúcs a Börzsönyben!");

            //7.
            Console.WriteLine($"7. feladat: 3000 lábnál magasabb hegycsúcsok száma: {hegyek.Where(x => x.MagasságLáb > 3000).Count()}");

            //8. feladat
            Console.WriteLine($"8. feladat: Hegység statisztika");
            hegyek.GroupBy(x => x.Hegység)
                .Select(gr => new { Hegység = gr.Key, Darab = gr.Count() })
                .ToList().ForEach(x => Console.WriteLine($"\t {x.Hegység} - {x.Darab} db"));

            //9. feladat
            Console.WriteLine($"9. feladat: bukk-videk.txt");

            using StreamWriter sw = new StreamWriter("bukk-videk.txt");
            // A decimal separator megváltoztatásához...
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";

            sw.WriteLine("Hegycsúcs neve;Magasság láb");
            hegyek.Where(x => x.Hegység == "Bükk-vidék")
                //.ToList().ForEach(x => sw.WriteLine($"{x.Név};" + $"{(x.MagasságLáb):0.0}".Replace(",", ".").Replace(".0", "")));     //csúnya
                .ToList().ForEach(x => sw.WriteLine($"{x.Név};{(x.MagasságLáb).ToString("0.#", nfi)}"));
        }
    }
}
