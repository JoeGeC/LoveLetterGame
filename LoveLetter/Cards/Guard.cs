using System;
using LoveLetter.Cards.Listeners;
using LoveLetter.Players;

namespace LoveLetter.Cards
{
    public class Guard : Card
    {
        IGuardListener listener;
        
        public Guard(IGuardListener listener)
        {
            this.listener = listener;
            Name = "Guard";
            Description =
                "Name a non-Guard card and choose another player. If they have that card they're out of the round.";
            Value = 1;
        }
        
        public override void DoAction(Player currentPlayer)
        {
            base.DoAction(currentPlayer);
            var player = ChoosePlayer(currentPlayer);
            var card = ChooseCard(currentPlayer);
            listener.DoGuardAction(player, card);
        }

        private static int ChoosePlayer(Player currentPlayer)
        {
            while (true)
            {
                var chosenPlayer = currentPlayer.ChoosePlayer();
                if (chosenPlayer > 0 && chosenPlayer < 5)
                    return chosenPlayer;
            }
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
    }
}