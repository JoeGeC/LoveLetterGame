using LoveLetter.Players;

namespace LoveLetter.Cards.Listeners
{
    public interface IBaronListener
    {
        void CompareHands(int chosenPlayerNumber, Player currentPlayer);
    }
}