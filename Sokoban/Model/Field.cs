using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanCLI
{
    public class Field : Tile
    {

        // TODO
        // Get rid of DirectionConverter, something with delegates or dynamic type overloading.

        public override Movable _Movable
        {
            get;
            set;
        }

        public Field(Movable movable)
        {
            _Movable = movable;
        }
        
        public virtual bool MoveOnThis(Crate crate, Direction direction)
        {
            if (_Movable == null)
            {
                _Movable = crate;
            }
            else
                return false;
            return true;
        }

        public bool MoveOnThis(Truck truck, Direction direction)
        {
            if (_Movable == null)
            {
                _Movable = truck;
                return true;
            }
            else
            {
                if (DirectionConverter.Convert(this, direction).MoveOnThis(_Movable, direction))
                {
                    _Movable = truck;
                    return true;
                }
                else
                    return false;
            }
        }
        
        public override bool MoveOnThis(Movable movable, Direction direction)
        {
            return MoveOnThis(movable as dynamic, direction);
        }
    }
}