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
    }
}
