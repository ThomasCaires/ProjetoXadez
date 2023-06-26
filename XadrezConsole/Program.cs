using Chess;
using Tabuleiro;
using XadrezConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        ChessPosition pos = new ChessPosition('b', 8);
        Console.WriteLine(pos);
        Console.WriteLine(pos.toPosition());
    }
}