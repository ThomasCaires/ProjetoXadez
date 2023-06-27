using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabuleiro
{
    internal class Position
    {
        public int Line{ get; set; }
        public int Column { get; set; }

        //Construtor principal da classe
        public Position(int linha, int column)
        {
            Line = linha;
            Column = column;
        }
        public void DefinirValores(int linha, int column)
        {
            Line = linha;
            Column = column;
        }
    public override string ToString()
        {
            return Line + ", " + Column;
        }

    }
}

