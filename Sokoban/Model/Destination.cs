using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanCLI
{
    public class Destination : Field
    {
        public Destination()
        {
        }

        public Destination(Movable movable) : base(movable)
        {
        }

        public override bool MoveOnThis(Crate crate, Direction direction)
        {
            if (_Movable == null)
            {
                _Movable = crate;
                // Notify Game object to up the DestinationsFilled counter;
            }
            else
                return false;
            return true;
        }
    }
}