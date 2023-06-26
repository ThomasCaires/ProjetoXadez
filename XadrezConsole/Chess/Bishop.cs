﻿using Tabuleiro;

namespace Chess
{
    internal class Bishop : ChessPiece
    {
        public Bishop(Table tab, Color color) : base(tab, color)
        {
        }
        public override string ToString()
        {
            return "B";
        }
    }
}
