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
            get;
            set;
        }

        public bool MoveNorth()
        {
            Field tmp = _Field;
            if (_Field._North.MoveOnThis(this, Direction.UP))
            {
                tmp._Movable = null;
                return true;
            }
            else
                return false;
        }

        public bool MoveEast()
        {
            Field tmp = _Field;
            if (_Field._East.MoveOnThis(this, Direction.RIGHT))
            {
                tmp._Movable = null;
                return true;
            }
            else
                return false;
        }

        public bool MoveSouth()
        {
            Field tmp = _Field;
            if (_Field._South.MoveOnThis(this, Direction.DOWN))
            {
                tmp._Movable = null;
                return true;
            }
            else
                return false;
        }

        public bool MoveWest()
        {
            Field tmp = _Field;
            if (_Field._West.MoveOnThis(this, Direction.LEFT))
            {
                tmp._Movable = null;
                return true;
            }
            else
                return false;
        }
    }
}