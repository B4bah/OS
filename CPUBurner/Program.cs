using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace CPUBurner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int threadCount = 4;
            List<Burner> burnerList = CreateCpuBurners(threadCount);
            Console.WriteLine("The start of the test");
            StartAllBurners(burnerList);

            Console.ReadLine();
            StopAllBurners(burnerList);
        }

        static List<Burner> CreateCpuBurners(int threadCount)
        {
            List<Burner> result = new List<Burner>();
            for (int i = 0; i < threadCount; i++)
            {
                result.Add(new Burner());
            }
            return result;
        }

        static void StartAllBurners(List<Burner> burnerList)
        {
            foreach(var b in burnerList)
            {
                b.Start();
            }
        }

        static void StopAllBurners(List<Burner> burners)
        {
            foreach(var b in burners)
            {
                b.Stop();
            }
        }
    }
}
