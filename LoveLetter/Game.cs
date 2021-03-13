using System;
using System.Collections.Generic;
using System.Linq;
using LoveLetter.Players;

namespace LoveLetter
{
    public class Game: IPlayerFinder
    {
        private readonly Deck deck;

        private readonly List<Player> players = new List<Player>()
        {
            new Human(1),
            new Cpu(2),
            new Cpu(3),
            new Cpu(4)
        };

        public Game()
        {
            deck = new Deck(this);
        }

        public void Play()
        {
            deck.Shuffle();
            deck.TakeTopCard();
            DealCards();
            while (!deck.IsEmpty())
                PlayTurn();
        }

        private void DealCards()
        {
            players.ForEach(player => player.TakeCard(deck.TakeTopCard()));
            Console.WriteLine("Cards have been dealt to each player.");
        }
        
        private void PlayTurn()
        {
            foreach (var player in players.Where(player => player.IsInRound))
            {
                if (deck.IsEmpty()) return;
                player.TakeCard(deck.TakeTopCard());
                player.PlayTurn(this);
            }
        }

        public Player PlayerAt(int number)
        {
            return players.ElementAtOrDefault(number);
        }
    }
}