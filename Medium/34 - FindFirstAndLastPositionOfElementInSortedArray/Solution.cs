// Question 34. Find First and Last Position of Element in Sorted Array (https://leetcode-cn.com/problems/find-first-and-last-position-of-element-in-sorted-array/)

/// <summary>
/// 执行用时：292 ms, 在所有 C# 提交中击败了 66.81% 的用户
/// 内存消耗：32 MB, 在所有 C# 提交中击败了 16.59% 的用户
/// </summary>
public class Solution 
{
    public int[] SearchRange(int[] nums, int target) 
    {
        int startIndex = Array.IndexOf(nums, target);
        if (startIndex == -1) { return new int[] { -1, -1 }; }

        int i = startIndex;
        for (i = startIndex; i < nums.Count(); i++)
        {
            if (nums[i] != target) { break; }
        }

        return new int[] { startIndex, i - 1 };
    }
}