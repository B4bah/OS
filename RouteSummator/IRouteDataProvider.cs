using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteSummator
{
    public delegate void RouteVisitor(Route route);
    public interface IRouteDataProvider
    {
        void VisitRoute(RouteVisitor routeVisitor);
    }
}
