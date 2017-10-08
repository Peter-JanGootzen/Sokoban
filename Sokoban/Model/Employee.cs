using SokobanCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Employee : Movable
    {
        public bool _Active {set; get;}

        public bool MoveRandom()
        {
            if (_Field == null) // If the Employee is not in the game, we return false so that the view doesn't update and so that he doesn't try to move and make null pointer exceptions
                return false;
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
            random = r.Next(100) + 1;
            if (_Active)
            {
                if(random <= 25)
                {
                    MoveNorth();
                }
                else if(random > 25 && random <= 50)
                {
                    MoveSouth();
                }
                else if(random > 50 && random <= 75)
                {
                    MoveEast();
                }
                else if(random > 75 && random <= 100)
                {
                    MoveWest();
                }
            }
            return _Active;
        }
    }
}
