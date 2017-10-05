using SokobanCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Trapdoor : SokobanCLI.Field
    {
        private int _PlacedCounter = 0;
        public int PlacedCounter
        {
            get { return _PlacedCounter; }
            set { }
        }

        public Trapdoor()
        {
        }

        public override bool MoveOnThis(Crate crate, Direction direction)
        {
            if (_Movable == null && _PlacedCounter >= 3)
            {
                crate._Field = null;
                crate = null;
            }
            else if (_Movable == null)
            {
                _Movable = crate;
                crate._Field = this;
                _PlacedCounter++;
            }
            else
                return false;
            return true;
        }

        public override bool MoveOnThis(Truck truck, Direction direction)
        {
            if (_Movable == null)
            {
                _Movable = truck;
                _PlacedCounter++;
                return true;
            }
            else
            {
                if (DirectionConverter.Convert(this, direction).MoveOnThis(_Movable, direction))
                {
                    _Movable = truck;
                    truck._Field = this;
                    _PlacedCounter++;
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