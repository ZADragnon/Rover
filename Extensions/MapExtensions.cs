using System;
using System.Linq;

using Rover.Enums;
using Rover.Interfaces;

using static System.Console;

namespace Rover.Extensions
{
    public static class MapExtension
    {
        public static IMap AddRover(this IMap map, int coordinateX, int coordinateY, Orientation orientation, string instructions)
        {
            map.Rovers.Add(new Implementations.Rover(coordinateX, coordinateY, orientation, instructions, map.Tiles.Max(x => x.X) + 1, map.Tiles.Max(x => x.Y) + 1));

            return map;
        }

        public static IMap Move(this IMap map)
        {
            map.Rovers.ToList().ForEach(rover => rover.Move());

            return map;
        }

        public static IMap Results(this IMap map)
        {
            WriteLine($"{Environment.NewLine}{map.ToString()}");
            map.Rovers.ToList().ForEach(rover => WriteLine($"{Environment.NewLine}{rover.ToString()}"));

            return map;
        }
    }
}
