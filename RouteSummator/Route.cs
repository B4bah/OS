using System;
using System.Collections.Generic;

namespace RouteSummator
{
    public class Route : IRoute
    {
        private List<Point> _points;

        public Route()
        {
            _points = new List<Point>();
        }

        public void AddPoint(Point point)
        {
            _points.Add(point);
        }

        private double CalculateLength()
        {
            if (_points.Count < 2)
                return 0.0;

            double length = 0.0;
            for (int i = 1; i < _points.Count; i++)
            {
                var p1 = _points[i - 1];
                var p2 = _points[i];
                double dx = p2.X - p1.X;
                double dy = p2.Y - p1.Y;
                length += Math.Sqrt(dx * dx + dy * dy);
            }
            return length;
        }

        public override string ToString()
        {
            return $"length = {CalculateLength():F2}";
        }
    }
}