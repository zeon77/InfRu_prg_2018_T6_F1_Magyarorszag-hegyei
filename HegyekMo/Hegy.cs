using System;

namespace HegyekMo
{
    class Hegy
    {
        private const double MetersToFeet = 3.280839895;

        public string Név { get; set; }
        public string Hegység { get; set; }
        public int Magasság { get; set; }
        public double MagasságLáb { get => Magasság * MetersToFeet; }

        public Hegy(string sor)
        {
            string[] sorSplitted = sor.Split(';');
            Név = sorSplitted[0];
            Hegység = sorSplitted[1];
            Magasság = int.Parse(sorSplitted[2]);
        }
    }
}
