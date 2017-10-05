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

        private Movable Movable;
        public Movable _Movable
        {
            get { return Movable; }
            set {
                Movable = value;
                if(Movable != null)
                    Movable._Field = this;
            }
        }

        public Field(Movable movable)
        {
            _Movable = movable;
        }

        public Field()
        {

        }
        
        public bool MoveOnThis(Crate crate, Direction direction)
        {
            if (_Movable == null)
            {
                _Movable = crate;
                crate._Field = this;
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
                    truck._Field = this;
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