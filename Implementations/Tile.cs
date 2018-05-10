using Rover.Interfaces;

namespace Rover.Implementations
{
    public class Tile : ITile
    {
        private int _x;
        private int _y;

        public Tile(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        public int X => this._x;

        public int Y => this._y;
    }
}
