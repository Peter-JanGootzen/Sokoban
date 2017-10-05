using SokobanCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Employee : Movable
    {
        public bool _Active = false;

        public void MoveRandom()
        {
            Random r = new Random();
            int random = r.Next(100) + 1;
            if(!_Active && random >= 90)
            {
                _Active = true;
            }
            else if(_Active && random <= 25)
            {
                _Active = false;
            }
        }

        public bool IsActive()
        {
            return _Active;
        }
    }
}