using System;
using System.Collections.Generic;
using System.Threading;

namespace StoreSimulation
{
    public class Simulation
    {
        private readonly SimulationParams _params;
        private readonly EntryGate _entryGate;
        private readonly CheckoutManager _checkoutManager;
        private readonly Clock _clock;
        private readonly List<Customer> _customers;
        private readonly Random _rng;

        public Simulation(SimulationParams parameters)
        {
            _params = parameters;
            _clock = new Clock();
            _entryGate = new EntryGate(_params.peopleMax, _clock);
            _checkoutManager = new CheckoutManager(_params.terminalCount, _clock);
            _customers = new List<Customer>();
            _rng = new Random();
        }

        public void Run()
        {
            // Start the two service threads
            _entryGate.Start();
            _checkoutManager.Start();

            int totalSimMinutes = (int)(_params.closeTime - _params.openTime).TotalMinutes + 60;
            int closeMinute = (int)(_params.closeTime - _params.openTime).TotalMinutes;
            int rushStartMinute = (int)(_params.rushStart - _params.openTime).TotalMinutes;
            int rushEndMinute = (int)(_params.rushEnd - _params.openTime).TotalMinutes;

            double nextArrivalTime = 0.0;
            int nextCustomerId = 1;
            bool storeClosed = false;

            for (int minute = 0; minute <= totalSimMinutes; minute++)
            {
                if (minute == closeMinute && !storeClosed)
                {
                    storeClosed = true;
                    Console.WriteLine($"[Minute {minute}] Store CLOSED for new customers.");
                }

                if (!storeClosed)
                {
                    bool isRushHour = minute >= rushStartMinute && minute < rushEndMinute;
                    double baseRate = _params.peopleFreq;   // now customers per hour
                    double meanArrival = isRushHour ? 30.0 / baseRate : 60.0 / baseRate;

                    while (minute >= nextArrivalTime)
                    {
                        int shopTime = RandomConsumeTime();
                        int payTime = RandomPayTime();

                        var customer = new Customer(
                            nextCustomerId++,
                            _entryGate,
                            _checkoutManager,
                            shopTime,
                            payTime,
                            _clock
                        );
                        _customers.Add(customer);
                        customer.Start();

                        nextArrivalTime += ExponentialRandom(meanArrival);
                    }
                }

                _clock.AdvanceTo(minute);
                Thread.Sleep(Clock.TimeScaleMs);
            }

            // Wait for all customers to complete their lifecycle.
            // The gate and checkout manager are still running, so customers will finish.
            foreach (var c in _customers)
                c.Stop();   // joins the customer thread

            Console.WriteLine("All customers have finished.");

            // Now safely shut down the service threads using poison pills.
            _entryGate.SignalStop();
            _checkoutManager.SignalStop();

            _entryGate.Stop();
            _checkoutManager.Stop();

            Console.WriteLine("\n=== SIMULATION ENDED ===");
            Console.WriteLine($"Total customers served: {nextCustomerId - 1}");
        }

        private double ExponentialRandom(double mean)
        {
            double u = _rng.NextDouble();
            if (u < 1e-10) u = 1e-10;
            return -mean * Math.Log(1.0 - u);
        }

        private int RandomConsumeTime()
        {
            double factor = 0.5 + _rng.NextDouble();
            int raw = (int)Math.Round(_params.consumeTime * factor);
            return Math.Max(1, raw);
        }

        private int RandomPayTime()
        {
            double factor = 0.5 + _rng.NextDouble();
            int raw = (int)Math.Round(_params.payTime * factor);
            return Math.Max(1, raw);
        }
    }
}