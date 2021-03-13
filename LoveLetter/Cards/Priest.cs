using System;
using LoveLetter.Players;

namespace LoveLetter.Cards
{
    public class Priest : Card
    {
        public Priest()
        {
            Name = "Priest";
            Description = "Look at another player's hand.";
            Value = 2;
        }

        public override void DoAction(Player currentPlayer, IPlayerFinder playerFinder)
        {
            while (true)
            {
                var chosenPlayerNumber = currentPlayer.ChoosePlayer();
                var chosenPlayer = playerFinder.PlayerAt(chosenPlayerNumber);
                if (chosenPlayer == null) continue;
                if (chosenPlayer.Vulnerable)
                {
                    ShowHandOf(chosenPlayer, currentPlayer);
                    return;
                } 
                Console.WriteLine("Player is protected by handmaid!");
            }
        }

        private static void ShowHandOf(Player chosenPlayer, Player currentPlayer)
        {
            currentPlayer.SeeHandOf(chosenPlayer);
        }
    }
}