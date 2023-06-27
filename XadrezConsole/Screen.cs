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
