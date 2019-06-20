using System;
using Battleship;
using Xunit;

namespace UnitTestBattleship
{
    public class UnitTest
    {
        [Fact]
        public void TestIsSunk()
        {
            var ship = new Ship(3,2,4,Orientation.Vertical);
            ship.ShipCoordinate[0].Status = CellType.Hit;
            ship.ShipCoordinate[1].Status = CellType.Hit;
            ship.ShipCoordinate[2].Status = CellType.Hit;

            Assert.False(ship.IsSunk());

            ship.ShipCoordinate[3].Status = CellType.Hit;

            Assert.True(ship.IsSunk());
        }

        [Fact]
        public void TestAddShip()
        {
            var player = new Player(new Board());

            Assert.True(player.AddShip(3, 2, 4, Orientation.Vertical));
            Assert.False(player.AddShip(5, 5, 6, Orientation.Vertical));
            Assert.False(player.AddShip(1, 5, 3, Orientation.Horizontal));
        }


        [Fact]
        public void TestFire()
        {
            var player = new Player(new Board());

            player.AddShip(3, 2, 4, Orientation.Vertical);

            Assert.Equal(CellType.Miss, player.Fire(4,3));

            Assert.Equal(CellType.Miss, player.Fire(3, 1));
            
            Assert.Equal(CellType.Hit, player.Fire(3, 5));
        }

        [Fact]
        public void TestIsLost()
        {
            var player = new Player(new Board());

            player.AddShip(3, 2, 4, Orientation.Vertical);
            player.Fire(3, 2);
            player.Fire(3, 3);
            player.Fire(3, 4);
            Assert.False(player.IsLost);
            player.Fire(3, 5);
            Assert.True(player.IsLost);
        }
    }
}
