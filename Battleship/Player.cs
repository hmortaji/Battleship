using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
    public class Player
    {
        /// <summary>
        /// List of player ships
        /// </summary>
        private List<Ship> Ships { get; } = new List<Ship>();

        /// <summary>
        /// The master game board.
        /// </summary>
        private readonly Board _board;

        /// <summary>
        /// Gets whether the player is lost.
        /// </summary>
        public bool IsLost => Ships.TrueForAll(x => x.IsSunk());

        /// <summary>
        /// Creates the instance of player.
        /// </summary>
        /// <param name="board"></param>
        public Player(Board board)
        {
            _board = board;
        }

        /// <summary>
        /// Adds a ship into the board.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="length"></param>
        /// <param name="orient"></param>
        /// <returns></returns>
        public bool AddShip(int x, int y, int length, Orientation orient)
        {
            switch (orient)
            {
                case Orientation.Horizontal when x + length > 9:
                case Orientation.Vertical when y + length > 9:
                    return false;
            }
            // Check free cells
            if (!_board.Cells.IsSea(x, y, length, orient)) return false;
            // add ship to client
            Ships.Add(new Ship(x, y, length, orient));
            // update master board cells
            for (var i = 0; i < length; i++)
            {
                _board.Cells.At(orient == Orientation.Horizontal ? x + i : x,
                    orient == Orientation.Vertical ? y + i : y).Status = CellType.Battleship;
            }

            return true;
        }

        /// <summary>
        /// Attack to specific coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public CellType Fire(int x, int y)
        {
            var ship = _board.Cells.At(x, y);
            if (ship.Status != CellType.Battleship)
            {
                ship.Status = CellType.Miss;
                return CellType.Miss;
            }
            
            Ships.First(item => item.HasPoint(x, y)).ShipCoordinate.First(item => item.Coordinate == (x, y)).Status = CellType.Hit;

            return CellType.Hit;
        }
    }
}
