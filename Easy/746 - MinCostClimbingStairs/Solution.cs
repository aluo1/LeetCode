// Question 746. Min Cost Climbing Stairs (https://leetcode-cn.com/problems/min-cost-climbing-stairs/)

/// <summary>
/// 执行用时：108 ms, 在所有 C# 提交中击败了 85.88% 的用户
/// 内存消耗：26 MB, 在所有 C# 提交中击败了 8.44% 的用户
/// </summary>
public class Solution 
{
    public int MinCostClimbingStairs(int[] cost) 
    {
       int N = cost.Count();
       int[] dp = new int[N + 1];
       dp[0] = 0;
       dp[1] = 0;
       
       for (int i = 2; i <= N; i++) 
       {
           dp[i] = Math.Min(dp[i - 1] + cost[i - 1], dp[i - 2] + cost[i - 2]);
       }

       return dp[N];
    }
}