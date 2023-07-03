using Tabuleiro;

namespace Chess
{
    internal class Knight : ChessPiece
    {
        public Knight(Table tab, Color color) : base(tab, color)
        {
        }
        public override string ToString()
        {
            return "C";
        }
        private bool CanMove(Position pos)//verificando se pode mover
        {
            ChessPiece p = Tab.Piece(pos);
            return p == null || p.Color != Color;
        }
        public override bool[,] PosibleMov()//movimentos do cavalo
        {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];

            Position pos = new Position(0, 0);

            //Acima
            pos.DefinirValores(Position.Line - 1, Position.Column - 2);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Diagonal direita acima
            pos.DefinirValores(Position.Line - 2, Position.Column - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Diagonal esquerda acima
            pos.DefinirValores(Position.Line - 2, Position.Column + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Esquerda
            pos.DefinirValores(Position.Line - 1, Position.Column + 2);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Direita
            pos.DefinirValores(Position.Line + 1, Position.Column + 2);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Abaixo
            pos.DefinirValores(Position.Line + 2, Position.Column + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Diagonal esquerda abaixo
            pos.DefinirValores(Position.Line + 2, Position.Column - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Diagonal direita abaixo
            pos.DefinirValores(Position.Line + 1, Position.Column - 2);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            return mat;
        }
    }
}
