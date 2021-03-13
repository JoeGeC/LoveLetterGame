using LoveLetter.Players;

namespace LoveLetter
{
    public interface ITokenChangeListener
    {
        void OnTokenChanged(Player player);
    }
}