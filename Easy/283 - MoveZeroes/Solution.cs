// Question 283. Move Zeroes (https://leetcode-cn.com/problems/move-zeroes/)

/// <summary>
/// 执行用时：312 ms, 在所有 C# 提交中击败了 21.48% 的用户
/// 内存消耗：31.6 MB, 在所有 C# 提交中击败了 18.96% 的用户
/// </summary>
public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        int N = nums.Count();
        int leftPointer = 0;
        int rightPointer = 0;

        while (rightPointer < N)
        {
            if (nums[rightPointer] != 0)
            {
                int temp = nums[leftPointer];
                nums[leftPointer] = nums[rightPointer];
                nums[rightPointer] = temp;
                leftPointer++;
            }
            rightPointer++;
        }
    }
}