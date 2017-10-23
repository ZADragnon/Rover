﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

using Rover.Interface;

namespace Rover.Implementation
{
    public class Map : IMap
    {
        public Map()
        {
            Tiles = new List<ITile>();
            Rovers = new List<IRover>();
        }

        public IList<ITile> Tiles { get; set; }

        public IList<IRover> Rovers { get; set; }

        public void Move() => Rovers.ToList().ForEach(rover => rover.Move());

        #region Overrides

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            int maxX = Tiles.Any() ? Tiles.Max(x => x.X) : 1;
            int maxY = Tiles.Any() ? Tiles.Max(x => x.Y) : 1;

            for (int i = 0; i < maxY; i++)
            {
                stringBuilder.AppendLine(new string('#', maxX));
            }

            return stringBuilder.ToString();
        }

        #endregion
    }
}
