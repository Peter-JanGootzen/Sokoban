using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanCLI
{
    public class Controller
    {
        public Parser _Parser
        {
            get => default(Parser);
            set
            {
            }
        }

        public Game _Spel
        {
            get => default(Game);
            set
            {
            }
        }

        public CLI _CLI
        {
            get => default(CLI);
            set
            {
            }
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }

        public void CheckWin()
        {
            throw new System.NotImplementedException();
        }
    }
}