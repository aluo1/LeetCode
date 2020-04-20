/// Question 494. Target Sum (https://leetcode-cn.com/problems/target-sum/)
/// 执行用时: 2924 ms, 在所有 C# 提交中击败了 5.97% 的用户
/// 内存消耗: 24.1 MB, 在所有 C# 提交中击败了 100.00% 的用户

public class åœSolution
{
    private int count = 0;

    public int FindTargetSumWays(int[] nums, int S)
    {
        this.FindTargetSumWays(nums, 0, 0, S);
        return count;
    }

    public void FindTargetSumWays(int[] nums, int i, int sum, int S)
    {
        if (i == nums.Count())
        {
            if (sum == S)
            {
                this.count++;
            }
        }
        else
        {
            int currentValue = nums[i];
            this.FindTargetSumWays(nums, i + 1, sum + currentValue, S);
            this.FindTargetSumWays(nums, i + 1, sum - currentValue, S);
        }
    }
}