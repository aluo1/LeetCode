// Question 73. Set Matrix Zeroes (https://leetcode-cn.com/problems/set-matrix-zeroes/)

/// <summary>
/// 执行用时：300 ms, 在所有 C# 提交中击败了 87.34% 的用户
/// 内存消耗：33.3 MB, 在所有 C# 提交中击败了 53.17% 的用户
/// </summary>
public class Solution 
{
    public void SetZeroes(int[][] matrix) 
    {
        HashSet<int> distinctRowsWithZero = new HashSet<int>();
        HashSet<int> distinctColumnsWithZero = new HashSet<int>();

        int M = matrix.Count();
        int N = matrix[0].Count();

        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (matrix[i][j] == 0)
                {
                    distinctRowsWithZero.Add(i);
                    distinctColumnsWithZero.Add(j);
                }
            }
        }

        foreach (int i in distinctRowsWithZero)
        {
            for (int j = 0; j < N; j++)
            {
                matrix[i][j] = 0;
            }
        }

        foreach (int j in distinctColumnsWithZero)
        {
            for (int i = 0; i < M; i++)
            {
                matrix[i][j] = 0;
            }
        }
    }
}