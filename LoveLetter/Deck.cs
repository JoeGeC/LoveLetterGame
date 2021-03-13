using System.Collections.Generic;
using LoveLetter.Cards;

namespace LoveLetter
{
    public class Deck
    {
        List<Card> deck = new List<Card>()
        {
            new Princess(),
            new Countess(),
            new King(),
            new Prince(),
            new Prince(),
            new Handmaid(),
            new Handmaid(),
            new Baron(),
            new Baron(),
            new Priest(),
            new Priest(),
            new Guard(),
            new Guard(),
            new Guard(),
            new Guard(),
            new Guard()
        };
    }
}