// Question 240. Search a 2D Matrix II (https://leetcode-cn.com/problems/search-a-2d-matrix-ii/)
// This question is idential to the question 04 in 《剑指 Offer》(../剑指Offer/04 - 二维数组的查找)

/// <summary>
/// 执行用时：284 ms, 在所有 C# 提交中击败了 62.37% 的用户
/// 内存消耗：31.4 MB, 在所有 C# 提交中击败了 91.67% 的用户
/// 
/// What's worth noting here is that matrix is a multi-dimensional array, and I spent some time
/// figuring out how to get the dimension correctly.
/// </summary>
public class Solution
{
    public bool SearchMatrix(int[,] matrix, int target)
    {
        int m = matrix.GetLength(0);
        if (m == 0) { return false; }

        int n = matrix.GetLength(1);
        if (n == 0) { return false; }

        int x = m - 1;
        int y = 0;

        while (true)
        {
            if (x < 0 || x >= m || y < 0 || y >= n)
            {
                return false;
            }

            int currentValue = matrix[x, y];

            if (currentValue < target)
            {
                y++;
            }
            else if (currentValue > target)
            {
                x--;
            }
            else
            {
                return true;
            }
        }
    }
}