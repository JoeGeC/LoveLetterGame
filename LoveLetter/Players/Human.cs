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

        public override void PlayTurn()
        {
            PrintHand();
            Card playCard = null;
            while (playCard == null)
            {
                Console.Write("Please pick a card to play: ");
                var cardChoice = ChooseCard();
                playCard = Hand.First(card => card.Name.ToLower().Equals(cardChoice));
            }
            Play(playCard);
        }

        public override int ChoosePlayer()
        {
            var input = Console.ReadLine();
            int.TryParse(input, out var inputAsInt);
            return inputAsInt;
        }

        public override string ChooseCard()
        {
            return Console.ReadLine()?.ToLower();
        }

        public override void TakeCard(Card card)
        {
            base.TakeCard(card);
            Console.WriteLine("You took a " + card.Name);
        }
    }
}