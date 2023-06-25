using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tabuleiro
{
    internal class Table
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        public ChessPiece[,] Pieces; //Criando matriz private do tipo ChessPiece 

        //Construor principal da classe
        public Table(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new ChessPiece[lines, columns];//Pieces recebe a propia matriz Pieces
        }
        //metodo public para permitir o acesso da matriz Pieces por outras classes
        public ChessPiece Piece (int line, int column)//metodo Piece "Peça" para retornar posiçao da peça individualmente
        {
            return Pieces[line, column];
        }
    }
}
