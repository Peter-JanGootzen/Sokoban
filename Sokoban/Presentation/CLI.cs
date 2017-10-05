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
            Console.Clear();
            Tile currentxaxistile = firstTile;
            Tile currentyaxistile = firstTile;
            while (currentyaxistile != null)
            {
                Console.Write(ParseTileChar(currentxaxistile as dynamic));

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

        private String ParseTileChar(Field field)
        {
            if (field._Movable != null)
                return ParseMovableChar(field._Movable as dynamic);
            else
                return ".";
        }

        private String ParseMovableChar(Truck truck)
        {
            return "@";
        }

        private String ParseMovableChar(Crate crate)
        {
            return "o";
        }

        private String ParseTileChar(Wall wall)
        {
            return "#";
        }

        private String ParseTileChar(Spacer spacer)
        {
            return " ";
        }
    }
}