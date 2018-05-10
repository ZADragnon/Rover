using Rover.Enums;
using System.Collections.Generic;

namespace Rover.Interfaces
{
    public interface IRover
    {
        IList<ITile> Route { get; set; }

        void Move();
    }
}