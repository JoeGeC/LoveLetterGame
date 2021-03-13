namespace LoveLetter.Cards
{
    public abstract class Card
    {
        protected string Name;
        protected string Description;
        protected int Value;

        public abstract void DoAction();
    }
}