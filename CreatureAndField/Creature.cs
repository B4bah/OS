using System;
using System.Collections.Generic;
using System.Text;

namespace CreatureAndField
{
    internal class Creature : IField
    {
        private Point _pos;
        private string _name;

        public Creature(Point pos, string name)
        {
            _pos = pos;
            _name = name;
            
        }
    }
}
