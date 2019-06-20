using System.Collections.Generic;

namespace Battleship
{
    public class Board
    {
        public List<Cell> Cells { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Board(int rows = 10, int columns = 10)
        {
            Cells = new List<Cell>();
            for (var i = 1; i <= rows; i++)
            {
                for (var j = 1; j <= columns; j++)
                {
                    Cells.Add(new Cell(i,j));
                }
            }
        }
    }
}
