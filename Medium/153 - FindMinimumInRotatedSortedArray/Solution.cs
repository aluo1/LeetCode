/// <summary>
/// Question 153. Find Minimum in Rotated Sorted Array (https://leetcode-cn.com/problems/find-minimum-in-rotated-sorted-array/)
/// 
/// 执行用时：112 ms, 在所有 C# 提交中击败了 49.36% 的用户
/// 内存消耗：24.5 MB, 在所有 C# 提交中击败了 88.71% 的用户
/// </summary>
public class Solution
{
    public int FindMin(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        int left = 0;
        int right = nums.Length - 1;
        int mid;

        if (nums[left] < nums[right])
        {
            return nums[left];
        }

        while (left < right)
        {

            mid = (int)Math.Round(left + (right - left) / 2.0);

            if (mid + 1 < nums.Length && nums[mid] > nums[mid + 1])
            {
                return nums[mid + 1];
            }
            else if (mid - 1 >= 0 && nums[mid - 1] > nums[mid])
            {
                return nums[mid];
            }
            else if (nums[mid] > nums[0])
            {
                left = mid;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }
}