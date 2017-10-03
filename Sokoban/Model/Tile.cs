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
            get => default(Tile);
            set
            {
            }
        }

        public Tile _West
        {
            get => default(Tile);
            set
            {
            }
        }

        public Tile _East
        {
            get => default(Tile);
            set
            {
            }
        }

        public Tile _South
        {
            get => default(Tile);
            set
            {
            }
        }

        public virtual Boolean MoveOnThis(Movable movable, Direction direction)
        {
            return false;
        }
    }
}