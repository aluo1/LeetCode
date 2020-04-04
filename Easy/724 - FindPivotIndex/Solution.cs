/// Question 724. Find Pivot Index
/// Difficulty: Easy
/// 执行用时: 136 ms, 在所有 C# 提交中击败了 74.10% 的用户
/// 内存消耗: 30.9 MB, 在所有 C# 提交中击败了 6.67% 的用户

public class Solution
{
    public int PivotIndex(int[] nums)
    {
        int sumOfArray = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sumOfArray += nums[i];
        }

        int sumOfSoFar = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            int currentValue = nums[i];
            if (sumOfSoFar == sumOfArray - currentValue - sumOfSoFar)
            {
                return i;
            }

            sumOfSoFar += currentValue;
        }

        return -1;
    }
}