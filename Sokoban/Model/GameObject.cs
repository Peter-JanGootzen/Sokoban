using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanCLI
{
    public abstract class SpelObject : Speler
    {
        public SpelObject _Noord
        {
            get => default(SpelObject);
            set
            {
            }
        }

        public SpelObject _West
        {
            get => default(SpelObject);
            set
            {
            }
        }

        public SpelObject _Oost
        {
            get => default(SpelObject);
            set
            {
            }
        }

        public SpelObject _Zuid
        {
            get => default(SpelObject);
            set
            {
            }
        }
    }
}