using Rover.Enums;

namespace Rover.Interfaces
{
    public interface IPosition : ITile
    {
        IPosition Move(Command instruction);
    }
}