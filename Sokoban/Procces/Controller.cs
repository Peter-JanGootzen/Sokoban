using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanCLI
{
    public class Controller
    {
        private Parser _Parser;

        private CLI _CLI;

        private Game _Game;


        public Controller()
        {
            _Parser = new Parser();
            _CLI = new CLI(this);
            StartGame();

        }

        public void StartGame()
        {
            if (LoadLevel())
            {
                _CLI.RefreshCLI(_Game._Maze._FirstTile);
                while (!_Game.CheckTruckWon() && !_Game.CheckTruckLost())
                {
                    if (_CLI.CatchInput())
                        _CLI.RefreshCLI(_Game._Maze._FirstTile);
                }
                _CLI.endScreen(_Game.CheckTruckLost());
            }
        }

        public bool LoadLevel()
        {
            _Game = _Parser.loadLevel();
            return _Game != null;
        }

        public bool MoveTruckNorth()
        {
            return _Game._Maze._Truck.MoveNorth();
        }

        public bool MoveTruckEast()
        {
            return _Game._Maze._Truck.MoveEast();
        }

        public bool MoveTruckSouth()
        {
            return _Game._Maze._Truck.MoveSouth();
        }

        public bool MoveTruckWest()
        {
            return _Game._Maze._Truck.MoveWest();
        }
    }
}