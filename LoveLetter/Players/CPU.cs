using System;
using System.Linq;
using LoveLetter.Cards;

namespace LoveLetter.Players
{
    public class Cpu : Player
    {
        private readonly Random random = new Random();

        public Cpu(int number) : base(number)
        {
        }

        public override void PlayTurn()
        {
            var card = Hand.ElementAt(random.Next(1));
            Play(card);
        }

        public override int ChoosePlayer()
        {
            return random.Next(1, 4);
        }

        public override string ChooseCard()
        {
            return PossibleCards.GetRandomName();
        }
    }
}