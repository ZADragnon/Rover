using Rover.Enums;
using Rover.Interfaces;

namespace Rover.Implementations.Orientations
{
    public class South : IPosition
    {
        private int _x;
        private int _y;
        private int _maxX;
        private int _maxY;

        public South(int x, int y, int maxX, int maxY)
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
                return new East(this._x, this._y, this._maxX, this._maxY);
            else if (instruction == Command.R)
                return new West(this._x, this._y, this._maxX, this._maxY);
            else if (instruction == Command.F && this._y != 0)
                this._y--;
            else if (instruction == Command.B && this._maxY != this._y)
                this._y++;

            return this;
        }

        public override string ToString()
        {
            return $"{this._x} {this._y} {this.GetType().Name}";
        }
    }
}