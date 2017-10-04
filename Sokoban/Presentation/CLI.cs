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

        public void RefreshCLI(Tile firstTile)
        {
            Tile currentxaxistile = firstTile;
            Tile currentyaxistile = firstTile;
            while (currentyaxistile != null)
            {
                Console.Write(ParseChar(currentxaxistile as dynamic));

                if (currentxaxistile._East != null)
                    currentxaxistile = currentxaxistile._East;
                else
                {
                    currentyaxistile = currentyaxistile._South;
                    currentxaxistile = currentyaxistile;
                    Console.WriteLine();
                }
            }
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
        public String ParseChar(Field Field)
        {
            return ".";
        }
        public String ParseChar(Destination Destination)
        {
            return "x";
        }

        public String ParseChar(Crate Crate)
        {
            return "o";
        }

        public String ParseChar(Truck Truck)
        {
            return "@";
        }
        public String ParseChar(Wall Wall)
        {
            return "#";
        }
        public String ParseChar(Spacer Spacer)
        {
            return " ";
        }
    }
}