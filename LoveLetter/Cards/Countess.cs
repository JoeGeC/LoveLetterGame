﻿using LoveLetter.Players;

namespace LoveLetter.Cards
{
    public class Countess : Card
    {
        public Countess()
        {
            Name = "Countess";
            Description = "If you have this card and the King or the Prince in your hand, you must discard this card.";
            Value = 7;
        }

        public override void DoAction(Player currentPlayer)
        {
            throw new System.NotImplementedException();
        }
    }
}