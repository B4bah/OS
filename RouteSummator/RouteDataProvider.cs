using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RouteSummator
{
    public class RouteDataProvider : IRouteDataProvider
    {
        private readonly string _dataPath;

        public RouteDataProvider(string dataPath = "../../../points.txt")
        {
            _dataPath = dataPath;
        }

        public void VisitRoute(RouteVisitor routeVisitor)
        {
            if (!File.Exists(_dataPath))
                throw new FileNotFoundException($"File {_dataPath} not found.");

            var lines = File.ReadAllLines(_dataPath);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var route = new Route();
                var matches = Regex.Matches(line, @"\((\d+),\s*(\d+)\)");
                foreach (Match match in matches)
                {
                    if (match.Groups.Count == 3 &&
                        double.TryParse(match.Groups[1].Value, out double x) &&
                        double.TryParse(match.Groups[2].Value, out double y))
                    {
                        route.AddPoint(new Point(x, y));
                    }
                }
                routeVisitor?.Invoke(route);
            }
        }
    }
}