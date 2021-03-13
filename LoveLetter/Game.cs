using System;
using System.Collections.Generic;
using System.Linq;
using LoveLetter.Players;

namespace LoveLetter
{
    public class Game
    {
        List<Player> players = new List<Player>()
        {
            new Human(),
            new Cpu(),
            new Cpu(),
            new Cpu()
        };
        Deck deck = new Deck();
        private int currentPlayerNumber = 0;

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
            var currentPlayer = players.ElementAt(currentPlayerNumber);
            currentPlayer.TakeCard(deck.TakeTopCard());
            currentPlayer.PlayTurn();
        }
    }
}