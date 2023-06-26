using Chess;
using Tabuleiro;
using XadrezConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Table tab = new Table (8, 8);

            tab.ColocarPeca(new Rook(tab, Color.Black), new Position(9, 0));
            tab.ColocarPeca(new Rook(tab, Color.Black), new Position(3, 3));
            tab.ColocarPeca(new King(tab, Color.Black), new Position(3, 3));

            Screen.ImprimirTabuleiro(tab);
            Console.ReadLine();
        }
        catch (TableException e) {
            Console.WriteLine(e.Message);
        }

    }
}