using HangManBL.Interfaces;
using System;

namespace HangManBL
{
    public class RandomUtils : IRandomUtils
    {
        private readonly Random _rnd = new Random(); //jei turime likusiu zodziu, generuojame  atsitiktini

        public int Random(int min, int max)
        {
            return _rnd.Next(min, max);
        }
    }
}
