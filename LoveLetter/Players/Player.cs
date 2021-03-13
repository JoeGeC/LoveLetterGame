using System;
using System.Collections.Generic;
using System.Linq;
using LoveLetter.Cards;

namespace LoveLetter.Players
{
    public abstract class Player
    {
        public readonly int Number;
        private readonly ITokenChangeListener tokenChangeListener;
        protected List<Card> Hand = new List<Card>();
        public bool IsInRound = true;
        public bool Vulnerable = true;
        public int Tokens = 0;

        protected Player(int number, ITokenChangeListener tokenChangeListener)
        {
            Number = number;
            this.tokenChangeListener = tokenChangeListener;
        }

        public abstract int ChoosePlayer();
        public abstract string ChooseCard();
        public abstract void SeeHandOf(Player player);

        public virtual void PlayTurn(IPlayerFinder playerFinder)
        {
            Vulnerable = true;
        }

        public virtual void TakeCard(Card card)
        {
            Hand.Add(card);
        }

        public void PrintHand()
        {
            Hand.ForEach(card => card.Print());
        }

        public bool HasCard(string card)
        {
            return Hand.Any(handCard => handCard.Is(card));
        }

        public void OutOfRound()
        {
            IsInRound = false;
            Console.WriteLine($"Player {Number} is out of the round!");
            if (Hand.Count > 0) Discard(FirstCard());
        }
        
        protected void Play(Card card, IPlayerFinder playerFinder)
        {
            Hand.Remove(card);
            Console.WriteLine($"Player {Number} played {card.Name}");
            card.DoAction(this, playerFinder);
            if(card.Is("princess")) OutOfRound();
        }

        public void Discard(Card card)
        {
            Hand.Remove(card);
            Console.WriteLine($"Player {Number} discarded {card.Name}");
            if(card.Is("princess")) OutOfRound();
        } 

        public Card FirstCard()
        {
            return Hand.ElementAt(0);
        }

        public virtual void TradeHands(Player player)
        {
            var tempHand = Hand;
            Hand = player.Hand;
            player.Hand = tempHand;
        }

        public void AddToken()
        {
            Console.WriteLine($"Player {Number} got a token!");
            Tokens++;
            tokenChangeListener.OnTokenChanged(this);
        }

        public void NewRound()
        {
            IsInRound = true;
            Vulnerable = true;
            Hand = new List<Card>();
        }
    }
}