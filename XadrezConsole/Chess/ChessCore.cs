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
        private HashSet<ChessPiece> Pieces;//conjunto de peças
        private HashSet<ChessPiece> Captured;//conjunto de peças capturadas

        public ChessCore()
        {
            Tab = new Table(8, 8);
            Turn = 1;
            APlayer = Color.White;
            Pieces = new HashSet<ChessPiece>();
            Captured = new HashSet<ChessPiece>();
            ColocarPecas();
        }
        public void ExeMoviment(Position Origin, Position Destination)//metodo que executa o movimento
        {
            ChessPiece P = Tab.Retirarpeca(Origin);
            P.InclementMoviment();
            ChessPiece CapturePiece = Tab.Retirarpeca(Destination);
            Tab.ColocarPeca(P, Destination);
            if (CapturePiece != null)
            {
                Captured.Add(CapturePiece);
            }
        }
        public void ExePlay(Position Origin, Position Destination)//metodo que chama ExeMoviment, passa de turno e muda o jogador
        {
            ExeMoviment(Origin, Destination);
            Turn++;
            ChangePlayer();
        }
        public void ValidOriginPos(Position pos)//metodo para validar a posiçao de origem, caso seja invalida tratar a exceção
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
        public void ValidDestinationPos(Position Origin, Position Destination)//metodo para validar a posiçao de destino, caso seja invalida tratar a exceção
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
        public HashSet<ChessPiece> Capturedpieces(Color color)
        {
            HashSet<ChessPiece> aux = new HashSet<ChessPiece>();
            foreach (ChessPiece p in Captured)
            {
                if(p.Color == color)
                {
                    aux.Add(p);
                }
            }
            return aux;
        }
        public HashSet<ChessPiece> Ingamepiece(Color color)
        {
            HashSet<ChessPiece> aux = new HashSet<ChessPiece>();
            foreach (ChessPiece p in Pieces)
            {
                if (p.Color == color)
                {
                    aux.Add(p);
                }
            }
            aux.ExceptWith(Capturedpieces(color));
            return aux;
        }
        public void PutNewPiece(char column, int line, ChessPiece piece)//novo metodp para colocar as peças no tabuleiro, agora alem de seram onstanciadas serão guardadas em um conjunto chamado Pieces
        {
            Tab.ColocarPeca(piece, new ChessPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }
        private void ColocarPecas()//colocando as peças dentro da classe core
        {
            //brancas
            PutNewPiece('c', 1, new Rook(Tab, Color.White));
            PutNewPiece('c', 2, new Rook(Tab, Color.White));
            PutNewPiece('d', 2, new Rook(Tab, Color.White));
            PutNewPiece('e', 2, new Rook(Tab, Color.White));
            PutNewPiece('e', 1, new Rook(Tab, Color.White));
            PutNewPiece('d', 1, new King(Tab, Color.White));
            //pretas
            PutNewPiece('c', 7, new Rook(Tab, Color.Black));
            PutNewPiece('c', 8, new Rook(Tab, Color.Black));
            PutNewPiece('d', 7, new Rook(Tab, Color.Black));
            PutNewPiece('e', 7, new Rook(Tab, Color.Black));
            PutNewPiece('e', 8, new Rook(Tab, Color.Black));
            PutNewPiece('d', 8, new King(Tab, Color.Black));
        }
    }
}
