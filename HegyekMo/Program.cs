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
        }
    }
}
