using Tabuleiro;
using XadrezConsole;


internal class Program
{
    private static void Main(string[] args)
    {

        Table tab = new Table(8, 8);
        Screen.ImprimirTabuleiro(tab);
        Console.ReadLine();
    }
}