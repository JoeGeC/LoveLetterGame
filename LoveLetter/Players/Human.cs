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

        public override void PlayTurn(IPlayerFinder playerFinder)
        {
            base.PlayTurn(playerFinder);
            PrintHand();
            Card playCard = null;
            while (playCard == null)
            {
                var cardChoice = ChooseCard();
                playCard = Hand.FirstOrDefault(card => card.Name.ToLower().Equals(cardChoice));
            }
            Play(playCard, playerFinder);
        }

        public override int ChoosePlayer()
        {
            Console.Write("Choose a player: ");
            var input = Console.ReadLine();
            int.TryParse(input, out var inputAsInt);
            return inputAsInt;
        }

        public override string ChooseCard()
        {
            Console.Write("Choose a Card: ");
            return Console.ReadLine()?.ToLower();
        }

        public override void SeeHandOf(Player player)
        {
            player.PrintHand();
        }

        public override void TakeCard(Card card)
        {
            base.TakeCard(card);
            Console.WriteLine("You took a " + card.Name);
        }
    }
}