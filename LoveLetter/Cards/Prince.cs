using LoveLetter.Players;

namespace LoveLetter.Cards
{
    public class Prince : Card
    {
        public Prince()
        {
            Name = "Prince";
            Description = "Choose any player to discard his or her hand and draw a new card";
            Value = 5;
        }

        public override void DoAction(Player currentPlayer, IPlayerFinder playerFinder)
        {
            throw new System.NotImplementedException();
        }
    }
}