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
    }
}
