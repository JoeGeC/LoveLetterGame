using System;
using LoveLetter.Players;

namespace LoveLetter.Cards
{
    public class Guard : Card
    {
        public Guard()
        {
            Name = "Guard";
            Description =
                "Name a non-Guard card and choose another player. If they have that card they're out of the round.";
            Value = 1;
        }
        
        public override void DoAction(Player currentPlayer, IPlayerFinder playerFinder)
        {
            base.DoAction(currentPlayer, playerFinder);
            var player = ChoosePlayer(currentPlayer, playerFinder);
            var card = ChooseCard(currentPlayer);
            DoGuardAction(player, card);
        }

        private static string ChooseCard(Player currentPlayer)
        {
            while (true)
            {
                var input = currentPlayer.ChooseCard();
                if (input != null && !input.Equals("guard") && input.IsACard())
                    return input;
            }
        }

        private static void DoGuardAction(Player player, string card)
        {
            if (player.HasCard(card)) player.OutOfRound();
            else Console.WriteLine($"Player {player.Number} did not have a {card}");
        }
    }
}