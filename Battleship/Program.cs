using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Battleship
{
    public class Program
    {
        static void Main(string[] args)
        {
            var player = new Player(new Board());

            player.AddShip(1, 1, 3, Orientation.Vertical);

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Attack Position:");
                    var data = Console.ReadLine()?.Split(',');
                    var result = player.Fire(int.Parse(data[0]), int.Parse(data[1]));

                    Console.WriteLine(result);

                    if (!player.IsLost) continue;
                    Console.WriteLine("Game Over!");
                    break;
                }
                catch
                {
                    Console.WriteLine("Wrong Input");
                }
            }
        }
    }
}
