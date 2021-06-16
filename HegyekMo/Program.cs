using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

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

        }
    }
}
