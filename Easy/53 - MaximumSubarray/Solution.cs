/// Question 53. Maximum Subarray (https://leetcode-cn.com/problems/maximum-subarray/)

public class Solution
{
    // 执行用时: 104 ms, 在所有 C# 提交中击败了 97.08% 的用户
    // 内存消耗: 25.3 MB, 在所有 C# 提交中击败了 14.29% 的用户
    // Acknowledgement: This idea is borrowed from the [official solution](https://leetcode-cn.com/problems/maximum-subarray/solution/zui-da-zi-xu-he-by-leetcode-solution/)
    public int MaxSubArray(int[] nums)
    {
        int numsLength = nums.Count();

        if (numsLength == 0) { return 0; }

        int previousValue = 0;
        int maxValue = nums[0];

        for (int i = 0; i < numsLength; i++)
        {
            previousValue = Math.Max(previousValue + nums[i], nums[i]);
            maxValue = Math.Max(previousValue, maxValue);
        }

        return maxValue;
    }
}