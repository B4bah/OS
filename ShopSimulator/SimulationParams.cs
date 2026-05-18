using System;

namespace StoreSimulation
{
    public struct SimulationParams
    {
        public int peopleFreq;
        public int peopleMax;
        public int consumeTime;
        public int payTime;
        public int terminalCount;
        public TimeSpan openTime;
        public TimeSpan closeTime;
        public TimeSpan rushStart;
        public TimeSpan rushEnd;
    }
}