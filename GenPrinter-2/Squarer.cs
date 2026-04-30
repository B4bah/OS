using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenPrinter_2
{
    public class Squarer : ActiveObject
    {
        //private BlockingBuffer<int> _normalBuffer;
        //private BlockingBuffer<int> _Squaredbuffer;
        //public Squarer(BlockingBuffer<int> normalBuffer, BlockingBuffer<int> squaredBuffer)
        //{
        //    _normalBuffer = normalBuffer;
        //    _Squaredbuffer = squaredBuffer;
        //}

        //protected override void Run()
        //{
        //    while (!IsStopped)
        //    {
        //        int normalValue = _normalBuffer.Pop();
        //        int squaredValue = Convert.ToInt32(Math.Pow(normalValue, 2));


        //        _Squaredbuffer.Add(squaredValue);
        //    }

        //}

        private BlockingBuffer<int> _in;
        private BlockingBuffer<int> _out;

        public BlockingBuffer<int> Out { get { return _out; }  }

        public Squarer(BlockingBuffer<int> inBuff, int bufferSize)
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
