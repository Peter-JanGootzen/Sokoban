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
        

        //TODO PRINT LEVEL MOET NOG GEMOVED WORDEN DENK IK?

        public Game loadLevel()
        {
            List<Crate> CrateList;
            Truck truck = new Truck();
            Tile[,] LevelArray = ParseLevelFile(out CrateList, ref truck);
            GenerateReferences(LevelArray);

            
            return GenerateGame(LevelArray, CrateList, truck);

        }

        private Game GenerateGame(Tile[,] LevelArray, List<Crate> CrateList, Truck Truck)
        {
            Maze maze = new Maze(CrateList);
            maze._FirstTile = LevelArray[0, 0];
            maze._Truck = Truck;
            Game game = new Game(maze);
            
            return game;
        }

        public Tile[,] ParseLevelFile(out List<Crate> CrateList, ref Truck Truck)
        {
            Tile[,] tiles;
            CrateList = new List<Crate>();
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
                            case "@":
                                tiles[x, y] = new Field(Truck);
                                break;
                            case "o":
                                Crate crate = new Crate();
                                CrateList.Add(crate);
                                tiles[x, y] = new Field(crate);
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
        
    }
}

