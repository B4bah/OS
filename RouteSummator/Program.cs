using System;

namespace RouteSummator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataPath = "./points.txt";
            IRouteDataProvider provider = new RouteDataProvider(dataPath);
            RouteStorage storage = new RouteStorage(provider);

            storage.Fill();

            Console.WriteLine(storage);
            Console.ReadKey();
        }
    }
}