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
        public int Turn { get; private set; }
        public Color APlayer { get; set; }
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
        public void ExePlay(Position Origin, Position Destination)
        {
            ExeMoviment(Origin, Destination);
            Turn++;
            ChangePlayer();
        }
        public void ValidOriginPos(Position pos)
        {
            if (Tab.Piece(pos) == null)
            {
                throw new TableException("Não existe peça na posição escolhida");
            }
            if (APlayer != Tab.Piece(pos).Color)
            {
                throw new TableException("A peça escolhida não é sua");
            }
            if (!Tab.Piece(pos).ExistMove())
            {
                throw new TableException("Não ha movimentos possiveis para peça escolhida");
            }
        }
        public void ValidDestinationPos(Position Origin, Position Destination)
        {
            if (!Tab.Piece(Origin).CanMoveTo(Destination))
            {
                throw new TableException("Posiçao de destino invalida");
            }
        }
        private void ChangePlayer()//metodo para mudar o jogador
        {
            if (APlayer == Color.White)//jogador atual for branco entao agore sera preto
            {
                APlayer = Color.Black;
            }
            else//caso contrario sera branco
            {
                APlayer = Color.White;
            }
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
