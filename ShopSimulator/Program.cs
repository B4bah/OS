using System;

namespace StoreSimulation
{
    public static class Program
    {
        public static void Main()
        {
            var parameters = new SimulationParams
            {
                peopleFreq = 60,
                peopleMax = 10,
                consumeTime = 10,
                payTime = 5,
                terminalCount = 4,
                openTime = new TimeSpan(8, 0, 0),
                closeTime = new TimeSpan(22, 0, 0),
                rushStart = new TimeSpan(16, 0, 0),
                rushEnd = new TimeSpan(19, 0, 0)
            };

            var simulation = new Simulation(parameters);
            simulation.Run();
        }
    }
}