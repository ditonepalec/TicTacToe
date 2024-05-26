using System;


namespace TicTacToeCC
{
    public class Board
    {
        private char[,] _board;
        public const int Size = 3;

        public Board()
        {
            _board = new char[Size, Size];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    _board[i, j] = ' ';
                }
            }
        }

        public bool PlaceSymbol(int row, int col, char symbol)
        {
            if (_board[row, col] == ' ')
            {
                _board[row, col] = symbol;
                return true;
            }
            return false;
        }

        public bool CheckWin(char symbol)
        {
            for (int i = 0; i < Size; i++)
            {
                if ((_board[i, 0] == symbol && _board[i, 1] == symbol && _board[i, 2] == symbol) ||
                    (_board[0, i] == symbol && _board[1, i] == symbol && _board[2, i] == symbol))
                {
                    return true;
                }
            }
            if ((_board[0, 0] == symbol && _board[1, 1] == symbol && _board[2, 2] == symbol) ||
                (_board[0, 2] == symbol && _board[1, 1] == symbol && _board[2, 0] == symbol))
            {
                return true;
            }
            return false;
        }

        public bool IsFull()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (_board[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public char GetSymbolAt(int row, int col)
        {
            return _board[row, col];
        }
    }

}
