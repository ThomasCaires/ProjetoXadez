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
                Console.Clear();
                Screen.ImprimirTabuleiro(core.Tab);
                
                Console.Write("origem ");
                Position origin = Screen.ReadPosition().ToPosition();
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