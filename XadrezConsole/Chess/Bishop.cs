using Tabuleiro;

namespace Chess
{
    internal class Bishop : ChessPiece
    {
        public Bishop(Table tab, Color color) : base(tab, color)
        {
        }
        public override string ToString()
        {
            return "B";
        }
        private bool CanMove(Position pos)//verificando se pode mover
        {
            ChessPiece p = Tab.Piece(pos);
            return p == null || p.Color != Color;
        }
        public override bool[,] PosibleMov()//movimentos do bispo
        {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];//criando matriz de movimento da peça BISPO

            Position pos = new Position(0, 0);

            //Diagonal direita para baixo
            pos.DefinirValores(Position.Line + 1, Position.Column + 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))//verificando se posiçao acima esta livre
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line++;
                pos.Column++;
            }
            //Diagonal direita para cima
            pos.DefinirValores(Position.Line + 1, Position.Column - 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))//verificando se posiçao acima esta livre
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line++;
                pos.Column--;
            }
            //Diagonal esquerda para cima
            pos.DefinirValores(Position.Line - 1, Position.Column - 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))//verificando se posiçao acima esta livre
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line--;
                pos.Column--;
            }
            //Diagonal direita para baixo
            pos.DefinirValores(Position.Line - 1, Position.Column + 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))//verificando se posiçao acima esta livre
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line--;
                pos.Column++;
            }
            return mat;
        }
    }
}
