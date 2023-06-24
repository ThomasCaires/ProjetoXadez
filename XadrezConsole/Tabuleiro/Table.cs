using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XadrezConsole.Tabuleiro
{
    internal class Table
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private ChessPiece[,] Pieces { get; set; }

        public Table(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new ChessPiece[lines, columns];
        }
    }
}
