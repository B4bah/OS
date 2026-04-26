using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace GenPrinter
{
    public class Printer<T> : ActiveObject
    {
        private List<T> _dataBuffer;

        public Printer(List<T> buffer)
        {
            _dataBuffer = buffer;
        }

        protected override void Run()
        {
            while (!IsStopped())
            {
                if (_dataBuffer.Count > 0)
                {
                    Thread.Sleep(0);
                    continue;
                }
                T data = _dataBuffer[0];
                _dataBuffer.RemoveAt(0);
                Console.WriteLine(data);
            }
        }
    }
}
