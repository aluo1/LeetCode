// Question 493. Reverse Pairs (https://leetcode-cn.com/problems/reverse-pairs/)

/// <summary>
/// 执行用时：372 ms, 在所有 C# 提交中击败了 18.18% 的用户
/// 内存消耗：43.4 MB, 在所有 C# 提交中击败了 15.15% 的用户
/// 
/// Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/reverse-pairs/solution/fan-zhuan-dui-by-leetcode-solution/)
/// </summary>
public class Solution
{
    public int ReversePairs(int[] nums)
    {
        int N = nums.Count();

        if (N == 0) { return 0; }

        return this.ReversePairs(nums, 0, N - 1);
    }

    public int ReversePairs(int[] nums, int left, int right)
    {
        if (left == right) { return 0; }

        int mid = (left + right) / 2;
        int n1 = this.ReversePairs(nums, left, mid);
        int n2 = this.ReversePairs(nums, mid + 1, right);
        int result = n1 + n2;

        int i = left;
        int j = mid + 1;
        while (i <= mid)
        {
            while (j <= right && 1.0 * nums[i] / 2 > nums[j] * 1.0)
            {
                j++;
            }
            result += j - mid - 1;
            i++;
        }

        // Merge two sorted array.
        int[] sorted = new int[right - left + 1];
        int p1 = left;
        int p2 = mid + 1;

        int p = 0;

        while (p1 <= mid || p2 <= right)
        {
            if (p1 > mid)
            {
                sorted[p++] = nums[p2++];
            }
            else if (p2 > right)
            {
                sorted[p++] = nums[p1++];
            }
            else
            {
                sorted[p++] = nums[p1] < nums[p2] ? nums[p1++] : nums[p2++];
            }
        }

        for (int k = 0; k < sorted.Count(); k++)
        {
            nums[left + k] = sorted[k];
        }

        return result;
    }
}