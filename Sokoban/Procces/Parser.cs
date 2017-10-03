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
        Tile[,] tiles;
        public Game ParseLevelFile()
        {
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
                    if(horizontalText.Length > largestHeight)
                    {
                        largestHeight = horizontalText.Length;
                    }
                }
                tiles = new Tile[largestWidth,largestHeight];
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
                return null;
            }
            return null;
        }

        public void GenerateReferences()
        {
            //TODO
        }

        public void printMaze(Tile[,] tiles)
        {
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                for (int x = 0; x < tiles.GetLength(0); x++)
                {
                    if (tiles[x, y] != null)
                    {
                        switch (tiles[x,y].GetType().Name)
                        {
                            case "Wall":
                                Console.Write("#");
                                break;
                            case "Field":
                                if(tiles[x, y]._Movable == null)
                                {
                                    Console.Write(".");
                                }
                                else if(tiles[x, y]._Movable.GetType().Name.Equals("Crate"))
                                { 
                                    Console.Write("o");
                                }
                                else if (tiles[x, y]._Movable.GetType().Name.Equals("Truck"))
                                {
                                    Console.Write("@");
                                }

                                break;
                            case "Spacer":
                                Console.Write(" ");
                                break;
                            case "Destination":
                                Console.Write("x");
                                break;
                        }
                    }

                }
                Console.WriteLine();

            }
        }

    }
}
                
