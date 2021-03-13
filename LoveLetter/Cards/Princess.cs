using LoveLetter.Players;

namespace LoveLetter.Cards
{
    public class Princess : Card
    {
        public Princess()
        {
            Name = "Princess";
            Description = "If you discard this card you are out of the round.";
            Value = 8;
        }

        public override void DoAction(Player currentPlayer, IPlayerFinder playerFinder)
        {
        }
    }
}