using System;
using System.Collections.Generic;
using System.Linq;
using LoveLetter.Cards.Listeners;
using LoveLetter.Players;

namespace LoveLetter
{
    public class Game: IGuardListener, IPriestListener, IBaronListener
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
                player.PlayTurn();
            }
        }

        public void DoGuardAction(int playerNumber, string card)
        {
            var player = players.ElementAt(playerNumber - 1);
            if (player.HasCard(card)) player.OutOfRound();
            else Console.WriteLine("Player did not have a {card}");
        }

        public void ShowHandOf(int playerNumber, Player currentPlayer)
        {
            var player = players.ElementAt(playerNumber - 1);
            currentPlayer.SeeHandOf(player);
        }

        public void CompareHands(int chosenPlayerNumber, Player currentPlayer)
        {
            var chosenPlayer = players.ElementAt(chosenPlayerNumber - 1);
            if(chosenPlayer.FirstCard().Value > currentPlayer.FirstCard().Value) currentPlayer.OutOfRound();
            if(chosenPlayer.FirstCard().Value < currentPlayer.FirstCard().Value) chosenPlayer.OutOfRound();
        }
    }
}