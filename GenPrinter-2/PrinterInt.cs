using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenPrinter_2
{
    public class PrinterInt : ActiveObject
    {
        private BlockingBuffer<int> _in;

        public PrinterInt(BlockingBuffer<int> inBuff)
        {
            _in = inBuff;
        }

        protected override void Run()
        {
            while(!IsStopped)
            {
                Console.WriteLine(_in.Pop());
            }
        }
    }
}
