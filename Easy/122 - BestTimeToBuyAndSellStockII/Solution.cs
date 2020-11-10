// Question 122. Best Time to Buy and Sell Stock II (https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-ii/)

/// <summary>
/// 执行用时：116 ms, 在所有 C# 提交中击败了 52.99% 的用户
/// 内存消耗：25.2 MB, 在所有 C# 提交中击败了 14.93% 的用户
/// </summary>
public class Solution 
{
    public int MaxProfit(int[] prices) 
    {
        int days = prices.Count();

        int maxprofit = 0;
        for (int i = 1; i < days; i++)
        {
            maxprofit += Math.Max(0, prices[i] - prices[i - 1]);
        }    

        return maxprofit;
    }
}
