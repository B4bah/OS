using System;
using System.Threading;

namespace StoreSimulation
{
    public class Customer : ActiveObject
    {
        private readonly int _id;
        private readonly IEntryGate _entryGate;
        private readonly ICheckoutManager _checkoutManager;
        private readonly int _consumeTimeMinutes;
        private readonly int _payTimeMinutes;
        private readonly Clock _clock;

        public Customer(int id, IEntryGate entryGate, ICheckoutManager checkoutManager,
                        int consumeTime, int payTime, Clock clock)
        {
            _id = id;
            _entryGate = entryGate;
            _checkoutManager = checkoutManager;
            _consumeTimeMinutes = consumeTime;
            _payTimeMinutes = payTime;
            _clock = clock;
        }

        protected override void Run()
        {
            int arrivalMinute = _clock.GetCurrentMinute();
            Console.WriteLine($"[Minute {arrivalMinute}] Customer {_id} ARRIVED.");

            var signal = new BlockingBuffer<bool>(1);

            // 1) Request entry
            var entryReq = new EntryRequest { customerId = _id, replyBuffer = signal };
            _entryGate.RequestEntry(entryReq);
            signal.Pop();  // blocks until the gate grants entry
            int enterMinute = _clock.GetCurrentMinute();
            int waitOutside = enterMinute - arrivalMinute;
            Console.WriteLine($"[Minute {enterMinute}] Customer {_id} ENTERED (waited {waitOutside} min).");

            // 2) Shopping
            Thread.Sleep(_consumeTimeMinutes * Clock.TimeScaleMs);
            int shopEndMinute = _clock.GetCurrentMinute();
            int shopTime = shopEndMinute - enterMinute;
            Console.WriteLine($"[Minute {shopEndMinute}] Customer {_id} finished shopping.");

            // 3) Pay at a checkout terminal
            int checkoutStartMinute = _clock.GetCurrentMinute();
            var checkoutReq = new CheckoutRequest
            {
                customerId = _id,
                payTimeMinutes = _payTimeMinutes,
                replyBuffer = signal
            };
            _checkoutManager.RequestCheckout(checkoutReq);
            signal.Pop();  // blocks until payment finishes
            int checkoutEndMinute = _clock.GetCurrentMinute();
            int checkoutTime = checkoutEndMinute - checkoutStartMinute;

            // 4) Leave the store
            _entryGate.Leave();
            Console.WriteLine($"[Minute {_clock.GetCurrentMinute()}] Customer {_id} LEFT.");

            // 5) Statistics
            Console.WriteLine(
                $"Customer {_id} STATS: wait outside = {waitOutside} min, " +
                $"shopping = {shopTime} min, at cashier = {checkoutTime} min.");
        }
    }
}