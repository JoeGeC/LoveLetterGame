using System;
using LoveLetter.Players;

namespace LoveLetter.Cards
{
    public class Baron : Card
    {
        public Baron()
        {
            Name = "Baron";
            Description =
                "You and another player secretly compare hands. The player with the lower value is out of the round.";
            Value = 3;
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
                    CompareHands(chosenPlayer, currentPlayer);
                    return;
                } 
                Console.WriteLine("Player is protected by handmaid!");
            }
        }

        private void CompareHands(Player chosenPlayer, Player currentPlayer)
        {
            if(chosenPlayer.FirstCard().Value > currentPlayer.FirstCard().Value) currentPlayer.OutOfRound();
            if(chosenPlayer.FirstCard().Value < currentPlayer.FirstCard().Value) chosenPlayer.OutOfRound();
        }
    }
}