namespace Matrix0noN
{
    public class Matrix
    {
        private int[,] _elements;

        public Matrix(int n)
        {
            _elements = new int[n, n];
            FillMatrix(n);
        }

        private void FillMatrix(int size)
        {
            int value = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    _elements[i, j] = value;
                    value++;
                }
            }
        }

    }
}