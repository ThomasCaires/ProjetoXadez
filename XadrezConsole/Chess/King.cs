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
    }
}
