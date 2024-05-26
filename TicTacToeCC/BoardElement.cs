using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace TicTacToeCC
{
    public class BoardElement : Button 
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public BoardElement(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
