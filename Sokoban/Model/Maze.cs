using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanCLI
{
    public class Maze
    {

        public int _AmountOfDestinations
        {
            get;
            set;
        }

        public Tile _FirstTile
        {
            get;
            set;
        }

        public Tile _LastTile
        {
            get;
            set;
        }

        public int _Length
        {
            get;
            set;
        }

        public Truck _Truck
        {
            get;
            set;
        }

        public List<Crate> crates = new List<Crate>();
    }
}