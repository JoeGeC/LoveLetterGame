using LoveLetter.Players;

namespace LoveLetter.Cards.Listeners
{
    public interface IPriestListener
    {
        void ShowHandOf(int choosePlayer, Player currentPlayer);
    }
}