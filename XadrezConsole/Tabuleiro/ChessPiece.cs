using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabuleiro
{
    internal class ChessPiece//Peça de xadrez
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Table Tab { get; protected set; }

        //Construtor principal da classe
        public ChessPiece(Position position, Table tab, Color color)
        {
            Position = position;
            Tab = tab;
            Color = color;
            this.QteMovimentos = 0;
     
        }
    }
}
