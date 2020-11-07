// Question 327. Count of Range Sum (https://leetcode-cn.com/problems/count-of-range-sum/)

/// <summary>
/// 执行用时：128 ms, 在所有 C# 提交中击败了 100.00% 的用户
/// 内存消耗：29.3 MB, 在所有 C# 提交中击败了 100.00% 的用户
/// 
/// Acknowledgement: This solution is a C#-version duplication of the [official solution](https://leetcode-cn.com/problems/count-of-range-sum/solution/qu-jian-he-de-ge-shu-by-leetcode-solution/) method 1.
/// </summary>
public class Solution 
{
    private int _lower;
    private int _upper;

    public int CountRangeSum(int[] nums, int lower, int upper) 
    {
        this._lower = lower;
        this._upper = upper;

        int  N = nums.Count();
        long sum = 0;
        long[] sums = new long[N + 1];

        for (int i = 0; i < N; ++i) 
        {
            sum += nums[i];
            sums[i + 1] = sum;
        }

        return this.CountRangeSumRecursively(sums, 0, sums.Count() - 1);
    }

    private int CountRangeSumRecursively(long[] sums, int left, int right)
    {
        if (left == right)
        {
            return 0;
        }

        int mid = (left + right) / 2;
        int n1 = this.CountRangeSumRecursively(sums, left, mid);
        int n2 = this.CountRangeSumRecursively(sums, mid + 1, right);
        int ret = n1 + n2;

        int i = left;
        int l = mid + 1;
        int r = mid + 1;

        while (i <= mid)
        {
            while (l <= right && sums[l] - sums[i] < this._lower) 
            {
                l++;
            }

            while (r <= right && sums[r] - sums[i] <= this._upper)
            {
                r++;
            }

            ret += r - l;
            i++;
        }

        // Merge 2 sorted arrays.
        int[] sorted = new int[right - left + 1];
        int p1 = left;
        int p2 = mid + 1;
        int p = 0;

        while (p1 <= mid || p2 <= right)
        {
            if (p1 > mid)
            {
                sorted[p++] = (int) sums[p2++];
            }
            else if (p2 > right)
            {
                sorted[p++] = (int) sums[p1++];
            }
            else 
            {
                if (sums[p1] < sums[p2])
                {
                    sorted[p++] = (int) sums[p1++];
                }
                else 
                {
                    sorted[p++] = (int) sums[p2++];
                }
            }
        }

        for (int j = 0; j < sorted.Count(); j++)
        {
            sums[left + j] = sorted[j];
        }

        return ret;
    }
}