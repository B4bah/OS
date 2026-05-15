using System;

namespace MatrixAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N (number of matrix elements): ");
            IMatrix matrix = new Matrix(int.Parse(Console.ReadLine()));

            Console.WriteLine(matrix);
            Console.WriteLine($"Min = {matrix.GetMin()}, Max = {matrix.GetMax()}");

            Console.WriteLine("Sum of rows:");
            Console.Write($"From row (0–{matrix.Size - 1}): ");
            int from = int.Parse(Console.ReadLine());
            Console.Write($"To row (0–{matrix.Size - 1}): ");
            int to = int.Parse(Console.ReadLine());

            Console.WriteLine($"Sum = {matrix.GetRangeSum(from, to)}");
            Console.ReadKey();
        }
    }
}