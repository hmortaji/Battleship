using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
    public static class Extensions
    {
        /// <summary>
        /// Gets the cell at specific coordinates.
        /// </summary>
        /// <param name="panels"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static Cell At(this List<Cell> panels, int row, int column)
        {
            return panels.First(x => x.Coordinate.Row == row && x.Coordinate.Column == column);
        }

        /// <summary>
        /// Check the cells whether is empty or not.
        /// </summary>
        /// <param name="panels"></param>
        /// <param name="x">orw</param>
        /// <param name="y">column</param>
        /// <param name="length">length of ship</param>
        /// <param name="orient">orientation</param>
        /// <returns></returns>
        public static bool IsSea(this List<Cell> panels, int x, int y, int length, Orientation orient)
        {
            for (var i = 0; i < length; i++)
            {
                if (panels.At((orient == Orientation.Horizontal) ? x + i : x,
                        orient == Orientation.Vertical ? y + i : y).Status !=
                    CellType.Empty) return false;
            }

            return true;
        }
    }
}
