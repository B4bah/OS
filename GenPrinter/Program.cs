using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GenPrinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> dataBuffer = new List<int>();
            IntGenerator generator = new IntGenerator(dataBuffer);
            Printer<int> printer = new Printer<int>(dataBuffer);

            Console.ReadLine();
            generator.Stop();
            printer.Stop();
        }
    }
}
