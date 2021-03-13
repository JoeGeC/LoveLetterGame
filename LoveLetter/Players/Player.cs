using System.Collections.Generic;
using LoveLetter.Cards;

namespace LoveLetter.Players
{
    public abstract class Player
    {
        protected readonly List<Card> hand = new List<Card>();

        public virtual void TakeCard(Card card)
        {
            hand.Add(card);
        }

        protected void PrintHand()
        {
            hand.ForEach(card => card.Print());
        }

        public abstract void PlayTurn();
    }
}