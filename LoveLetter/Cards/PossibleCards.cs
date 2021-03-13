using System;
using System.Collections.Generic;

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
    }
}