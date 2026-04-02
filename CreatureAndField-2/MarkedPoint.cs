using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureAndField_2
{
    public struct MarkedPoint
    {
        public Point Pos;
        public int Mark;

        public MarkedPoint(Point pos, int mark)
        {
            Pos = pos;
            Mark = mark;
        }

        public override string ToString()
        {
            return $"{Pos.ToString()}: {Mark.ToString()}";
        }
    }
}
