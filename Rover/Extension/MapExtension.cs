using System.Linq;

using Rover.Enum;
using Rover.Interface;

namespace Rover.Extension
{
    public static class MapExtension
    {
        public static IMap AddRover(this IMap map, int coordinateX, int coordinateY, Orientation orientation, string instructions)
        {
            map.Rovers.Add(new Implementation.Rover(coordinateX, coordinateY, orientation, instructions, map.Tiles.Max(x => x.X), map.Tiles.Max(x => x.Y)));

            return map;
        }
    }
}
