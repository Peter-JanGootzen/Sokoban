using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanCLI
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            new Controller();
            Console.ReadLine();
        }
    }
}
