using System;
using System.Linq;
using LoveLetter.Cards;

namespace LoveLetter.Players
{
    public class Human : Player
    {
        public Human(int number) : base(number)
        {
        }
        
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
                Console.Write("Please pick a card to play: ");
                var cardChoice = Console.ReadLine()?.ToLower();
                playCard = Hand.First(card => card.Name.ToLower().Equals(cardChoice));
            }
            Play(playCard);
        }
    }
}