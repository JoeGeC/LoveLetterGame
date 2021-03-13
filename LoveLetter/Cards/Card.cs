using System;
using LoveLetter.Players;

namespace LoveLetter.Cards
{
    public abstract class Card
    {
        public string Name;
        protected string Description;
        public int Value;

        public virtual void DoAction(Player currentPlayer)
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