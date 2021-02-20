// Question 561. Array Partition I (https://leetcode-cn.com/problems/array-partition-i/)

/// <summary>
/// 执行用时：200 ms, 在所有 C# 提交中击败了 63.83% 的用户
/// 内存消耗：34.6 MB, 在所有 C# 提交中击败了 93.48% 的用户
/// </summary>
public class Solution 
{
    public int ArrayPairSum(int[] nums) 
    {
        int arraySize = nums.Count();
        int N = arraySize / 2;
        int minSum = 0;

        Array.Sort(nums);
        for (var i = 0; i < arraySize; i += 2)
        {
            minSum += nums[i];
        }

        return minSum;
    }
}