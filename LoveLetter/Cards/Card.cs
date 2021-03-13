using System;

namespace LoveLetter.Cards
{
    public abstract class Card
    {
        public string Name;
        protected string Description;
        protected int Value;

        public virtual void DoAction()
        {
            Print();
        }

        public void Print()
        {
            Console.WriteLine("\n" + Name + " - " + Value);
            Console.WriteLine(Description);
        }

        public bool Is(string cardName)
        {
            return Name.ToLower().Equals(cardName.ToLower());
        }
    }
}