using System;
using System.Linq;
using LoveLetter.Cards;

namespace LoveLetter.Players
{
    public class Human : Player
    {
        public override void TakeCard(Card card)
        {
            base.TakeCard(card);
            Console.WriteLine("You took a " + card.Name);
        }

        public override void PlayTurn()
        {
            PrintHand();
            Card playCard = null;
            while (playCard == null)
            {
                Console.WriteLine("Please pick a card to play: ");
                var cardChoice = Console.ReadLine()?.ToLower();
                playCard = hand.First(card => card.Name.ToLower().Equals(cardChoice));
            }
            Discard(playCard);
        }

        private void Discard(Card card)
        {
            hand.Remove(card);
        }
    }
}