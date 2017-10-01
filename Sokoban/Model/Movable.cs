using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanCLI
{
    public abstract class Movable : GameObject
    {
        private Destination _CurrentDestination;

        public void setCurrentDestination(Destination Destination)
        {
            this._CurrentDestination = Destination;
        }

        public void Move(Direction Direction)
        {
            GameObject NextDestination;

            switch (Direction)
            {
                case Direction.UP:
                    NextDestination = _North;
                    break;
                case Direction.DOWN:
                    NextDestination = _South;
                    break;
                case Direction.LEFT:
                    NextDestination = _West;
                    break;
                case Direction.RIGHT:
                    NextDestination = _East;
                    break;
                default:
                    NextDestination = null;
                    break;
            }

            NextDestination.MoveOnThis();
        }
    }
}