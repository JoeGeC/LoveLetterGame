using System;
using LoveLetter.Cards.Listeners;

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
        
        public override void DoAction()
        {
            base.DoAction();
            var player = ChoosePlayer();
            var card = ChooseCard();
            listener.DoGuardAction(player, card);
        }

        private string ChooseCard()
        {
            while (true)
            {
                Console.Write("Choose a Card: ");
                var input = Console.ReadLine()?.ToLower();
                if (input != null && !input.Equals("guard") && input.IsACard())
                    return input;
            }
        }

        private static int ChoosePlayer()
        {
            while (true)
            {
                Console.Write("Choose a player: ");
                var input = Console.ReadLine();
                int.TryParse(input, out var inputAsInt);
                if (inputAsInt > 0 && inputAsInt < 5)
                    return inputAsInt;
            }
        }
    }
}