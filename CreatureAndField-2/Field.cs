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
        private HashSet<Point> _filledCells = new HashSet<Point>();

        public Field(int width, int height)
        {
            _height = height;
            _width = width;
        }

        public bool CanMove(Point pos)
        {
            return IsValid(pos) && IsFree(pos);
        }

        public void PaintTheCell(Point pos)
        {
            _filledCells.Add(pos);
        }

        private bool IsValid(Point pos)
        {
            //return pos.X < _width && pos.Y < _height;
            return pos.X >= 0 && pos.X < _width && pos.Y >= 0 && pos.Y < _height;
        }

        private bool IsFree(Point pos)
        {
            return !_filledCells.Contains(pos);
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", _filledCells)}]";
        }
    }
}
