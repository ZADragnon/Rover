using System.Collections.Generic;

namespace Rover.Interface
{
    public interface IMap : IMove
    {
        IList<ITile> Tiles { get; set; }

        IList<IRover> Rovers { get; set; }
    }
}
