using System.Collections.Generic;
using System.Text;

namespace RouteSummator
{
    public class RouteStorage
    {
        private readonly IRouteDataProvider _dataProvider;
        private List<Route> _routes;

        public RouteStorage(IRouteDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            _routes = new List<Route>();
        }

        public void Fill()
        {
            _routes.Clear();
            _dataProvider.VisitRoute(route => _routes.Add(route));
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Uploaded routes count: {_routes.Count}");
            for (int i = 0; i < _routes.Count; i++)
            {
                sb.AppendLine($"Route {i + 1}: {_routes[i]}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}