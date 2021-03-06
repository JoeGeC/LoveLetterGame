using LoveLetter.Players;

namespace LoveLetter
{
    public interface IPlayerFinder
    {
        public Player PlayerAt(int number);
        bool ValidPlayersAvailable(Player currentPlayer);
    }
}