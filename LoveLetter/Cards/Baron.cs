using LoveLetter.Cards.Listeners;
using LoveLetter.Players;

namespace LoveLetter.Cards
{
    public class Baron : Card
    {
        private IBaronListener listener;

        public Baron(IBaronListener listener)
        {
            this.listener = listener;
            Name = "Baron";
            Description =
                "You and another player secretly compare hands. The player with the lower value is out of the round.";
            Value = 3;
        }
        
        public override void DoAction(Player currentPlayer)
        {
            listener.CompareHands(currentPlayer.ChoosePlayer(), currentPlayer);
        }
    }
}