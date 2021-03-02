// Question 304. Range Sum Query 2D - Immutable (https://leetcode-cn.com/problems/range-sum-query-2d-immutable/)

/// <summary>
/// 执行用时：188 ms, 在所有 C# 提交中击败了 72.73% 的用户
/// 内存消耗：35.2 MB, 在所有 C# 提交中击败了 68.18% 的用户
/// </summary>
public class NumMatrix
{
    private int[][] _sum;

    public NumMatrix(int[][] matrix) 
    {
        int M = matrix.Count();
        if (M != 0)
        {
            int N = matrix[0].Count();

            int[][] rowsSum = new int[M][];
            for (var i = 0; i < M; i++)
            {
                int[] rowSum = new int[N];
                for (var j = 0; j < N; j++)
                {
                    rowSum[j] = (j == 0 ? 0 : rowSum[j - 1]) + matrix[i][j];
                }
                rowsSum[i] = rowSum;
            }

            _sum = new int[M + 1][];
            var sumRow = new int[N + 1];
            Array.Fill(sumRow, 0);
            _sum[0] = sumRow;

            // System.Console.WriteLine("_sum: [");
            // System.Console.WriteLine($"[{string.Join(",", sumRow)}]");

            for (var i = 1; i <= M; i++)
            {
                sumRow = new int[N + 1];
                sumRow[0] = 0;
                
                for (var j = 1; j <= N; j++)
                {
                    sumRow[j] = _sum[i - 1][j] + rowsSum[i - 1][j - 1];
                }

                // System.Console.WriteLine($"[{string.Join(",", sumRow)}]");

                _sum[i] = sumRow;
            }

            // System.Console.WriteLine("]");
        }
        else
        {
            _sum = new int[0][];
        }
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) 
    {
        return _sum[row2 + 1][col2 + 1] - _sum[row1][col2 + 1] - _sum[row2 + 1][col1] + _sum[row1][col1];
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */