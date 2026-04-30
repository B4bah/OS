using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenPrinter_2
{
    public class ActiveObject
    {
        private Thread _thread;
        private volatile bool _isStopped = false;
        
        public bool IsStopped { get {  return _isStopped; }  }

        public ActiveObject()
        {
            _thread = new Thread(Run);
        }

        public void Start()
        {
            _isStopped = false;
            _thread.Start();
        }

        public void Stop()
        {
            _isStopped = true;
            _thread.Join();
        }

        protected virtual void Run()
        { }
    }
}
