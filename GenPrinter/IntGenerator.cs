using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenPrinter
{
    public class IntGenerator : ActiveObject
    {
        private List<int> _dataBuffer;

        public IntGenerator(List<int> buffer)
        {
            _dataBuffer = buffer;
        }

        protected override void Run()
        {
            int data = 0;
            while(!IsStopped())
            {
                _dataBuffer.Add(data++);
            }
        }
    }
}
