using System;

namespace HegyekMo
{
    class Hegy
    {
        public string Név { get; set; }
        public string Hegység { get; set; }
        public int Magasság { get; set; }

        public Hegy(string sor)
        {
            string[] sorSplitted = sor.Split(';');
            Név = sorSplitted[0];
            Hegység = sorSplitted[1];
            Magasság = int.Parse(sorSplitted[2]);
        }
    }
}
