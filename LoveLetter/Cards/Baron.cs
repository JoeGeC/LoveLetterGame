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
            base.DoAction(currentPlayer, playerFinder);
            var chosenPlayer = ChoosePlayer(currentPlayer, playerFinder);
            CompareHands(chosenPlayer, currentPlayer);
        }

        private void CompareHands(Player chosenPlayer, Player currentPlayer)
        {
            if(chosenPlayer.FirstCard().Value > currentPlayer.FirstCard().Value) currentPlayer.OutOfRound();
            else if(chosenPlayer.FirstCard().Value < currentPlayer.FirstCard().Value) chosenPlayer.OutOfRound();
        }
    }
}