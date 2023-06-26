﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                for (int j = 0; j < tab.Columns; j++)
                {
                    if (tab.Piece(i, j) == null)//testendo se não tem nenhuma peça na posição
                    {
                        Console.Write("- ");
                    }
                    else //caso a posiçao nao seja nula a peça sera impressa
                    {
                        Console.Write(tab.Piece(i,j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}