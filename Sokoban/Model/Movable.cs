using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanCLI
{
    public abstract class Movable
    {
        public Field _Field
        {
            get => default(Field);
            set
            {
            }
        }

        public bool MoveNorth()
        {
                return _Field._North.MoveOnThis(this, Direction.UP);
        }

        public bool MoveEast()
        {
                return _Field._East.MoveOnThis(this, Direction.RIGHT);
        }

        public bool MoveSouth()
        {
                return _Field._South.MoveOnThis(this, Direction.DOWN);
        }

        public bool MoveWest()
        {
                return _Field._North.MoveOnThis(this, Direction.LEFT);
        }
    }
}