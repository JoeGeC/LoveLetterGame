using System;
using System.Linq;
using System.Threading;
using LoveLetter.Cards;

namespace LoveLetter.Players
{
    public class Cpu : Player
    {
        private readonly Random random = new Random();
        private const int ChoiceDelay = 1000;

        public Cpu(int number, ITokenChangeListener tokenChangeListener) : base(number, tokenChangeListener)
        {
        }

        public override void PlayTurn(IPlayerFinder playerFinder)
        {
            base.PlayTurn(playerFinder);
            Thread.Sleep(ChoiceDelay);
            var card = Hand.ElementAt(random.Next(1));
            Play(card, playerFinder);
        }

        public override int ChoosePlayer()
        {
            Console.Write("Choose a player: ");
            var randomNumber = random.Next(1, 5); 
            Thread.Sleep(ChoiceDelay);
            Console.WriteLine(randomNumber);
            return randomNumber;
        }

        public override string ChooseCard()
        {
            Console.Write("Choose a Card: ");
            var randomName = PossibleCards.GetRandomName();
            Thread.Sleep(ChoiceDelay);
            Console.WriteLine(randomName);
            return randomName;
        }

        public override void SeeHandOf(Player player)
        {
        }
    }
}