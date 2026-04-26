using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenPrinter
{
    public class ActiveObject
    {
        private Thread _activeTrhead;
        private volatile bool _isStopped = false;
        public ActiveObject()
        {
            _activeTrhead = new Thread(Run);
            Start();
        }

        public void Start()
        {
            _isStopped = false;
            _activeTrhead.Start();
        }

        public void Stop()
        {
            _isStopped = true;
            _activeTrhead.Join();
        }

        protected virtual void Run()
        { }

        protected bool IsStopped() => _isStopped;
    }
}
