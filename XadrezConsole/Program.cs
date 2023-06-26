using Chess;
using Tabuleiro;
using XadrezConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        Table tab = new Table(8, 8);

        tab.ColocarPeca(new Rook(tab, Color.Black), new Position(0, 0));
        tab.ColocarPeca(new Rook(tab, Color.Black), new Position(0, 3));
        tab.ColocarPeca(new King(tab, Color.Black), new Position(1, 0));

        Screen.ImprimirTabuleiro(tab);
        Console.ReadLine();

    }
}