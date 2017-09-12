using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanCLI
{
    public abstract class GameObject
    {
        public GameObject Noord
        {
            get => default(GameObject);
            set
            {
            }
        }

        public GameObject West
        {
            get => default(GameObject);
            set
            {
            }
        }

        public GameObject Oost
        {
            get => default(GameObject);
            set
            {
            }
        }

        public GameObject Zuid
        {
            get => default(GameObject);
            set
            {
            }
        }
    }
}