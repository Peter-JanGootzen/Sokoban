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
        public Game LoadLevel()
        {
            string winDir = System.Environment.GetEnvironmentVariable("windir");
            OpenFileDialog fileChooser = new OpenFileDialog();
            if (fileChooser.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(fileChooser.FileName.ToString());
            }
            /*
            StreamReader reader = new StreamReader();
            try
            {
                do
                {
                    reader.ReadLine();
                }
                while (reader.Peek() != -1);
            }

            finally
            {
                reader.Close();
            }
            */
            return null;
        }
    }
}