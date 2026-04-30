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

            GeneratorInt generator = new GeneratorInt(bufferSize);
            SquarerInt squarer = new SquarerInt(generator.Out, bufferSize);
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
