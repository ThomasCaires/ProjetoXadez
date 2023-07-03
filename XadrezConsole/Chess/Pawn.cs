using System.Runtime.ConstrainedExecution;
using Tabuleiro;

namespace Chess
{
    internal class Pawn : ChessPiece
    {
        public Pawn(Table Tab, Color color) : base(Tab, color)
        {
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
                        mat[pos.Line, pos.Column] = true;
                    }
                    pos.DefinirValores(Position.Line + 1, Position.Column + 1);
                    if (Tab.ValidPosition(pos) && existeInimigo(pos))
                    {
                        mat[pos.Line, pos.Column] = true;
                    }
                }
            }
            return mat;
        }
    }
}