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
            Console.WriteLine($"    {Name} - {Value}");
            Console.WriteLine($"    {Description} \n");
        }

        public bool Is(string cardName)
        {
            return Name.ToLower().Equals(cardName.ToLower());
        }

        protected static Player ChoosePlayer(Player currentPlayer, IPlayerFinder playerFinder)
        {
            if (!playerFinder.ValidPlayersAvailable(currentPlayer)) return NoValidPlayers();
            while (true)
            {
                var chosenPlayerNumber = currentPlayer.ChoosePlayer();
                var chosenPlayer = playerFinder.PlayerAt(chosenPlayerNumber - 1);
                if (!IsValidPlayer(chosenPlayer, currentPlayer)) continue;
                return chosenPlayer;
            }
        }

        private static Player NoValidPlayers()
        {
            Console.WriteLine("No valid players.");
            return null;
        }

        private static bool IsValidPlayer(Player chosenPlayer, Player currentPlayer)
        {
            if (chosenPlayer == null) return false;
            if (chosenPlayer.Number == currentPlayer.Number) return ChosenPlayerIsYou();
            if (!chosenPlayer.IsInRound) return ChosenPlayerIsOutOfRound(chosenPlayer);
            if (!chosenPlayer.Vulnerable) return ChosenPlayerIsProtected();
            return true;
        }

        private static bool ChosenPlayerIsOutOfRound(Player chosenPlayer)
        {
            Console.WriteLine($"Player {chosenPlayer.Number} is out. Choose another player.");
            return false;
        }

        private static bool ChosenPlayerIsYou()
        {
            Console.WriteLine("That is you! Choose another player.");
            return false;
        }

        private static bool ChosenPlayerIsProtected()
        {
            Console.WriteLine("Player is protected by handmaid!");
            return false;
        }
    }
}