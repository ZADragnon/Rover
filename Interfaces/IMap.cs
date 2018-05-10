using System.Collections.Generic;

namespace Rover.Interfaces
{
    public interface IMap
    {
        IList<ITile> Tiles { get; set; }

        IList<IRover> Rovers { get; set; }
    }
}
