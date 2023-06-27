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
                try
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.Clear();
                    Screen.ImprimirTabuleiro(core.Tab);
                    Console.WriteLine();
                    Console.WriteLine("Turno" + core.Turn);
                    Console.WriteLine("Aguandando jogada :" + core.APlayer);


                    Console.WriteLine();
                    Console.Write("Origem ");
                    Position origin = Screen.ReadPosition().ToPosition();
                    core.ValidOriginPos(origin);

                    bool[,] possiblepos = core.Tab.Piece(origin).PosibleMov();

                    Console.Clear();
                    Screen.ImprimirTabuleiro(core.Tab, possiblepos);
                    Console.Write("Destino ");
                    Position destination = Screen.ReadPosition().ToPosition();
                    core.ValidDestinationPos(origin, destination);

                    core.ExePlay(origin, destination);
                }
                catch (TableException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            Console.ReadLine();
        }
        catch (TableException e)
        {
            Console.WriteLine(e.Message);
        }

    }
}