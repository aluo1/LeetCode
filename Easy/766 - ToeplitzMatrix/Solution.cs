// Question 766. Toeplitz Matrix (https://leetcode-cn.com/problems/toeplitz-matrix/)

/// <summary>
/// 执行用时：136 ms, 在所有 C# 提交中击败了 14.29% 的用户
/// 内存消耗：27.5 MB, 在所有 C# 提交中击败了 85.71% 的用户
/// </summary>
public class Solution 
{
    private int M;
    private int N;
    private int[][] _matrix;

    public bool IsToeplitzMatrix(int[][] matrix) 
    {
        this._matrix = matrix;
        this.M = matrix.Count();
        this.N = matrix[0].Count();

        // Check the upper half 
        for (var i = 0; i < this.N; i++)
        {
            if (!this.AreDiagonalElementsSame(0, i))
            {
                return false;
            }
        }

        // Check the lower half
        for (var i = 1; i < this.M; i++)
        {
            if (!this.AreDiagonalElementsSame(i, 0))
            {
                return false;
            }
        }

        return true;
    }

    private bool AreDiagonalElementsSame(int x, int y)
    {
        int element = this._matrix[x++][y++];

        while (x < this.M && y < this.N)
        {
            if (this._matrix[x++][y++] != element)
            {
                return false;
            }
        }

        return true;
    }
}