/// Question 45. Jump Game II (https://leetcode-cn.com/problems/jump-game-ii/)

public class Solution
{
    // 执行用时: 120 ms, 在所有 C# 提交中击败了 58.89% 的用户
    // 内存消耗: 26.3 MB, 在所有 C# 提交中击败了 100.00% 的用户
    // Acknowledgement: This idea is borrowed from the [official solution](https://leetcode-cn.com/problems/jump-game-ii/solution/tiao-yue-you-xi-ii-by-leetcode-solution/)
    public int Jump(int[] nums)
    {
        int numsLength = nums.Count();

        int end = 0;
        int maxPosition = 0;
        int steps = 0;

        for (int i = 0; i < numsLength - 1; i++)
        {
            maxPosition = Math.Max(maxPosition, i + nums[i]);
            if (i == end)
            {
                end = maxPosition;
                steps++;
            }
        }

        return steps;
    }
}