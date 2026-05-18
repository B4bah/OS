using System;
using System.Threading;

namespace StoreSimulation
{
    public class EntryGate : ActiveObject, IEntryGate
    {
        private readonly BlockingBuffer<EntryRequest> _requestBuffer;
        private readonly SemaphoreSlim _capacitySemaphore;
        private readonly Clock _clock;
        private int _currentCount;

        public EntryGate(int maxCapacity, Clock clock)
        {
            _requestBuffer = new BlockingBuffer<EntryRequest>(maxCapacity * 2);
            _capacitySemaphore = new SemaphoreSlim(maxCapacity, maxCapacity);
            _clock = clock;
        }

        public void RequestEntry(EntryRequest request)
        {
            _requestBuffer.Add(request);
        }

        public void Leave()
        {
            _capacitySemaphore.Release();
            Interlocked.Decrement(ref _currentCount);
        }

        // Called by Simulation to inject a stop signal
        public void SignalStop()
        {
            // Poison pill: customerId = -1
            _requestBuffer.Add(new EntryRequest { customerId = -1, replyBuffer = null! });
        }

        protected override void Run()
        {
            while (!IsStopped)
            {
                EntryRequest request = _requestBuffer.Pop();

                // Check for stop signal
                if (request.customerId == -1)
                    break;

                _capacitySemaphore.Wait();
                request.replyBuffer.Add(true);
                Interlocked.Increment(ref _currentCount);

                Console.WriteLine($"[Minute {_clock.GetCurrentMinute()}] Gate admitted customer {request.customerId}. Inside: {_currentCount}");
            }
        }
    }
}