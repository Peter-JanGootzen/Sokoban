using Sokoban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanCLI
{
    public class Field : Tile
    {

        public Field(Movable movable)
        {
            _Movable = movable;
        }

        public Field()
        {

        }

        private Movable Movable;
        public Movable _Movable
        {
            get { return Movable; }
            set
            {
                Movable = value;
                if (Movable != null)
                    Movable._Field = this;
            }
        }

        public virtual bool MoveOnThis(Crate crate, Direction direction)
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

        public virtual bool MoveOnThis(Employee employee, Direction direction)
        {
            if (_Movable == null)
            {
                _Movable = employee;
                return true;
            }
            else
            {
                if (DirectionConverter.Convert(this, direction).MoveOnThis(_Movable, direction))
                {
                    _Movable = employee;
                    employee._Field = this;
                    return true;
                }
                else
                    return false;
            }
        }

        public virtual bool MoveOnThis(Truck truck, Direction direction)
        {
            if (_Movable != null && SetEmployeeActive(_Movable as dynamic))
                return false;
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

        public bool SetEmployeeActive(Employee employee)
        {
            employee._Active = true;
            return true;
        }
        public bool SetEmployeeActive(Crate crate)
        {
            return false;
        }

    }
}