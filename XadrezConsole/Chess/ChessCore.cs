using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
        public bool xeque { get; private set; }
        public bool Over { get; private set; }
        private HashSet<ChessPiece> Pieces;//conjunto de peças
        private HashSet<ChessPiece> Captured;//conjunto de peças capturadas
        public ChessPiece Vulneravelenpassant { get; private set; }

        public ChessCore()
        {
            Tab = new Table(8, 8);
            Turn = 1;
            APlayer = Color.White;
            xeque = false;
            Over = false;
            Pieces = new HashSet<ChessPiece>();
            Captured = new HashSet<ChessPiece>();
            Vulneravelenpassant = null;
            ColocarPecas();
        }
        public ChessPiece ExeMoviment(Position Origin, Position Destination)//metodo que executa o movimento
        {
            ChessPiece p = Tab.Retirarpeca(Origin);
            p.InclementMoviment();
            ChessPiece pecaCapturada = Tab.Retirarpeca(Destination);
            Tab.ColocarPeca(p, Destination);
            if (pecaCapturada != null)
            {
                Captured.Add(pecaCapturada);
            }
            //Roque pequeno
            if (p is King && Destination.Column == Origin.Column + 2)
            {
                Position origint = new Position(Origin.Line, Origin.Column + 3);
                Position destt = new Position(Origin.Line, Origin.Column + 1);
                ChessPiece T = Tab.Retirarpeca(origint);
                T.InclementMoviment();
                Tab.ColocarPeca(T, destt);
            }
            //Roque grande
            if (p is King && Destination.Column == Origin.Column - 2)
            {
                Position origint = new Position(Origin.Line, Origin.Column - 4);
                Position destt = new Position(Origin.Line, Origin.Column - 1);
                ChessPiece T = Tab.Retirarpeca(origint);
                T.InclementMoviment();
                Tab.ColocarPeca(T, destt);
            }
            //En Passant
            if (p is Pawn)
            {
                if (Origin.Column != Destination.Column && pecaCapturada == null)
                {
                    Position posP;
                    if (p.Color == Color.White)
                    {
                        posP = new Position(Destination.Line + 1, Destination.Column);
                    }
                    else
                    {
                        posP = new Position(Destination.Line - 1, Destination.Column);
                    }
                    pecaCapturada = Tab.Retirarpeca(posP);
                    Captured.Add(pecaCapturada);
                }
            }
            return pecaCapturada;
        }
        public void desfazMovimento(Position origem, Position destino, ChessPiece pecaCapturada)
        {
            ChessPiece p = Tab.Retirarpeca(destino);
            p.DenclementMoviment();
            if (pecaCapturada != null)
            {
                Tab.ColocarPeca(pecaCapturada, destino);
                Captured.Remove(pecaCapturada);
            }
            //Roque pequeno
            if (p is King && destino.Column == origem.Column + 2)
            {
                Position origint = new Position(origem.Line, origem.Column + 3);
                Position destt = new Position(origem.Line, origem.Column + 1);
                ChessPiece T = Tab.Retirarpeca(destt);
                T.DenclementMoviment();
                Tab.ColocarPeca(T, origint);
            }
            //Roque grande
            if (p is King && destino.Column == origem.Column - 2)
            {
                Position origint = new Position(origem.Line, origem.Column - 4);
                Position destt = new Position(origem.Line, origem.Column - 1);
                ChessPiece T = Tab.Retirarpeca(destt);
                T.DenclementMoviment();
                Tab.ColocarPeca(T, origint);
            }
            //En Passant
            if (p is Pawn)
            {
                if (origem.Column != destino.Column && pecaCapturada == Vulneravelenpassant)
                {
                    ChessPiece pawn= Tab.Retirarpeca(destino);
                    Position posP;
                    if(p.Color == Color.White)
                    {
                        posP=new Position(3, destino.Column);
                    }
                    else
                    {
                        posP = new Position(4, destino.Column);
                    }
                    Tab.ColocarPeca(pawn, posP);
                }
            }
        }
        public void ExePlay(Position Origin, Position Destination)//metodo que chama ExeMoviment, passa de turno e muda o jogador
        {
            ChessPiece pecaCapturada = ExeMoviment(Origin, Destination);

            if (estaEmXeque(APlayer))
            {
                desfazMovimento(Origin, Destination, pecaCapturada);
                throw new TableException("Você não pode se colocar em xeque!");
            }

            if (estaEmXeque(adversaria(APlayer)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }
            if (testeXequemate(adversaria(APlayer)))
            {
                Over = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }
            ChessPiece p = Tab.Piece(Destination);
            //En Passant
            if (p is Pawn && (Destination.Line == Origin.Line - 2 || Destination.Line == Origin.Line + 2))
            {
                Vulneravelenpassant = p;
            }
            else
            {
                Vulneravelenpassant = null;
            }
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
                if (p.Color == color)
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
        private Color adversaria(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private ChessPiece rei(Color color)
        {
            foreach (ChessPiece x in Ingamepiece(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool estaEmXeque(Color color)
        {
            ChessPiece R = rei(color);
            if (R == null)
            {
                throw new TableException($"Não tem rei da cor {color} no tabuleiro!");
            }
            foreach (ChessPiece x in Ingamepiece(adversaria(color)))
            {
                bool[,] mat = x.PosibleMov();
                if (mat[R.Position.Line, R.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }
        public bool testeXequemate(Color cor)
        {
            if (!estaEmXeque(cor))
            {
                return false;
            }
            foreach (ChessPiece x in Ingamepiece(cor))
            {
                bool[,] mat = x.PosibleMov();
                for (int i = 0; i < Tab.Lines; i++)
                {
                    for (int j = 0; j < Tab.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origem = x.Position;
                            Position destino = new Position(i, j);
                            ChessPiece pecaCapturada = ExeMoviment(origem, destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PutNewPiece(char column, int line, ChessPiece piece)//novo metodp para colocar as peças no tabuleiro, agora alem de seram onstanciadas serão guardadas em um conjunto chamado Pieces
        {
            Tab.ColocarPeca(piece, new ChessPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }
        private void ColocarPecas()//colocando as peças dentro da classe core
        {
            //brancas
            PutNewPiece('a', 1, new Rook(Tab, Color.White));
            PutNewPiece('b', 1, new Knight(Tab, Color.White));
            PutNewPiece('c', 1, new Bishop(Tab, Color.White));
            PutNewPiece('d', 1, new Queen(Tab, Color.White));
            PutNewPiece('e', 1, new King(Tab, Color.White, this));
            PutNewPiece('f', 1, new Bishop(Tab, Color.White));
            PutNewPiece('g', 1, new Knight(Tab, Color.White));
            PutNewPiece('h', 1, new Rook(Tab, Color.White));
            PutNewPiece('a', 2, new Pawn(Tab, Color.White, this));
            PutNewPiece('b', 2, new Pawn(Tab, Color.White, this));
            PutNewPiece('c', 2, new Pawn(Tab, Color.White, this));
            PutNewPiece('d', 2, new Pawn(Tab, Color.White, this));
            PutNewPiece('e', 2, new Pawn(Tab, Color.White, this));
            PutNewPiece('f', 2, new Pawn(Tab, Color.White, this));
            PutNewPiece('g', 2, new Pawn(Tab, Color.White, this));
            PutNewPiece('h', 2, new Pawn(Tab, Color.White, this));
            //pretas
            PutNewPiece('a', 8, new Rook(Tab, Color.Black));
            PutNewPiece('b', 8, new Knight(Tab, Color.Black));
            PutNewPiece('c', 8, new Bishop(Tab, Color.Black));
            PutNewPiece('d', 8, new Queen(Tab, Color.Black));
            PutNewPiece('e', 8, new King(Tab, Color.Black, this));
            PutNewPiece('f', 8, new Bishop(Tab, Color.Black));
            PutNewPiece('g', 8, new Knight(Tab, Color.Black));
            PutNewPiece('h', 8, new Rook(Tab, Color.Black));
            PutNewPiece('a', 7, new Pawn(Tab, Color.Black, this));
            PutNewPiece('b', 7, new Pawn(Tab, Color.Black, this));
            PutNewPiece('c', 7, new Pawn(Tab, Color.Black, this));
            PutNewPiece('d', 7, new Pawn(Tab, Color.Black, this));
            PutNewPiece('e', 7, new Pawn(Tab, Color.Black, this));
            PutNewPiece('f', 7, new Pawn(Tab, Color.Black, this));
            PutNewPiece('g', 7, new Pawn(Tab, Color.Black, this));
            PutNewPiece('h', 7, new Pawn(Tab, Color.Black, this));
        }
    }
}
