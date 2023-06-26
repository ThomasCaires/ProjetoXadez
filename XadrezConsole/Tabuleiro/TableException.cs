using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabuleiro
{
    internal class TableException : Exception
    {
        public TableException() { }
        public TableException(string msg) : base(msg)
        {
        }
    }
}
