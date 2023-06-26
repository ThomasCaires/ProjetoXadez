using Tabuleiro;

namespace Chess
{
    internal class Pawn : ChessPiece
    {
        public Pawn(Table tab, Color color) : base(tab, color)
        {   
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
