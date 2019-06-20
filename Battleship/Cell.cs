using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    /// <summary>
    /// Represents the cell information for the coordinates.
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// The coordinates of the cell
        /// </summary>
        public (int Row, int Column) Coordinate { get; set; }
        /// <summary>
        /// Gets the Cell Status
        /// </summary>
        public CellType Status { get; set; }
        /// <summary>
        /// Creates the instance of cell.
        /// </summary>
        /// <param name="x">row</param>
        /// <param name="y">column</param>
        public Cell(int x,int y)
        {
            Coordinate = (x, y);
            Status = CellType.Empty;
        }
    }
}
