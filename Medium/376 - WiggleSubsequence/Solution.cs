// Question 376. Wiggle Subsequence (https://leetcode-cn.com/problems/wiggle-subsequence/)

/// <summary>
/// 执行用时：100 ms, 在所有 C# 提交中击败了 80.00% 的用户
/// 内存消耗：23.6 MB, 在所有 C# 提交中击败了 50.00% 的用户
/// 
/// Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/wiggle-subsequence/solution/bai-dong-xu-lie-by-leetcode-solution-yh2m/)
/// </summary>
public class Solution 
{
    public int WiggleMaxLength(int[] nums) 
    {
        int N = nums.Count();

        if (N < 2) { return N; }

        int previousDifference = nums[1] - nums[0];
        int maxLength = previousDifference != 0 ? 2 : 1;
        
        for (int i = 2; i < N; i++)
        {
            int difference = nums[i] - nums[i - 1];

            if ((difference > 0 && previousDifference <= 0) || (difference < 0 && previousDifference >= 0))
            {
                maxLength++;
                previousDifference = difference;
            }
        }

        return maxLength;
    }
}