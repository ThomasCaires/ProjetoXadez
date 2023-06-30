using Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Tabuleiro;

namespace XadrezConsole
{
    class Screen
    {

        public static void ImprimirPartida(ChessCore game) //metodo melhorado para imprimir a partida
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;            
            Screen.ImprimirTabuleiro(game.Tab);
            PrintCapturedPieces(game);
            Console.WriteLine();
            Console.WriteLine("Turno" + game.Turn);
            if (!game.Over)
            {


                Console.WriteLine("Aguandando jogada :" + game.APlayer);
                if (game.xeque)
                {
                    Console.WriteLine("XEQUE");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE");
                    Console.WriteLine($"VENCEDOR: {game.APlayer}");
            }
        }
        public static void PrintCapturedPieces(ChessCore game)
        {
            Console.WriteLine("Peças capturadas");
            Console.Write("Brancas: ");
            Printh(game.Capturedpieces(Color.White));
            Console.WriteLine();
            Console.Write("Pretas: ");
            Printh(game.Capturedpieces(Color.Black));
            Console.WriteLine();
        }
        public static void Printh(HashSet<ChessPiece> group)
        {
            Console.Write("[");
            foreach (ChessPiece item in group)
            {
                Console.Write(item + " ");
            }
            Console.Write("]");
        }
        public static void ImprimirTabuleiro(Table tab) //imprime o tabuleiro na tela
        {
            for (int i = 0; i < tab.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Columns; j++)
                {
                    ImprimirPeca(tab.Piece(i, j));//chamando metodo para imrimir tela
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void ImprimirTabuleiro(Table tab, bool[,] PosiblePos) //imprime o tabuleiro na tela
        {
            ConsoleColor Def = Console.BackgroundColor;
            ConsoleColor Alt = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Columns; j++)
                {
                    if (PosiblePos[i, j] == true)
                    {
                        Console.BackgroundColor = Alt;
                    }
                    else
                    {
                        Console.BackgroundColor = Def;
                    }
                    ImprimirPeca(tab.Piece(i, j));//chamando metodo para imrimir tela
                    Console.BackgroundColor = Def;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = Def;
        }
        public static ChessPosition ReadPosition()//metodo para ler a posiçao desejada
        {
            string s = Console.ReadLine();
            char c = s[0];
            int l = int.Parse(s[1] + "");//forçando int l a ser uma string
            return new ChessPosition(c, l);
        }
        public static void ImprimirPeca(ChessPiece Piece)
        {
            if (Piece == null)//testendo se não tem nenhuma peça na posição
            {
                Console.Write("- ");
            }
            else
            {
                if (Piece.Color == Color.White)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(Piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;//tipo que muda a cor do terminal
                    Console.ForegroundColor = ConsoleColor.Black;//definindo a cor das peças pretas como vermelho
                    Console.Write(Piece);
                    Console.ForegroundColor = aux;//voltando para cor original
                }
                Console.Write(" ");
            }
        }
    }
}
