using Rover.Enum;

namespace Rover.Interface
{
    public interface IRover : ITile, IMove
    {
        Orientation Orientation { get; set; }

        string Instructions { get; set; }
    }
}
