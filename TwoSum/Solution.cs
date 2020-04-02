/// Question 1. Two Sum (https://leetcode-cn.com/problems/two-sum/)
/// Difficulty: Easy


public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        /// 执行用时: 480 ms.
        /// 内存消耗: 30.5 MB.
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new int[] { i, j };
                }
            }
        }

        return new int[2];
    }
}