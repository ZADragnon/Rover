using System;

using static System.Console;

using Rover.Enum;
using Rover.Interface;


namespace Rover.Implementation
{
    public class Rover : IRover
    {
        public Rover(int coordinateX, int coordinateY, Orientation orientation, string instructions, int maxX, int maxY)
        {
            X = coordinateX;
            Y = coordinateY;
            Orientation = orientation;
            Instructions = instructions;
            MaxX = maxX;
            MaxY = maxY;
        }

        public int X { get; set; } = 0;

        public int Y { get; set; } = 0;

        public int MaxX { get; protected set; } = 0;

        public int MaxY { get; protected set; } = 0;

        public Orientation Orientation { get; set; } = Orientation.N;

        public string Instructions { get; set; }

        public void Move()
        {
            WriteLine($"{Environment.NewLine}Rover is moving....");

            char[] commands = Instructions.ToCharArray();
            int commandLength = commands.Length;

            for (int i = 0; i < commandLength; i++)
            {
                if (System.Enum.TryParse(typeof(Command), commands[i].ToString(), out object commandResult))
                {
                    switch ((Command)commandResult)
                    {
                        case Command.F:
                            // Future implementation
                            break;
                        case Command.R:
                            // Orientation change clockwise
                            int clockwiseOrientation = (int)Orientation;
                            clockwiseOrientation = clockwiseOrientation >= 3 ? 0 : clockwiseOrientation + 1;

                            Orientation = (Orientation)clockwiseOrientation;
                            break;
                        case Command.B:
                            // Future implementation
                            break;
                        case Command.L:
                            // Orientation change counter clockwise
                            int antiClockwiseOrientation = (int)Orientation;
                            antiClockwiseOrientation = antiClockwiseOrientation <= 0 ? 3 : antiClockwiseOrientation - 1;

                            Orientation = (Orientation)antiClockwiseOrientation;
                            break;
                        case Command.M:
                            // Move in direction of Orientation
                            switch (Orientation)
                            {
                                case Orientation.N:
                                    // y + 1
                                    Y = (MaxY == Y) ? MaxY : Y + 1;
                                    break;
                                case Orientation.E:
                                    // x + 1
                                    X = (MaxX == X) ? MaxX : X + 1;
                                    break;
                                case Orientation.S:
                                    // y - 1
                                    Y = (Y == 0) ? 0 : Y - 1;
                                    break;
                                case Orientation.W:
                                    // x - 1
                                    X = (X == 0) ? 0 : X - 1;
                                    break;
                            }
                            break;
                    }
                }
            }


            WriteLine($"Rover stopped.... Location is {X} {Y} {Orientation.ToString()}");
        }
    }
}
