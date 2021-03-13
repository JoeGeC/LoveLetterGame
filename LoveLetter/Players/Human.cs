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
            Console.WriteLine("Your hand: \n");
            PrintHand();
            Card playCard = null;
            if (HasCard("countess") && (HasCard("king") || HasCard("prince"))) playCard = GetCardFromHand("countess");
            while (playCard == null)
            {
                var cardChoice = ChooseCard();
                playCard = GetCardFromHand(cardChoice);
            }
            Play(playCard, playerFinder);
        }

        private Card GetCardFromHand(string cardChoice)
        {
            return Hand.FirstOrDefault(card => card.Name.ToLower().Equals(cardChoice));
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

        public override void TradeHands(Player player)
        {
            base.TradeHands(player);
            PrintHand();
        }
    }
}