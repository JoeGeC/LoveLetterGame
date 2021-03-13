using System;

namespace LoveLetter.Cards
{
    public abstract class Card
    {
        public string Name;
        protected string Description;
        protected int Value;

        public abstract void DoAction();

        public void Print()
        {
            Console.WriteLine("\n" + Name + " - " + Value);
            Console.WriteLine(Description);
        }
    }
}