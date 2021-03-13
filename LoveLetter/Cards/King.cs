using LoveLetter.Players;

namespace LoveLetter.Cards
{
    public class King : Card
    {
        public King()
        {
            Name = "King";
            Description = "Trade hands with another player of your choice";
            Value = 6;
        }
        
        public override void DoAction(Player currentPlayer, IPlayerFinder playerFinder)
        {
            throw new System.NotImplementedException();
        }
    }
}