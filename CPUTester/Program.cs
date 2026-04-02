using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CPUTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int processorCount = 4;

            List<BurnThread> burnThreads = new List<BurnThread>();

            for (int i = 0; i < processorCount; ++i)
            {
                burnThreads.Add(new BurnThread());
            }

            Console.WriteLine("Press any  key to stop");
            Console.ReadLine();

            foreach(BurnThread burnThread in burnThreads)
            {
                burnThread.Stop();
            }
        }
    }
}
