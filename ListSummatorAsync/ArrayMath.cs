using System;
using System.Threading.Tasks;

namespace ListSummator
{
    public static class ArrayMath
    {
        public static void Fill(double[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = i;
        }

        public static double Sum(double[] numbers)
        {
            double result = 0;
            foreach (double value in numbers)
                result += value;
            return result;
        }

        public static double ParallelSum(double[] numbers, int threadCount)
        {
            int chunkSize = numbers.Length / threadCount;
            Task<double>[] tasks = new Task<double>[threadCount];

            for (int t = 0; t < threadCount; t++)
            {
                int start = t * chunkSize;
                int end = (t == threadCount - 1) ? numbers.Length : start + chunkSize;

                tasks[t] = Task.Run(() => SumRange(numbers, start, end));
            }

            Task.WaitAll(tasks);

            double total = 0;
            foreach (var task in tasks)
                total += task.Result;
            return total;
        }

        private static double SumRange(double[] numbers, int from, int to)
        {
            double result = 0;
            for (int i = from; i < to; i++)
                result += numbers[i];
            return result;
        }
    }
}