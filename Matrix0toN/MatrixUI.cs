using System;
using System.IO;

namespace Matrix0toN
{
    public class MatrixUI
    {
        public static int GetUserMatrixSize() => Convert.ToInt32(Console.ReadLine());

        public static void PrintMatrixMax(int maxMatrix)
        {
            System.Console.WriteLine(maxMatrix);
        }

        public static void PrintMatrixMin(int minMatrix)
        {
            System.Console.WriteLine(minMatrix);
        }

        public static void PrintMatrixSum(int sum)
        {
            System.Console.WriteLine(sum);
        }
    }
}
