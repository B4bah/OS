using CreatureAndField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureAndField_2
{
    public interface IMoveStrategy
    {
        Point NextMove(Point currentPos, Field field);
    }
}
