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
    }
}
