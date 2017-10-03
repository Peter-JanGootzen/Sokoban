using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SokobanCLI
{
    public class Parser
    {
        public Game ParseLevelFile()
        {
            OpenFileDialog fileChooser = new OpenFileDialog();
            if (fileChooser.ShowDialog() == DialogResult.OK)
            {
                String[] horizontalText = File.ReadAllLines(fileChooser.FileName.ToString());
                int largestSize = 0;
                for (int i = 0; i < horizontalText.Length; i++)
                {
                    if (horizontalText[i].Length > largestSize)
                    {
                        largestSize = horizontalText[i].Length;
                    }
                }

                String[] verticalText = new String[largestSize];
                String text = "";
                for (int i = 0; i < largestSize; i++)
                {
                    for (int y = 0; y < horizontalText.Length; y++)
                    {
                        if (horizontalText[y].Length > i)
                        {
                            text = text + horizontalText[y][i];
                        }
                    }
                    verticalText[i] = text;
                    text = "";
                }
                for (int i = 0; i < horizontalText.Length; i++)
                {
                    for (int y = 0; y < horizontalText[i].Length; y++)
                    {
                        Console.Write(horizontalText[i][y] + "");
                    }
                    Console.WriteLine();
                }
            }
            
            return null;
        }
    }
}
                
