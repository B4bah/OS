using System.Threading;

namespace StoreSimulation
{
    public class Clock
    {
        public const int TimeScaleMs = 100;

        private int _currentMinute;
        private readonly object _lock = new object();

        public int GetCurrentMinute()
        {
            lock (_lock)
                return _currentMinute;
        }

        public void AdvanceTo(int minute)
        {
            lock (_lock)
                _currentMinute = minute;
        }
    }
}