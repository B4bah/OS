using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteSummator
{
    public class Route : IRoute
    {
        private List<Point> _points;

        public Route()
        {
            _points = new List<Point>();
        }

        public void Fill()
        {

        }

        private double CalculateLength()
        {
            return 0.0;
        }
    }
}
