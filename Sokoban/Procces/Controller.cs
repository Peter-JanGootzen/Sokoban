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

        public CLI _CLI
        {
            get => default(CLI);
            set
            {
            }
        }

        public Game _Game
        {
            get => default(Game);
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