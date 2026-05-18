using System.Threading;

namespace StoreSimulation
{
    public class ActiveObject
    {
        private Thread? _thread;
        private volatile bool _isStopped;

        public bool IsStopped => _isStopped;

        public void Start()
        {
            _isStopped = false;
            _thread = new Thread(Run);
            _thread.Start();
        }

        public void Stop()
        {
            _isStopped = true;
            _thread?.Join();
        }

        protected virtual void Run()
        { }
    }
}