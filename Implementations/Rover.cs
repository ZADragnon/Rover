using System.Collections.Generic;
using Rover.Enums;
using Rover.Interfaces;
using Rover.Implementations.Orientations;
using System;

namespace Rover.Implementations
{
    public class Rover : IRover
    {
        private IPosition _position;
        private string _instructions;
        public IList<ITile> Route { get; set; }

        public Rover(int coordinateX, int coordinateY, Orientation orientation, string instructions, int maxX, int maxY)
        {
            if (orientation == Orientation.N)
                this._position = new North(coordinateX, coordinateY, maxX, maxY);
            else if (orientation == Orientation.E)
                this._position = new East(coordinateX, coordinateY, maxX, maxY);
            else if (orientation == Orientation.S)
                this._position = new South(coordinateX, coordinateY, maxX, maxY);
            else if (orientation == Orientation.W)
                this._position = new West(coordinateX, coordinateY, maxX, maxY);

            this._instructions = instructions;

            Route = new List<ITile>();
            Route.Add(new Tile(this._position.X, this._position.Y));
        }

        public void Move()
        {
            char[] commands = this._instructions.ToCharArray();
            int commandLength = commands.Length;

            for (int i = 0; i < commandLength; i++)
            {
                if (Enum.TryParse(typeof(Command), commands[i].ToString(), out object commandResult))
                {
                    this._position = this._position.Move((Command)commandResult);
                    Route.Add(new Tile(this._position.X, this._position.Y));
                }
            }
        }

        public override string ToString()
        {
            return $"The {this.GetType().Name}'s location is {this._position.ToString()}";
        }
    }
}