// Question 62. Unique Paths (https://leetcode-cn.com/problems/unique-paths/)

/// <summary>
/// 执行用时：44 ms, 在所有 C# 提交中击败了 85.20% 的用户
/// 内存消耗：14.9 MB, 在所有 C# 提交中击败了 27.60% 的用户
/// 
/// Acknowledgement: This solution is a C#-version duplicate of the [official solution](https://leetcode-cn.com/problems/unique-paths/solution/bu-tong-lu-jing-by-leetcode-solution-hzjf/)
/// </summary>
public class Solution 
{
    public int UniquePaths(int m, int n) 
    {
        long answer = 1;

        for (int x = n, y = 1; y < m; ++x, ++y)
        {
            answer = answer * x / y;
        }

        return (int) answer;
    }
}