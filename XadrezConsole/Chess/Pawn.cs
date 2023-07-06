using System.Runtime.ConstrainedExecution;
using Tabuleiro;

namespace Chess
{
    internal class Pawn : ChessPiece
    {
        private ChessCore Core;
        public Pawn(Table Tab, Color color, ChessCore core) : base(Tab, color)
        {
            Core = core;
        }
        public override string ToString()
        {
            return "P";
        }
        private bool CanMove(Position pos)//verificando se pode mover
        {
            ChessPiece p = Tab.Piece(pos);
            return p == null || p.Color != Color;
        }
        private bool existeInimigo(Position pos)
        {
            ChessPiece p = Tab.Piece(pos);
            return p != null && p.Color != Color;
        }

        private bool livre(Position pos)
        {
            return Tab.Piece(pos) == null;
        }

        public override bool[,] PosibleMov()
        {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];
            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.DefinirValores(Position.Line - 1, Position.Column);
                if (Tab.ValidPosition(pos) && livre(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefinirValores(Position.Line - 2, Position.Column);
                Position p2 = new Position(Position.Line - 1, Position.Column);
                if (Tab.ValidPosition(p2) && livre(p2) && Tab.ValidPosition(pos) && livre(pos) && QteMovimentos == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefinirValores(Position.Line - 1, Position.Column - 1);
                if (Tab.ValidPosition(pos) && existeInimigo(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefinirValores(Position.Line - 1, Position.Column + 1);
                if (Tab.ValidPosition(pos) && existeInimigo(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                //En Passant
                if (Position.Line == 3)
                {
                    Position esquerda = new Position(Position.Line, Position.Column - 1);
                    if (Tab.ValidPosition(esquerda) && existeInimigo(esquerda) && Tab.Piece(esquerda) == Core.Vulneravelenpassant)
                    {
                        mat[esquerda.Line, esquerda.Column] = true;
                    }
                    Position direita = new Position(Position.Line, Position.Column + 1);
                    if (Tab.ValidPosition(direita) && existeInimigo(direita) && Tab.Piece(direita) == Core.Vulneravelenpassant)
                    {
                        mat[direita.Line, direita.Column] = true;
                    }
                }
            }
            else
            {
                pos.DefinirValores(Position.Line + 1, Position.Column);
                if (Tab.ValidPosition(pos) && livre(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefinirValores(Position.Line + 2, Position.Column);
                Position p = new Position(Position.Line + 1, Position.Column);
                if (Tab.ValidPosition(p) && livre(p) && Tab.ValidPosition(pos) && livre(pos) && QteMovimentos == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefinirValores(Position.Line + 1, Position.Column - 1);
                if (Tab.ValidPosition(pos) && existeInimigo(pos))
                {
                    mat[pos.Line - 1, pos.Column] = true;
                }
                pos.DefinirValores(Position.Line + 1, Position.Column + 1);
                if (Tab.ValidPosition(pos) && existeInimigo(pos))
                {
                    mat[pos.Line - 1, pos.Column] = true;
                }
                //En Passant
                if (Position.Line == 4)
                {
                    Position esquerda = new Position(Position.Line, Position.Column - 1);
                    if (Tab.ValidPosition(esquerda) && existeInimigo(esquerda) && Tab.Piece(esquerda) == Core.Vulneravelenpassant)
                    {
                        mat[esquerda.Line + 1, esquerda.Column] = true;
                    }
                    Position direita = new Position(Position.Line, Position.Column + 1);
                    if (Tab.ValidPosition(direita) && existeInimigo(direita) && Tab.Piece(direita) == Core.Vulneravelenpassant)
                    {
                        mat[direita.Line + 1, direita.Column] = true;
                    }
                }
            }
            return mat;
        }

    }
}
