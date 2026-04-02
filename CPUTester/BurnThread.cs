using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CPUTester
{
    public class BurnThread
    {
        private bool _isRunning = false;
        private Thread _burnThread;
        
        public BurnThread()
        {
            _burnThread = new Thread(StartBurn);
            _isRunning = true;
        }

        public void Stop()
        {
            if (_isRunning)
                return;

            _isRunning = false;
            _burnThread.Join();
        }

        public void StartBurn()
        {
            int i = 0;
            while (_isRunning)
            {
                double j = Math.Pow(Math.Pow(i, -10), 4);
                i++;
            }
        }
    }
}
