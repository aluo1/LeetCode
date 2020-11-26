// Question 164. Maximum Gap (https://leetcode-cn.com/problems/maximum-gap/)

/// <summary>
/// 执行用时：116 ms, 在所有 C# 提交中击败了 56.00% 的用户
/// 内存消耗：24.8 MB, 在所有 C# 提交中击败了 24.00% 的用户
/// </summary>
public class Solution
{
    public int MaximumGap(int[] nums)
    {
        int N = nums.Count();
        if (N < 2) { return 0; }

        // Sort the array.
        Array.Sort(nums);

        int maxGap = int.MinValue;
        for (int i = 0; i < N - 1; i++)
        {
            int gap = nums[i + 1] - nums[i];
            maxGap = Math.Max(gap, maxGap);
        }

        return maxGap;
    }
}