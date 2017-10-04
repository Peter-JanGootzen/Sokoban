using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Sokoban;

namespace SokobanCLI
{
    public class Parser
    {
        // TODO
        // No type switching
        // Add crates to the _Crates List in the Maze obj

        public Game loadLevel()
        {
            Tile[,] levelArray = ParseLevelFile();
            Maze maze = new Maze();
            maze._FirstTile = levelArray[0, 0];
            GenerateReferences(levelArray);
            //GENERATE GAME
            return new Game(null);

        }

        public Tile[,] ParseLevelFile()
        {
            Tile[,] tiles;
            OpenFileDialog fileChooser = new OpenFileDialog();
            if (fileChooser.ShowDialog() == DialogResult.OK)
            {
                String[] horizontalText = File.ReadAllLines(fileChooser.FileName.ToString());
                int largestHeight = 0;
                int largestWidth = 0;
                for (int i = 0; i < horizontalText.Length; i++)
                {
                    if (horizontalText[i].Length > largestWidth)
                    {
                        largestWidth = horizontalText[i].Length;
                    }
                    if (horizontalText.Length > largestHeight)
                    {
                        largestHeight = horizontalText.Length;
                    }
                }
                tiles = new Tile[largestWidth, largestHeight];
                for (int y = 0; y < largestHeight; y++)
                {
                    for (int x = 0; x < horizontalText[y].Length; x++)
                    {
                        switch (horizontalText[y][x] + "")
                        {
                            case "#":
                                tiles[x, y] = new Wall();
                                break;
                            case ".":
                                tiles[x, y] = new Field();
                                break;
                            case " ":
                                tiles[x, y] = new Spacer();
                                break;
                            case "@"://HAVE TO ADD TRUCK TO FIELD CONSTRUCTOR.
                                tiles[x, y] = new Field(new Truck());
                                break;
                            case "o"://HAVE TO ADD CRATE TO FIELD CONSTRUCTOR
                                tiles[x, y] = new Field(new Crate());
                                break;
                            case "x":
                                tiles[x, y] = new Destination();
                                break;
                        }
                    }
                }
                return tiles;
            }
            return null;
        }

        public void GenerateReferences(Tile[,] tiles)
        {
            Tile north;
            Tile south;
            Tile west;
            Tile east;
            Tile temp;
            //TODO
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                for (int x = 0; x < tiles.GetLength(0); x++)
                {
                    if (tiles[x, y] == null)
                    {
                        break;
                    }
                    temp = tiles[x, y];
                    if (y - 1 > 0)
                    {
                        if (tiles[x, y - 1] != null)
                        {
                            north = tiles[x, y - 1];
                            if (temp._North == null)
                            {
                                temp._North = north;
                            }
                            if (north._South == null)
                            {
                                north._South = temp;
                            }
                        }

                    }
                    if (x - 1 > 0)
                    {
                        if (tiles[x - 1, y] != null)
                        {
                            west = tiles[x - 1, y];

                            if (temp._West == null)
                            {
                                temp._West = west;
                            }
                            if (west._East == null)
                            {
                                west._East = temp;
                            }
                        }

                    }
                    if (y + 1 < tiles.GetLength(1))
                    {
                        if (tiles[x, y + 1] != null)
                        {
                            south = tiles[x, y + 1];
                            if (temp._South == null)
                            {
                                temp._South = south;
                            }
                            if (south._North == null)
                            {
                                south._North = temp;
                            }
                        }
                    }
                    if (x + 1 < tiles.GetLength(0))
                    {
                        if (tiles[x + 1, y] != null)
                        {
                            east = tiles[x + 1, y];
                            if (temp._East == null)
                            {
                                temp._East = east;
                            }
                            if (east._West == null)
                            {
                                east._West = temp;
                            }
                        }
                    }
                }
            }

        }



        //public void printMazeFor(Tile[,] tiles)
        //{
        //    for (int y = 0; y < tiles.GetLength(1); y++)
        //    {
        //        for (int x = 0; x < tiles.GetLength(0); x++)
        //        {
        //            if (tiles[x, y] != null)
        //            {
        //                switch (tiles[x, y].GetType().Name)
        //                {
        //                    case "Wall":
        //                        Console.Write("#");
        //                        break;
        //                    case "Field":
        //                        if (tiles[x, y]._Movable == null)
        //                        {
        //                            Console.Write(".");
        //                        }
        //                        else if (tiles[x, y]._Movable.GetType().Name.Equals("Crate"))
        //                        {
        //                            Console.Write("o");
        //                        }
        //                        else if (tiles[x, y]._Movable.GetType().Name.Equals("Truck"))
        //                        {
        //                            Console.Write("@");
        //                        }

        //                        break;
        //                    case "Spacer":
        //                        Console.Write(" ");
        //                        break;
        //                    case "Destination":
        //                        Console.Write("x");
        //                        break;
        //                }
        //            }

        //        }
        //        Console.WriteLine();

        //    }
        //}

        //public void printMazeRef(Maze _Maze)
        //{
        //    Tile CurrentXAxisTile = _Maze._FirstTile;
        //    Tile CurrentYAxisTile = _Maze._FirstTile;
        //    while (CurrentYAxisTile != null)
        //    {
        //        switch (CurrentXAxisTile.GetType().Name)
        //        {
        //            case "Wall":
        //                Console.Write("#");
        //                break;
        //            case "Field":
        //                if (CurrentXAxisTile._Movable == null)
        //                {
        //                    Console.Write(".");
        //                }
        //                else if (CurrentXAxisTile._Movable.GetType().Name.Equals("Crate"))
        //                {
        //                    Console.Write("o");
        //                }
        //                else if (CurrentXAxisTile._Movable.GetType().Name.Equals("Truck"))
        //                {
        //                    Console.Write("@");
        //                }

        //                break;
        //            case "Spacer":
        //                Console.Write(" ");
        //                break;
        //            case "Destination":
        //                Console.Write("x");
        //                break;
        //        }

        //        if (CurrentXAxisTile._East != null)
        //            CurrentXAxisTile = CurrentXAxisTile._East;
        //        else
        //        {
        //            CurrentYAxisTile = CurrentYAxisTile._South;
        //            CurrentXAxisTile = CurrentYAxisTile;
        //            Console.WriteLine();
        //        }
        //    }
        //}
    }
}

