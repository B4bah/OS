using System;
using System.Threading;

namespace StoreSimulation
{
    public class CheckoutManager : ActiveObject, ICheckoutManager
    {
        private readonly BlockingBuffer<CheckoutRequest> _requestBuffer;
        private readonly SemaphoreSlim _terminals;
        private readonly Clock _clock;

        public CheckoutManager(int terminalCount, Clock clock)
        {
            _requestBuffer = new BlockingBuffer<CheckoutRequest>(terminalCount * 10);
            _terminals = new SemaphoreSlim(terminalCount, terminalCount);
            _clock = clock;
        }

        public void RequestCheckout(CheckoutRequest request)
        {
            _requestBuffer.Add(request);
        }

        public void SignalStop()
        {
            // Poison pill: customerId = -1
            _requestBuffer.Add(new CheckoutRequest { customerId = -1, payTimeMinutes = 0, replyBuffer = null! });
        }

        protected override void Run()
        {
            while (!IsStopped)
            {
                CheckoutRequest request = _requestBuffer.Pop();

                // Stop signal
                if (request.customerId == -1)
                    break;

                _terminals.Wait();
                int startMinute = _clock.GetCurrentMinute();
                Console.WriteLine($"[Minute {startMinute}] Customer {request.customerId} started payment.");

                Thread.Sleep(request.payTimeMinutes * Clock.TimeScaleMs);

                request.replyBuffer.Add(true);
                _terminals.Release();

                int endMinute = _clock.GetCurrentMinute();
                Console.WriteLine($"[Minute {endMinute}] Customer {request.customerId} finished payment.");
            }
        }
    }
}