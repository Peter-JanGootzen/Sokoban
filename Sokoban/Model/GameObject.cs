using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanCLI
{
    public abstract class GameObject
    {

        public GameObject _North
        {
            get => default(GameObject);
            set
            {
            }
        }

        public GameObject _West
        {
            get => default(GameObject);
            set
            {
            }
        }

        public GameObject _East
        {
            get => default(GameObject);
            set
            {
            }
        }

        public GameObject _South
        {
            get => default(GameObject);
            set
            {
            }
        }

        public virtual Boolean MoveOnThis()
        {
            return false;
        }
    }
}