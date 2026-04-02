using System;
using System.Collections.Generic;
using System.Text;

namespace CreatureAndField
{
    public interface IField
    {
        bool CanMove(Point position);

        void PaintTheCell(Point position, int mark);
    }
}
