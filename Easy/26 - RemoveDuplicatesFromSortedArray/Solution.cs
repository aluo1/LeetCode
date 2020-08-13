/// <summary>
/// Question 26. Remove Duplicates from Sorted Array (https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array/)
/// 
/// 执行用时：368 ms, 在所有 C# 提交中击败了 11.63% 的用户
/// 内存消耗：33.4 MB, 在所有 C# 提交中击败了 49.78% 的用户
/// 
/// This solution is a rewrite of the 
/// [provided solution](https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array/solution/shan-chu-pai-xu-shu-zu-zhong-de-zhong-fu-xiang-by-/).
/// 
/// </summary>
public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length <= 1) { return nums.Length; }

        var i = 0;
        for (int j = 1; j < nums.Length; j++)
        {
            if (nums[i] != nums[j])
            {
                nums[++i] = nums[j];
            }
        }

        return i + 1;
    }
}