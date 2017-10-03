using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanCLI
{
    public enum Direction
    {
        UP, DOWN, LEFT, RIGHT
    }

    public static class DirectionConverter
    {
        public static Tile Convert(Field field, Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    return field._North;
                case Direction.DOWN:
                    return field._South;
                case Direction.RIGHT:
                    return field._East;
                case Direction.LEFT:
                    return field._West;
            }
            return null;
        }
    }
}