namespace MatrixAnalyzer
{
    public interface IMatrix
    {
        int Size { get; }
        int GetMin();
        int GetMax();
        long GetRangeSum(int fromRow, int toRow);
    }
}