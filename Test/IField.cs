using System;
using System.Collections.Generic;
using System.Text;

namespace CreatureAndField
{
    internal interface IField
    {
        public bool CanMove(Point position)
        {
            return false;
        }
    }
}
