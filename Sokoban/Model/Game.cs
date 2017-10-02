using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanCLI
{
    public class Game
    {

        private int _DestinationsFilled;
        public int DestinationsFilled
        {
            get;
        }

        public Maze _Maze
        {
            get => default(Maze);
            set
            {
            }
        }

        public void SetDestinationsFilled(int value)
        {
            _DestinationsFilled = _DestinationsFilled + value;
        }
        public Game(Maze maze)
        {
            _Maze = maze;
            _DestinationsFilled = 0;
        }

    }
}