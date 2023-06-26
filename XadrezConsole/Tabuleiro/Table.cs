using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

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
        public ChessPiece Piece(int line, int column)//metodo Piece "Peça" para retornar posiçao da peça individualmente
        {
            return Pieces[line, column];
        }
        public ChessPiece Piece(Position pos)//sobrecarga para que a classe Table receba Position como argumento
        {
            //LEMBRETE:pode remover a função "ValidingPosition" colocando o bloco if antes de retornar Pieces
            return Pieces[pos.Line, pos.Column];
        }
        public bool PieceHere(Position pos)//testando se existe uma peça nesta posição
        {
            ValidingPosition(pos);//validando a posiçao pos
            return Piece(pos) != null;
        }
        public void ColocarPeca(ChessPiece p, Position pos)
        {
            if (PieceHere(pos))
            {
                throw new TableException("Existe uma peça na posição");
            }
            Pieces[pos.Line, pos.Column] = p;//colocando peça p na matriz de peças na posiçao desejada
            p.Position = pos;
        }
        public bool ValidPosition(Position pos)//testando se a posiçao é valida
        {
            if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
            {
                return false;
            }//como return corta o metodo nao ha necessidade do else
            return true;
        }
        public void ValidingPosition(Position pos)//retorna se a posiçao for invalida
        {
            if (!ValidPosition(pos))
            {
                throw new TableException("Posiçao invalida");
            }
        }

    }
}
