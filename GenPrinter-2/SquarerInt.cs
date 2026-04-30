using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenPrinter_2
{
    public class SquarerInt : ActiveObject
    {
        private BlockingBuffer<int> _in;
        private BlockingBuffer<int> _out;

        public BlockingBuffer<int> Out { get { return _out; }  }

        public SquarerInt(BlockingBuffer<int> inBuff, int bufferSize)
        {
            _in = inBuff;
            _out = new BlockingBuffer<int>(bufferSize);
        }

        protected override void Run()
        {
            while(!IsStopped)
            {
                int value = _in.Pop();

                value = value * value;

                _out.Add(value);
            }
        }
    }
}
