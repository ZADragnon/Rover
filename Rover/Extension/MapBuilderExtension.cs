﻿using Rover.Builder;
using Rover.Implementation;
using Rover.Interface;

namespace Rover.Extension
{
    public static class MapBuilderExtension
    {
        public static MapBuilder SetCoordinates(this MapBuilder mapBuilder, int maxRightCoordinate, int maxUpperCoordinate)
        {
            mapBuilder.X = maxRightCoordinate;
            mapBuilder.Y = maxUpperCoordinate;
            return mapBuilder;
        }

        public static IMap BuildMap(this MapBuilder mapBuilder)
        {
            int width = mapBuilder.X > 0 ? mapBuilder.X : 0;
            int height = mapBuilder.Y > 0 ? mapBuilder.Y : 0;

            // Create Tiles and Map
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    mapBuilder.Map.Tiles.Add(new Tile { X = x, Y = y });
                }
            }

            return mapBuilder.Map;
        }
    }
}
