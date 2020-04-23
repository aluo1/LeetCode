/// Question 55. Jump Game (https://leetcode-cn.com/problems/jump-game/)

public class Solution
{
    /// 执行用时: 136 ms, 在所有 C# 提交中击败了 28.65% 的用户
    /// 内存消耗: 26.1 MB, 在所有 C# 提交中击败了 50.00% 的用户
    public bool CanJump(int[] nums)
    {
        int distance = nums.Count();
        int furtherest = 0;

        for (int i = 0; i < distance; i++)
        {
            if (i <= furtherest)
            {
                furtherest = Math.Max(furtherest, i + nums[i]);
                if (furtherest >= distance - 1)
                {
                    return true;
                }
            }
        }

        return false;
    }
}