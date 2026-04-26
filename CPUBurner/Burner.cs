using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CPUBurner
{
    public class Burner
    {
        private bool _isRunning;
        private volatile Thread _burnThread;

        public Burner()
        {
            _burnThread = new Thread(Burn);
        }

        public void Start()
        {
            _isRunning = true;
            _burnThread.Start();
        }

        private void Burn()
        {
            double sum = 0.0;
            int i = 0;
            while (_isRunning)
            {
                sum += Math.Pow(i, i);
            }
        }

        public void Stop()
        {
            if (_isRunning)
                return;
            _isRunning = false;
            _burnThread.Join();
        }
    }
}
