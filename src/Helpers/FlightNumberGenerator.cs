using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Helpers
{
    public static class FlightNumberGenerator
    {
        private static readonly string[] AirlineCodes = { "GD", "AY" };
        private static readonly Random random = new();

        public static string GenerateFlightNumber()
        {
            string code = AirlineCodes[random.Next(AirlineCodes.Length)];
            int number = random.Next(100, 9999); // 3-4 haneli sayı
            return $"{code}{number}";
        }
    }
}