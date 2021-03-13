using LoveLetter.Players;

namespace LoveLetter.Cards
{
    public class Handmaid : Card
    {
        public Handmaid()
        {
            Name = "Handmaid";
            Description = "Until your next turn, ignore all effects from other players' cards";
            Value = 4;
        }

        public override void DoAction(Player currentPlayer, IPlayerFinder playerFinder)
        {
            base.DoAction(currentPlayer, playerFinder);
            currentPlayer.Vulnerable = false;
        }
    }
}