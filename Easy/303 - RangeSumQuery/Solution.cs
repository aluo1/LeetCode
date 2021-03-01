/// Question 303. Range Sum Query - Immutable (https://leetcode-cn.com/problems/range-sum-query-immutable/)

public class NumArray
{
    /// 执行用时 : 344 ms, 在所有 C# 提交中击败了 40.63% 的用户
    /// 内存消耗 : 35.7 MB, 在所有 C# 提交中击败了 25.00% 的用户

    private readonly int[] nums;

    public NumArray(int[] nums)
    {
        this.nums = nums;
    }

    public int SumRange(int i, int j)
    {
        int sum = 0;
        for (int index = i; index <= j; index++)
        {
            sum += this.nums[index];
        }

        return sum;
    }
}

public class NumArrayWithPrecalculatedValue
{
    /// 执行用时 : 1116 ms, 在所有 C# 提交中击败了 6.25% 的用户
    /// 内存消耗 : 35.7 MB, 在所有 C# 提交中击败了 25.00% 的用户

    private readonly int[] rangeSum;

    public NumArray(int[] nums)
    {
        this.rangeSum = new int[nums.Count()];

        for (int i = 0; i < nums.Count(); i++)
        {
            this.rangeSum[i] = nums.Take(i + 1).Sum();
        }
    }

    public int SumRange(int i, int j)
    {
        if (i == 0)
        {
            return this.rangeSum[j];
        }

        return this.rangeSum[j] - this.rangeSum[i - 1];
    }
}

/// <summary>
/// 执行用时：172 ms, 在所有 C# 提交中击败了 82.00% 的用户
/// 内存消耗：35.3 MB, 在所有 C# 提交中击败了 60.00% 的用户
/// </summary>
public class NumArray 
{
    int[] _sums;

    public NumArray(int[] nums) 
    {
        int N = nums.Count();
        _sums = new int[N];
        if (N > 0)
        {
            _sums[0] = nums[0];

            for (var i = 1; i < N; i++)
            {
                _sums[i] = nums[i] + _sums[i - 1];
            }
        }
    }
    
    public int SumRange(int i, int j) 
    {
        return _sums[j] - (((i - 1) >= 0) ? _sums[i - 1] : 0);
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(i,j);
 */
