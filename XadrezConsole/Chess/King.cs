using Tabuleiro;

namespace Chess
{
    internal class King : ChessPiece
    {
        public King(Table tab, Color color) : base(tab, color)
        {
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
        public override bool[,] PosibleMov()//movimentos do rei
        {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];//criando matriz de movimento da peça REI

            Position pos = new Position(0, 0);

            //Acima
            pos.DefinirValores(Position.Line - 1, Position.Column);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line,pos.Column] = true;
            }
            //Diagonal direita acima
            pos.DefinirValores(Position.Line -1, Position.Column + 1);
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
            pos.DefinirValores(Position.Line +1 , Position.Column);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Diagonal esquerda abaixo
            pos.DefinirValores(Position.Line +1, Position.Column + 1);
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
            return mat;
        }

    }
}
