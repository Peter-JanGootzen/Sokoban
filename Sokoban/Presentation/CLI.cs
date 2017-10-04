using Sokoban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanCLI
{
    public class CLI
    {

        private Controller controller;

        public CLI(Controller controller)
        {
            this.controller = controller;
        }

        public void RefreshCLI()
        {
            // DRAW SOME SHIT
        }

        public bool CatchInput()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                    return controller.MoveTruckWest();
                case ConsoleKey.RightArrow:
                    return controller.MoveTruckEast();
                case ConsoleKey.DownArrow:
                    return controller.MoveTruckSouth();
                case ConsoleKey.UpArrow:
                    return controller.MoveTruckNorth();
                case ConsoleKey.O:
                    return controller.LoadLevel();
            }
            return false;
        }
    }
}