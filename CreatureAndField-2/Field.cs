using CreatureAndField_2;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreatureAndField
{
    public class Field : IField
    {
        private int _width;
        private int _height;

        public Field(int width, int height)
        {
            _height = height;
            _width = width;
        }

        public bool CanMove(Point pos)
        {
            return IsValid(pos);
        }

        private bool IsValid(Point position)
        {
            return position.X < _width && position.Y < _height;
        }
    }
}
