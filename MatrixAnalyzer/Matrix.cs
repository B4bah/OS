using System.Text;

namespace MatrixAnalyzer
{
    public class Matrix : IMatrix
    {
        private readonly int[,] _data;

        public int Size { get; }

        public Matrix(int n)
        {
            Size = n;
            _data = new int[n, n];
            Fill();
        }

        private void Fill()
        {
            int value = 0;
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    _data[i, j] = value++;
        }

        public int GetMin()
        {
            int min = _data[0, 0];
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (_data[i, j] < min) min = _data[i, j];
            return min;
        }

        public int GetMax()
        {
            int max = _data[0, 0];
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (_data[i, j] > max) max = _data[i, j];
            return max;
        }

        public long GetRangeSum(int fromRow, int toRow)
        {
            long sum = 0;
            for (int i = fromRow; i <= toRow; i++)
                for (int j = 0; j < Size; j++)
                    sum += _data[i, j];
            return sum;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                    sb.Append($"{_data[i, j],5}");
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd();
        }
    }
}