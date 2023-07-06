using Tabuleiro;

namespace Chess
{
    internal class King : ChessPiece
    {
        private ChessCore Core;
        public King(Table tab, Color color, ChessCore core) : base(tab, color)
        {
            Core = core;
        }
        public override string ToString()
        {
            return "R";
        }
        private bool CanMove(Position pos)//verificando se pode mover
        {
            ChessPiece p = Tab.Piece(pos);
            return p == null || p.Color != Color;
        }
        private bool TesteRoque(Position position)
        {
            ChessPiece piece = Tab.Piece(position);
            return piece != null && piece is Rook && piece.Color == Color && piece.QteMovimentos == 0;
        }
        public override bool[,] PosibleMov()//movimentos do rei
        {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];//criando matriz de movimento da peça REI

            Position pos = new Position(0, 0);

            //Acima
            pos.DefinirValores(Position.Line - 1, Position.Column);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Diagonal direita acima
            pos.DefinirValores(Position.Line - 1, Position.Column + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Diagonal esquerda acima
            pos.DefinirValores(Position.Line - 1, Position.Column - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Esquerda
            pos.DefinirValores(Position.Line, Position.Column - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Direita
            pos.DefinirValores(Position.Line, Position.Column + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Abaixo
            pos.DefinirValores(Position.Line + 1, Position.Column);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Diagonal esquerda abaixo
            pos.DefinirValores(Position.Line + 1, Position.Column + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Diagonal direita abaixo
            pos.DefinirValores(Position.Line + 1, Position.Column - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Roque
            if (QteMovimentos == 0 && !Core.xeque)
            {
                //Roque pequeno
                Position post1 = new Position(Position.Line, Position.Column + 3);
                if (TesteRoque(post1))
                {
                    Position p1=new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);
                    if(Tab.Piece(p1)==null && Tab.Piece(p2) == null)
                    {
                        mat[Position.Line, Position.Column +2] = true;
                    }
                }
                //Roque grande
                Position post2 = new Position(Position.Line, Position.Column - 4);
                if (TesteRoque(post2))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column -2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);

                    if (Tab.Piece(p1) == null && Tab.Piece(p2) == null&& Tab.Piece(p3)==null)
                    {
                        mat[Position.Line, Position.Column - 2] = true;
                    }
                }
            }
            return mat;
        }

    }
}
