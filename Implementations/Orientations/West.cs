using Rover.Enums;
using Rover.Interfaces;

namespace Rover.Implementations.Orientations
{
    public class West : IPosition
    {
        private int _x;
        private int _y;
        private int _maxX;
        private int _maxY;

        public West(int x, int y, int maxX, int maxY)
        {
            this._x = x;
            this._y = y;
            this._maxX = maxX;
            this._maxY = maxY;
        }

        public int X => this._x;
        public int Y => this._y;

        public IPosition Move(Command instruction)
        {
            if (instruction == Command.L)
                return new South(this._x, this._y, this._maxX, this._maxY);
            else if (instruction == Command.R)
                return new North(this._x, this._y, this._maxX, this._maxY);
            else if (instruction == Command.F && this._x != 0)
                this._x--;
            else if (instruction == Command.B && this._maxX != this._x)
                this._x++;

            return this;
        }

        public override string ToString()
        {
            return $"{this._x} {this._y} {this.GetType().Name}";
        }
    }
}