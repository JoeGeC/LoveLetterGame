using System;
using LoveLetter.Players;

namespace LoveLetter.Cards
{
    public abstract class Card
    {
        public string Name;
        protected string Description;
        public int Value;

        public virtual void DoAction(Player currentPlayer, IPlayerFinder playerFinder)
        {
            Print();
        }

        public void Print()
        {
            Console.WriteLine("\n" + Name + " - " + Value);
            Console.WriteLine(Description);
        }

        public bool Is(string cardName)
        {
            return Name.ToLower().Equals(cardName.ToLower());
        }

        protected Player ChoosePlayer(Player currentPlayer, IPlayerFinder playerFinder)
        {
            while (true)
            {
                var chosenPlayerNumber = currentPlayer.ChoosePlayer();
                var chosenPlayer = playerFinder.PlayerAt(chosenPlayerNumber);
                if (chosenPlayer == null) continue;
                if (chosenPlayer.Vulnerable) return chosenPlayer;
                Console.WriteLine("Player is protected by handmaid!");
            }
        }
    }
}