using System;
using System.Collections.Generic;
using System.Linq;

namespace LoveLetter.Cards
{
    public static class PossibleCards
    {
        static List<string> names = new List<string>()
        {
            "princess",
            "countess",
            "king",
            "prince",
            "handmaid",
            "baron",
            "priest",
            "guard"
        };
        
        public static bool IsACard(this String str)
        {
            return names.Contains(str);
        }

        public static string GetRandomName()
        {
            var random = new Random();
            var randomNumber = random.Next(names.Count);
            return names.ElementAt(randomNumber);
        }
    }
}