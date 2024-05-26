using System;


namespace TicTacToeCC
{
    public class Game
    {
        private Board _board;
        private Player _player1;
        private Player _player2;
        private Player _currentPlayer;

        public Game(Player player1, Player player2)
        {
            _board = new Board();
            _player1 = player1;
            _player2 = player2;
            _currentPlayer = _player1;
        }

        public Player CurrentPlayer => _currentPlayer;

        public bool MakeMove(int row, int col)
        {
            return _board.PlaceSymbol(row, col, _currentPlayer.Symbol);
        }

        public bool CheckWin()
        {
            return _board.CheckWin(_currentPlayer.Symbol);
        }

        public bool IsDraw()
        {
            return _board.IsFull() && !CheckWin();
        }

        public void SwitchPlayer()
        {
            _currentPlayer = _currentPlayer == _player1 ? _player2 : _player1;
        }

        public char GetSymbolAt(int row, int col)
        {
            return _board.GetSymbolAt(row, col);
        }
    }


}
