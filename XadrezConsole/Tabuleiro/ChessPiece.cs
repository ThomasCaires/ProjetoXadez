namespace Tabuleiro
{
    abstract class ChessPiece//Peça de xadrez
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Table Tab { get; protected set; }

        //Construtor principal da classe
        public ChessPiece(Table tab, Color color)
        {
            Position = null!;//position nao sera nulo mas iniciara nulo
            Tab = tab;
            Color = color;
            this.QteMovimentos = 0;
        }
        public void InclementMoviment()
        {
            QteMovimentos++;
        }
        public bool ExistMove()
        {
            bool[,] mat = PosibleMov();
            for (int i = 0; i < Tab.Lines; i++)
            {
                for (int j = 0; j < Tab.Lines; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool CanMoveTo(Position pos)
        {
            return PosibleMov()[pos.Line,pos.Column];
        }
        public abstract bool[,] PosibleMov();
    }
}
