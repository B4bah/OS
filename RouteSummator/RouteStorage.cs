using System.Collections.Generic;

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

        public IReadOnlyList<Route> Routes => _routes;

        public void Fill()
        {
            // Очищаем текущий список
            _routes.Clear();

            // Используем визитёр: для каждого прочитанного маршрута добавляем его в хранилище
            _dataProvider.VisitRoute(route =>
            {
                _routes.Add(route);
            });
        }
    }
}