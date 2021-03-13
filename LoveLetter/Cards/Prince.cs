using LoveLetter.Players;

namespace LoveLetter.Cards
{
    public class Prince : Card
    {
        private readonly IDealListener listener;

        public Prince(IDealListener listener)
        {
            this.listener = listener;
            Name = "Prince";
            Description = "Choose any player to discard his or her hand and draw a new card";
            Value = 5;
        }

        public override void DoAction(Player currentPlayer, IPlayerFinder playerFinder)
        {
            base.DoAction(currentPlayer, playerFinder);
            var player = ChoosePlayer(currentPlayer, playerFinder);
            player.Discard(player.FirstCard());
            listener.DealCard(player);
        }
    }
}