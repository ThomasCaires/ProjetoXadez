using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace XadrezConsole.Tabuleiro
{
    internal class ChessPiece//Peça de xadrez
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Table Tab { get; set; }

        //Construtor principal da classe
        public ChessPiece(Position position, Color color, Table tab)
        {
            Position = position;
            Color = color;
            this.QteMovimentos = 0;
            Tab = tab;
        }
    }
}
