using System;
using System.Text.RegularExpressions;

using static System.Console;

using Rover.Builder;
using Rover.Enum;
using Rover.Extension;

namespace Rover
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"Welcome to the Rover Solution.");

            #region Capture user input

            // Read upper-right co-ordinates of plateau
            WriteLine($"{Environment.NewLine}Please supply the upper-right co-ordinates for the Plateau, e.g. 5 5");
            (int coordinateX, int coordinateY) = ValidateCoordinatesInput(ReadLine());

            // Read rover one location
            WriteLine($"{Environment.NewLine}Please supply Rover One's position, e.g. 1 2 N");
            (int rover1CoordinateX, int rover1CoordinateY, Orientation rover1Orientation) = ValidateRoverInput(ReadLine());

            // Read rover one instructions
            WriteLine($"{Environment.NewLine}Please supply Rover One's instructions. e.g. LMLMLMLMM");
            string rover1Instructions = ValidateRoverInstructions(ReadLine());

            // Read rover one location
            WriteLine($"{Environment.NewLine}Please supply Rover Two's position, e.g. 3 3 E");
            (int rover2CoordinateX, int rover2CoordinateY, Orientation rover2Orientation) = ValidateRoverInput(ReadLine());

            // Read rover one instructions
            WriteLine($"{Environment.NewLine}Please supply Rover Two's instructions. e.g. MMRMMRMRRM");
            string rover2Instructions = ValidateRoverInstructions(ReadLine());

            #endregion

            #region Set up map and Move Rovers

            // Build the Map
            new MapBuilder()
                // Set up map
                .SetCoordinates(coordinateX, coordinateY)
                .BuildMap()
                // Add Rovers to map
                .AddRover(rover1CoordinateX, rover1CoordinateY, rover1Orientation, rover1Instructions)
                .AddRover(rover2CoordinateX, rover2CoordinateY, rover2Orientation, rover2Instructions)
                // Move Rovers on map
                .Move();

            #endregion

            ReadLine();
        }

        #region Validate Helpers

        private static (int x, int y) ValidateCoordinatesInput(string input)
        {
            Regex regexPattern = new Regex(@"\d \d");

            if (regexPattern.IsMatch(input))
            {
                string[] inputArray = input.Split(' ');

                if (int.TryParse(inputArray[0], out int x))
                    if (int.TryParse(inputArray[1], out int y))
                        return (x, y);
            }

            WriteLine($"{Environment.NewLine}Please try again the input ({input}) was not in the correct format.");

            return ValidateCoordinatesInput(ReadLine());
        }

        private static (int x, int y, Orientation orientation) ValidateRoverInput(string input)
        {
            Regex regexPattern = new Regex(@"\d \d [NESW|nesw]");

            if (regexPattern.IsMatch(input))
            {
                string[] inputArray = input.ToUpper().Split(' ');

                if (int.TryParse(inputArray[0], out int x))
                    if (int.TryParse(inputArray[1], out int y))
                        if (System.Enum.TryParse(inputArray[2], out Orientation orientation))
                            return (x, y, orientation);
            }

            WriteLine($"{Environment.NewLine}Please try again the input ({input}) was not in the correct format.");

            return ValidateRoverInput(ReadLine());
        }

        private static string ValidateRoverInstructions(string input)
        {
            Regex regexPattern = new Regex(@"[MRL|mrl]");

            if (regexPattern.IsMatch(input) || string.IsNullOrWhiteSpace(input))
                return input.ToUpper();

            WriteLine($"{Environment.NewLine}Please try again the input ({input}) was not in the correct format.");

            return ValidateRoverInstructions(ReadLine());
        }

        #endregion
    }
}
