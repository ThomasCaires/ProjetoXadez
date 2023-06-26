using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace Chess
{
    internal class ChessCore //classe que contem a mecanica do jogo de xadrez
    {
        public Table Tab { get; private set; } = null!;
        private int Turn { get; set; }
        private Color APlayer { get; set; }
        public bool Over { get; private set; }

        public ChessCore()
        {
            Tab = new Table(8, 8);
            Turn = 1;
            APlayer = Color.White;
            ColocarPecas();
        }
        public void ExeMoviment(Position Origin, Position Destination)
        {
            ChessPiece P = Tab.Retirarpeca(Origin);
            P.InclementMoviment();
            ChessPiece CapturePiece = Tab.Retirarpeca(Destination);
            Tab.ColocarPeca(P, Destination);
        }
       private void ColocarPecas()//colocando as peças dentro da classe core
        {
            Tab.ColocarPeca(new Rook(Tab, Color.White), new ChessPosition('c', 1).ToPosition());
            Tab.ColocarPeca(new Rook(Tab, Color.White), new ChessPosition('c', 2).ToPosition());
            Tab.ColocarPeca(new Rook(Tab, Color.White), new ChessPosition('d', 2).ToPosition());
            Tab.ColocarPeca(new Rook(Tab, Color.White), new ChessPosition('e', 2).ToPosition());
            Tab.ColocarPeca(new Rook(Tab, Color.White), new ChessPosition('e', 1).ToPosition());
            Tab.ColocarPeca(new King(Tab, Color.White), new ChessPosition('d', 1).ToPosition());

            Tab.ColocarPeca(new Rook(Tab, Color.Black), new ChessPosition('c', 7).ToPosition());
            Tab.ColocarPeca(new Rook(Tab, Color.Black), new ChessPosition('c', 8).ToPosition());
            Tab.ColocarPeca(new Rook(Tab, Color.Black), new ChessPosition('d', 7).ToPosition());
            Tab.ColocarPeca(new Rook(Tab, Color.Black), new ChessPosition('e', 7).ToPosition());
            Tab.ColocarPeca(new Rook(Tab, Color.Black), new ChessPosition('e', 8).ToPosition());
            Tab.ColocarPeca(new King(Tab, Color.Black), new ChessPosition('d', 8).ToPosition());
        }
    }
}
