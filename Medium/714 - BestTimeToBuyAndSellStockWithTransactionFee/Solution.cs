// Question 714. Best Time to Buy and Sell Stock with Transaction Fee (https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee/)

/// <summary>
/// Acknowledgement: All these 3 solutions are C#-duplicate of the 
/// [official solution] (https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee/solution/mai-mai-gu-piao-de-zui-jia-shi-ji-han-sh-rzlz/)
/// </summary>
public class Solution 
{
    /// <summary>
    /// 执行用时：248 ms, 在所有 C# 提交中击败了 66.67% 的用户
    /// 内存消耗：43.2 MB, 在所有 C# 提交中击败了 48.72% 的用户
    /// </summary>
    /// <param name="prices"></param>
    /// <param name="fee"></param>
    /// <returns></returns>
    public int MaxProfit(int[] prices, int fee) 
    {
        int N = prices.Count();
        int buy = prices[0] + fee;
        int profit = 0;

        for (var i = 0; i < N; i++)
        {
            if (prices[i] + fee < buy)
            {
                buy = prices[i] + fee;
            }
            else if (prices[i] > buy)
            {
                profit += prices[i] - buy;
                buy = prices[i];
            }
        }

        return profit;
    }

    /// <summary>
    /// 执行用时：244 ms, 在所有 C# 提交中击败了 74.36% 的用户
    /// 内存消耗：43.1 MB, 在所有 C# 提交中击败了 56.41% 的用户
    /// </summary>
    /// <param name="prices"></param>
    /// <param name="fee"></param>
    /// <returns></returns>
    public int MaxProfitSimplifiedDP(int[] prices, int fee) 
    {
        var N = prices.Count();
                
        int sell = 0;
        int hold = -prices[0];

        for (var i = 1; i < N; i++)
        {
            sell = Math.Max(sell, hold + prices[i] - fee);
            hold = Math.Max(sell - prices[i], hold);
        }
        
        return sell;
    }

    /// <summary>
    /// 执行用时：368 ms, 在所有 C# 提交中击败了 5.13% 的用户
    /// 内存消耗：49 MB, 在所有 C# 提交中击败了 5.13% 的用户
    /// </summary>
    /// <param name="prices"></param>
    /// <param name="fee"></param>
    /// <returns></returns>
    public int MaxProfitDP(int[] prices, int fee) 
    {
        var N = prices.Count();
        List<List<int>> dp = new List<List<int>>();
        dp.Add(new List<int> { 0, -prices[0] });

        for (var i = 1; i < N; i++)
        {
            int notHoldingProfit = Math.Max(dp[i - 1][0], dp[i - 1][1] + prices[i] - fee);
            int holdingProfit = Math.Max(dp[i - 1][0] - prices[i], dp[i - 1][1]);
            dp.Add(new List<int> { notHoldingProfit, holdingProfit });
        }
        
        return dp[N - 1][0];
    }
}