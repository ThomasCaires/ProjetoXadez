namespace Tabuleiro
{
    internal class ChessPiece//Peça de xadrez
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
    }
}
