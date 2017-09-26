using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanCLI
{
    public class Field : GameObject
    {
        public Movable _Movable
        {
            get => default(Movable);
            set
            {
            }
        }

        public void MoveMovable(Direction direction)
        {
            throw new System.NotImplementedException();
        }
    }
}