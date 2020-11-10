// Question 31. Next Permutation (https://leetcode-cn.com/problems/next-permutation/)

/// <summary>
/// 执行用时：260 ms, 在所有 C# 提交中击败了 100.00% 的用户
/// 内存消耗：31.3 MB, 在所有 C# 提交中击败了 16.00% 的用户
/// 
/// Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/next-permutation/solution/xia-yi-ge-pai-lie-by-leetcode-solution/).
/// </summary>
public class Solution 
{
    public void NextPermutation(int[] nums) 
    {
        int N = nums.Count();

        if (N == 1) { return; }

        int i = N - 2;
        while (i >= 0 && nums[i] >= nums[i + 1]) 
        {
            i--;
        }

        if (i >= 0)
        {
            int j = N - 1;
            while (j >= 0 && nums[j] <= nums[i]) { j--; }
            this.SwapTwoValues(nums, i, j);
        }

        this.ReverseFromStart(nums, i + 1);

    }

    private void SwapTwoValues(int[] nums, int leftIndex, int rightIndex)
    {
        int temp = nums[leftIndex];
        nums[leftIndex] = nums[rightIndex];
        nums[rightIndex] = temp;
    }

    private void ReverseFromStart(int[] nums, int start)
    {
        int left = start;
        int right = nums.Count() - 1;

        while (left < right)
        {
            this.SwapTwoValues(nums, left, right);
            left++;
            right--;
        }
    }
}