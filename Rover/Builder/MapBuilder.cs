using Rover.Implementation;
using Rover.Interface;

namespace Rover.Builder
{
    public class MapBuilder : ITile
    {
        #region Variables

        private int _x = 0;
        private int _y = 0;
        private IMap _map;

        #endregion

        #region Constructors

        public MapBuilder() : this(0, 0)
        { }

        public MapBuilder(int maxRightCoordinate, int maxUpperCoordinate)
        {
            X = maxRightCoordinate;
            Y = maxUpperCoordinate;
            Map = new Map();
        }

        #endregion

        #region Properties

        public int X { get => _x; set => _x = value; }

        public int Y { get => _y; set => _y = value; }

        public IMap Map { get => _map; protected set => _map = value; }

        #endregion
    }
}
