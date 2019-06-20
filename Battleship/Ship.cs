using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace Battleship
{
    public class Ship
    {
        /// <summary>
        /// Ship coordinates
        /// </summary>
        public readonly List<Cell> ShipCoordinate = new List<Cell>();

        /// <summary>
        /// creates the ship instance/
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="length"></param>
        /// <param name="orient"></param>
        public Ship(int x, int y, int length, Orientation orient)
        {
            for (var i = 0; i < length; i++)
            {
                ShipCoordinate.Add(new Cell(orient == Orientation.Horizontal ? x + i : x,
                    orient == Orientation.Vertical ? y + i : y) {Status = CellType.Battleship});
            }
        }

        /// <summary>
        /// Check the ship is sunk.
        /// </summary>
        /// <returns></returns>
        public bool IsSunk() => ShipCoordinate.TrueForAll(x => x.Status == CellType.Hit);

        /// <summary>
        /// check the ship has specified coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool HasPoint(int x, int y) => ShipCoordinate.Any(ship => ship.Coordinate.Row == x && ship.Coordinate.Column == y);
    }
}
