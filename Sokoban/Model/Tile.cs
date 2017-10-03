using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanCLI
{
    public abstract class Tile
    {

        public Tile _North
        {
            get;
            set;
        }

        public Tile _West
        {
            get;
            set;
        }

        public Tile _East
        {
            get;
            set;
        }

        public Tile _South
        {
            get;
            set;
        }

        public virtual Movable _Movable
        {
            get => null;
            set { }
        }

        public virtual Boolean MoveOnThis(Movable movable, Direction direction)
        {
            return false;
        }
    }
}