using System;
using System.Collections.Generic;
using System.Linq;
using LoveLetter.Cards;
using LoveLetter.Players;

namespace LoveLetter
{
    public class Game: IPlayerFinder, IDealListener, ITokenChangeListener
    {
        private readonly Deck deck;
        private Player winner;

        private readonly List<Player> players;

        public Game()
        {
            players = new List<Player>()
            {
                new Human(1, this),
                new Cpu(2, this),
                new Cpu(3, this),
                new Cpu(4, this)
            };
            deck = new Deck(this);
        }

        public void Play()
        {
            while(winner == null)
                PlayRound();
        }

        private void PlayRound()
        {
            deck.Shuffle();
            deck.TakeTopCard();
            DealCards();
            var endRound = false;
            while (!endRound) endRound = PlayTurn();
            FindWinner();
        }

        private void FindWinner()
        {
            var result = new List<Player>();
            foreach (var player in players.Where(player => player.IsInRound))
                result.Add(CompareWinner(result.ElementAt(0).FirstCard().Value, player));
            result.ForEach(player => player.AddToken());
        }

        private static Player CompareWinner(int winningValue, Player player)
        {
            if (winningValue == 0) return player;
            return player.FirstCard().Value > winningValue ? player : null;
        }

        private bool OnePlayerLeft()
        {
            var playersLeft = players.Count(player => player.IsInRound);
            return playersLeft <= 1;
        }

        private void DealCards()
        {
            players.ForEach(player => player.TakeCard(deck.TakeTopCard()));
            Console.WriteLine("Cards have been dealt to each player.");
        }
        
        private bool PlayTurn()
        {
            foreach (var player in players.Where(player => player.IsInRound))
            {
                if (deck.IsEmpty() || OnePlayerLeft()) return true;
                player.TakeCard(deck.TakeTopCard());
                player.PlayTurn(this);
            }
            return false;
        }

        public Player PlayerAt(int number)
        {
            return players.ElementAtOrDefault(number);
        }

        public bool ValidPlayersAvailable()
        {
            return players.Any(player => player.IsInRound && player.Vulnerable);
        }

        public void DealCard(Player player)
        {
            if(player.IsInRound) player.TakeCard(deck.TakeTopCard());
        }

        public void OnTokenChanged(Player player)
        {
            if (player.Tokens >= 4) winner = player;
        }
    }
}