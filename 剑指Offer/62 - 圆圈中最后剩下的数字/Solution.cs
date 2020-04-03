/// 面试题62. 圆圈中最后剩下的数字 (https://leetcode-cn.com/problems/yuan-quan-zhong-zui-hou-sheng-xia-de-shu-zi-lcof/)
/// Difficulty: Easy
/// 执行用时: 1124 ms, 在所有 C# 提交中击败了 8.70% 的用户
/// 内存消耗: 23.8 MB, 在所有 C# 提交中击败了 100.00% 的用户

public class Solution
{
    public int LastRemaining(int n, int m)
    {
        List<int> circle = new List<int>();

        for (int i = 0; i < n; i++)
        {
            circle.Add(i);
        }

        int currentIndex = 0;
        while (circle.Count() > 1)
        {
            currentIndex = (currentIndex + m - 1) % circle.Count();
            circle.RemoveAt(currentIndex);
        }

        return circle.ElementAt(0);
    }
}