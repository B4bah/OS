using System;
using System.Collections.Generic;
using System.Text;

namespace CreatureAndField
{
    internal interface IField
    {
        bool CanMove(Point position);
    }
}
