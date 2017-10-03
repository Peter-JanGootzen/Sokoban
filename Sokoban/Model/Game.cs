using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanCLI
{
    public class Game
    {
        public Maze _Maze
        {
            get;
            set;
        }
        public Game(Maze maze)
        {
            _Maze = maze;
        }

        public bool CheckTruckWon()
        {
            int DestinationsFilled = 0;
            Tile CurrentXAxisTile = _Maze._FirstTile;
            Tile CurrentYAxisTile = _Maze._FirstTile;
            while (CurrentYAxisTile != null)
            {
                if (CurrentXAxisTile._Movable != null && CheckDestinationFilled(CurrentXAxisTile as dynamic, CurrentXAxisTile._Movable))
                    DestinationsFilled++;

                if (CurrentXAxisTile._East != null)
                    CurrentXAxisTile = CurrentXAxisTile._East;
                else
                {
                    CurrentYAxisTile = CurrentYAxisTile._South;
                    CurrentXAxisTile = CurrentYAxisTile;
                }
            }
            return DestinationsFilled == _Maze._AmountOfDestinations;
        }

        private bool CheckDestinationFilled(Destination destination, Crate crate)
        {
            return true;
        }

        private bool CheckDestinationFilled(Field field, Movable movable)
        {
            return false;
        }

    }
}