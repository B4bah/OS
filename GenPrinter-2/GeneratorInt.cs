using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenPrinter_2
{
    public class GeneratorInt :ActiveObject
    {
        //private BlockingBuffer<int> _buffer;
        //public GeneratorInt(BlockingBuffer<int> buffer)
        //{
        //    _buffer = buffer;
        //}

        //protected override void Run()
        //{
        //    int sum = 0;
        //    while (!IsStopped)
        //    {
        //        _buffer.Add(sum++);
        //        Thread.Sleep(1000);
        //    }
        //}

        private BlockingBuffer<int> _buffer;

        public BlockingBuffer<int> Out { get { return _buffer; }  }

        public GeneratorInt(int bufferSize)
        {
            _buffer = new BlockingBuffer<int>(bufferSize);
        }

        protected override void Run()
        {
            int sum = 0;

            while(!IsStopped)
            {
                _buffer.Add(sum++);
                Thread.Sleep(1000);
            }
        }
    }
}
