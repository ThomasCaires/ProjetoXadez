using Tabuleiro;

namespace Chess
{
    internal class Rook : ChessPiece
    {
        public Rook(Table tab, Color color) : base(tab, color)
        {
        }
        public override string ToString()
        {
            return "T";
        }
        private bool CanMove(Position pos)//verificando se pode mover
        {
            ChessPiece p = Tab.Piece(pos);
            return p == null || p.Color != Color;
        }
        public override bool[,] PosibleMov()//movimentos da torre
        {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];//criando matriz de movimento da peça TORRE

            Position pos = new Position(0, 0);

            //Acima
            pos.DefinirValores(Position.Line - 1, Position.Column);
            while (Tab.ValidPosition(pos) && CanMove(pos))//verificando se posiçao acima esta livre
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Piece(pos)!=null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line --;//toda vez que voltar para o while inclemeta menos 1 linha
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
                pos.Line ++;
            }
            //Esquerda
            pos.DefinirValores(Position.Line, Position.Column -1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Piece(pos) != null && Tab.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column --;
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
                pos.Column ++;
            }

            return mat;
        }
    }
}
