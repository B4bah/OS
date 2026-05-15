using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListSummator
{
    public static class ArrayMath
    {
        public static void Fill(double[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }
        }

        public static double Sum(double[] numbers)
        {
            double result = 0;
            foreach (double value in numbers)
            {
                result += value;
            }
            return result;
        }
    }
}
