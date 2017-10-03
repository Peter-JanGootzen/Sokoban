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
            get => _DestinationsFilled;
        }

        public Maze _Maze
        {
            get;
            set;
        }

        private void UpDestinationsFilled()
        {
            _DestinationsFilled++;
        }

        private void DownDestinationFilled()
        {
            _DestinationsFilled--;
        }

        public Game(Maze maze)
        {
            _Maze = maze;
            _DestinationsFilled = 0;
        }

    }
}