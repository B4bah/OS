using System;
using System.Diagnostics;

namespace ListSummator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the amount of numbers:\n>>> ");
            int numbersCount = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of threads:\n>>> ");
            int threadCount = int.Parse(Console.ReadLine());

            double[] numbers = new double[numbersCount];
            ArrayMath.Fill(numbers);

            Stopwatch watch = new Stopwatch();

            watch.Restart();
            double singleSum = ArrayMath.Sum(numbers);
            watch.Stop();
            Console.WriteLine($"Single-thread sum: {singleSum} in {watch.Elapsed.TotalSeconds:F4} sec");

            watch.Restart();
            double parallelSum = ArrayMath.ParallelSum(numbers, threadCount);
            watch.Stop();
            Console.WriteLine($"Parallel sum ({threadCount} threads): {parallelSum} in {watch.Elapsed.TotalSeconds:F4} sec");
        }
    }
}