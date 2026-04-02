using CreatureAndField_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CreatureAndField
{
    public class Field : IField
    {
        private int _width;
        private int _height;
        private HashSet<MarkedPoint> _filledCells = new HashSet<MarkedPoint>();

        public Field(int width, int height)
        {
            _height = height;
            _width = width;
        }

        public bool CanMove(Point pos)
        {
            return IsValid(pos) && IsFree(pos);
        }

        public void PaintTheCell(Point pos, int mark)
        {
            _filledCells.Add(new MarkedPoint(pos, mark));
        }

        private bool IsValid(Point pos)
        {
            return pos.X >= 0 && pos.X < _width && pos.Y >= 0 && pos.Y < _height;
        }

        private bool IsFree(Point pos)
        {
            return !_filledCells.Any(markedPoint => markedPoint.Pos.Equals(pos));
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", _filledCells)}]";
        }
    }
}
