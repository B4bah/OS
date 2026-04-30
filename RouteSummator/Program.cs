using System;

namespace RouteSummator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Укажите путь к файлу, если он отличается от "./points.txt"
            string dataPath = "./points.txt";
            IRouteDataProvider provider = new RouteDataProvider(dataPath);
            RouteStorage storage = new RouteStorage(provider);

            storage.Fill();

            var routes = storage.Routes;
            Console.WriteLine($"Загружено маршрутов: {routes.Count}");
            for (int i = 0; i < routes.Count; i++)
            {
                double length = routes[i].CalculateLength();
                Console.WriteLine($"Маршрут {i + 1}: длина = {length:F2}");
            }

            Console.ReadKey();
        }
    }
}