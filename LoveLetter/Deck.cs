using System;
using System.Collections.Generic;
using System.Linq;
using LoveLetter.Cards;

namespace LoveLetter
{
    public class Deck
    {
        private List<Card> deck;

        public Deck(IDealListener dealListener)
        {
            NewDeck(dealListener);
        }

        public void NewDeck(IDealListener dealListener)
        {
            deck = new List<Card>()
            {
                new Princess(),
                new Countess(),
                new King(),
                new Prince(dealListener),
                new Prince(dealListener),
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

        public void Shuffle()
        {
            var random = new Random();
            deck = deck.OrderBy(a => random.Next()).ToList();
            Console.WriteLine("Deck shuffled.");
        }

        public Card TakeTopCard()
        {
            var topCard = deck.ElementAt(0);
            deck.RemoveAt(0);
            return topCard;
        }

        public bool IsEmpty()
        {
            return deck.Count == 0;
        }
    }
}