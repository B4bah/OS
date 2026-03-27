using CreatureAndField_2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CreatureAndField
{
    internal class Creature
    {
        private Point _pos;
        private string _name;
        private IField _iField;

        public Creature(Point pos, string name, IField iField)
        {
            _pos = pos;
            _name = name;
            _iField = iField;
        }

        public bool Move()
        {
            Point nextPos = _pos;
            nextPos.Y += 1;
            if (_iField.CanMove(nextPos))
            {
                _pos = nextPos;
                return true;
            }
            nextPos.Y -= 1;
            nextPos.X += 1;
            if (_iField.CanMove(nextPos))
            {
                _pos = nextPos;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{_name}: ({_pos.ToString()})"; 
        }
    }
}
