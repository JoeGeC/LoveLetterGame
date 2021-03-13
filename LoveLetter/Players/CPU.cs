using System;
using System.Linq;
using System.Threading;
using LoveLetter.Cards;

namespace LoveLetter.Players
{
    public class Cpu : Player
    {
        private readonly Random random = new Random();
        private int choiceDelay = 1000;

        public Cpu(int number) : base(number)
        {
        }

        public override void PlayTurn()
        {
            Thread.Sleep(choiceDelay);
            var card = Hand.ElementAt(random.Next(1));
            Play(card);
        }

        public override int ChoosePlayer()
        {
            Console.Write("Choose a player: ");
            var randomNumber = random.Next(1, 4); 
            Thread.Sleep(choiceDelay);
            Console.WriteLine(randomNumber);
            return randomNumber;
        }

        public override string ChooseCard()
        {
            Console.Write("Choose a Card: ");
            var randomName = PossibleCards.GetRandomName();
            Thread.Sleep(choiceDelay);
            Console.WriteLine(randomName);
            return randomName;
        }

        public override void SeeHandOf(Player player)
        {
        }
    }
}