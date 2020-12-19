// Question 48. Rotate Image (https://leetcode-cn.com/problems/rotate-image/)

/// <summary>
/// 执行用时：288 ms, 在所有 C# 提交中击败了 58.85% 的用户
/// 内存消耗：30.5 MB, 在所有 C# 提交中击败了 5.95% 的用户
/// </summary>
public class Solution 
{
    public void Rotate(int[][] matrix) 
    {
        int N = matrix.Count();

        for (var i = 0; i < N / 2; i++)
        {
            for (var j = 0; j < N; j++)
            {
                int temp = matrix[i][j];
                matrix[i][j] = matrix[N - 1 - i][j];
                matrix[N - 1 - i][j] = temp;
            }
        }

        for (var i = 0; i < N; i++)
        {
            for (var j = 0; j < i; j++)
            {
                int temp = matrix[i][j];
                matrix[i][j] = matrix[j][i];                
                matrix[j][i] = temp;       
            }
        }
    }
}