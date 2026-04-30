using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenPrinter_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int bufferSize = 1000;

            //BlockingBuffer<int> normalBuffer = new BlockingBuffer<int>(bufferSize);
            //BlockingBuffer<int> squaredBuffer = new BlockingBuffer<int>(bufferSize);

            //GeneratorInt generator = new GeneratorInt(normalBuffer);
            //Squarer squarer = new Squarer(normalBuffer, squaredBuffer);
            //PrinterInt printer = new PrinterInt(squaredBuffer);
            GeneratorInt generator = new GeneratorInt(Squarer.In);
            Squarer squarer = new Squarer(generator.Out);
            PrinterInt printer = new PrinterInt(squarer.Out);

            generator.Start();
            squarer.Start();
            printer.Start();

            Console.ReadLine();
            generator.Stop();
            squarer.Stop();
            printer.Stop();
        }
    }
}
