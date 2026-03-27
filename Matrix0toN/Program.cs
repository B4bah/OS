using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix0toN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = MatrixUI.GetUserMatrixSize();
            Matrix matrix = new Matrix(matrixSize);
            MatrixUI.PrintMatrixMax(Matrix.Max());
            MatrixUI.PrintMatrixMin(Matrix.Min());
            MatrixUI.PrintMatrixSum(Matrix.Sum());
        }
    }
}
