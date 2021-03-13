﻿using System;
using System.Collections.Generic;
using System.Linq;
using LoveLetter.Cards;

namespace LoveLetter.Players
{
    public abstract class Player
    {
        private readonly int number;
        protected readonly List<Card> Hand = new List<Card>();
        public bool IsInRound = true;

        protected Player(int number)
        {
            this.number = number;
        }
        
        public abstract void PlayTurn();
        public abstract int ChoosePlayer();
        public abstract string ChooseCard();
        public abstract void SeeHandOf(Player player);

        public virtual void TakeCard(Card card)
        {
            Hand.Add(card);
        }

        public void PrintHand()
        {
            Hand.ForEach(card => card.Print());
            Console.WriteLine("\n");
        }

        public bool HasCard(string card)
        {
            return Hand.Any(handCard => handCard.Is(card));
        }

        public void OutOfRound()
        {
            IsInRound = false;
            Console.WriteLine($"Player {number} is out of the round!");
            Discard(Hand.ElementAt(0));
        }
        
        protected void Play(Card card)
        {
            Hand.Remove(card);
            Console.WriteLine($"Player {number} played {card.Name}");
            card.DoAction(this);
        }

        private void Discard(Card card)
        {
            Hand.Remove(card);
            Console.WriteLine($"Player {number} discarded {card.Name}");
        }
    }
}