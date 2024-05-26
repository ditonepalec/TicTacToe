using System;
using System.Windows.Forms;
using System.Drawing;
using TicTacToeCC;

namespace TicTacToeCC
{
    public partial class Form1 : Form
    {
        private Game _game;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            Player player1 = new Player("Player 1", 'X');
            Player player2 = new Player("Player 2", 'O');
            _game = new Game(player1, player2);
            InitializeBoard();
            UpdateBoard();
        }

        private void InitializeBoard()
        {
            tableLayoutPanel1.Controls.Clear(); 
            for (int i = 0; i < Board.Size; i++)
            {
                for (int j = 0; j < Board.Size; j++)
                {
                    var button = new BoardElement(i, j)
                    {
                        Dock = DockStyle.Fill,
                        Font = new Font("Microsoft Sans Serif", 24F),
                        Text = string.Empty
                    };
                    button.Click += ButtonClick;
                    tableLayoutPanel1.Controls.Add(button, j, i);
                }
            }
        }

        private void UpdateBoard()
        {
            for (int i = 0; i < Board.Size; i++)
            {
                for (int j = 0; j < Board.Size; j++)
                {
                    BoardElement button = (BoardElement)tableLayoutPanel1.GetControlFromPosition(j, i);
                    button.Text = _game.GetSymbolAt(i, j).ToString();
                }
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            BoardElement button = sender as BoardElement;
            int row = button.Row;
            int col = button.Column;

            if (_game.MakeMove(row, col))
            {
                UpdateBoard();

                if (_game.CheckWin())
                {
                    MessageBox.Show($"{_game.CurrentPlayer.Name} Переміг!");
                    InitializeGame();
                }
                else if (_game.IsDraw())
                {
                    MessageBox.Show("Нiчия!");
                    InitializeGame();
                }
                else
                {
                    _game.SwitchPlayer();
                }
            }
        }
    }
}
