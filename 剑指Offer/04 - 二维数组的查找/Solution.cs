/// 面试题04. 二维数组中的查找 (https://leetcode-cn.com/problems/er-wei-shu-zu-zhong-de-cha-zhao-lcof/)
/// Difficulty: Easy
/// 执行用时: 144 ms, 在所有 C# 提交中击败了 62.77% 的用户
/// 内存消耗: 31.1 MB, 在所有 C# 提交中击败了 100.00% 的用户
public class Solution
{
    public bool FindNumberIn2DArray(int[][] matrix, int target)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == target)
                {
                    return true;
                }
            }
        }

        return false;
    }
}