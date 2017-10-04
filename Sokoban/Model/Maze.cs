using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanCLI
{
    public class Maze
    {
        public Maze(List<Crate> crateList)
        {
            this.crates = crateList;
        }

        public Maze()
        {
        }

        public Tile _FirstTile
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