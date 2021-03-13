using LoveLetter.Cards.Listeners;
using LoveLetter.Players;

namespace LoveLetter.Cards
{
    public class Priest : Card
    {
        readonly IPriestListener listener;
        
        public Priest(IPriestListener listener)
        {
            this.listener = listener;
            Name = "Priest";
            Description = "Look at another player's hand.";
            Value = 2;
        }

        public override void DoAction(Player currentPlayer)
        {
            base.DoAction(currentPlayer);
            listener.ShowHandOf(currentPlayer.ChoosePlayer(), currentPlayer);
        }
    }
}