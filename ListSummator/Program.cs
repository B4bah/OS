using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ListSummator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the amount of numbers:\n>>> ");
            int numbersCount = int.Parse(Console.ReadLine());

            double[] numbers = new double[numbersCount];

            ArrayMath.Fill(numbers);

            Stopwatch sumWatch = new Stopwatch();
            sumWatch.Start();
            double sum = ArrayMath.Sum(numbers);
            sumWatch.Stop();
            Console.WriteLine($"THe sum is {sum} by {sumWatch.ElapsedMilliseconds / 1000.0} seconds");
        }
    }
}
