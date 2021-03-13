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
            base.DoAction(currentPlayer, playerFinder);
            var chosenPlayer = ChoosePlayer(currentPlayer, playerFinder);
            ShowHandOf(chosenPlayer, currentPlayer);
        }

        private static void ShowHandOf(Player chosenPlayer, Player currentPlayer)
        {
            currentPlayer.SeeHandOf(chosenPlayer);
        }
    }
}