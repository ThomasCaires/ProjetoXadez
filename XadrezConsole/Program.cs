using Chess;
using Tabuleiro;
using XadrezConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            ChessCore core = new ChessCore();

            while (!core.Over)
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.Clear();
                Screen.ImprimirTabuleiro(core.Tab);

                Console.WriteLine();
                Console.Write("Origem ");
                Position origin = Screen.ReadPosition().ToPosition();
  
                bool[,] possiblepos = core.Tab.Piece(origin).PosibleMov();

                Console.Clear();
                Screen.ImprimirTabuleiro(core.Tab, possiblepos);
                Console.Write("Destino ");
                Position destination = Screen.ReadPosition().ToPosition();

                core.ExeMoviment(origin, destination);
            }
            Console.ReadLine();
        }
        catch (TableException e)
        {
            Console.WriteLine(e.Message);
        }

    }
}