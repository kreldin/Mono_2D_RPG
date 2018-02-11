using System;

namespace RpgLibrary
{
    public enum DieType { D4 = 4, D6 = 6, D8 = 8, D10 = 10, D12 = 12, D20 = 20, D100 = 100}

    public static class Mechanics
    {
        private static readonly Random Random = new Random();

        public static int RollDie(DieType die)
        {
            return Random.Next(0, (int) die) + 1;
        }
    }
}
