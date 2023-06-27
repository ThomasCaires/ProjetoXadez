using Tabuleiro;

namespace Chess
{
    internal class Queen : ChessPiece
    {
        public Queen(Table tab, Color color) : base(tab, color)
        {
        }
        public override string ToString()
        {
            return "Q";
        }
        private bool CanMove(Position pos)//verificando se pode mover
        {
            ChessPiece p = Tab.Piece(pos);
            return p == null || p.Color != Color;
        }
        public override bool[,] PosibleMov()//movimentos da rainha
        {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];//criando matriz de movimento da peça RAINHA

            Position pos = new Position(0, 0);

            //Acima
            pos.DefinirValores(Position.Line - 1, Position.Column);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line--;
            }
            //Diagonal direita acima
            pos.DefinirValores(Position.Line - 1, Position.Column + 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line--;
                pos.Column++;
            }
            //Diagonal esquerda acima
            pos.DefinirValores(Position.Line - 1, Position.Column - 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line--;
                pos.Column++;
            }
            //Esquerda
            pos.DefinirValores(Position.Line, Position.Column - 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column--;
            }
            //Direita
            pos.DefinirValores(Position.Line, Position.Column + 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column++;
            }
            //Abaixo
            pos.DefinirValores(Position.Line + 1, Position.Column);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line++;
            }
            //Diagonal esquerda abaixo
            pos.DefinirValores(Position.Line + 1, Position.Column + 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line++;
                pos.Column++;
            }
            //Diagonal direita abaixo
            pos.DefinirValores(Position.Line + 1, Position.Column - 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line++;
                pos.Column--;
            }
            return mat;
        }

    }
}

