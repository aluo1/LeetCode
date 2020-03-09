/// Question 121. Best Time to Buy and Sell Stock (https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock/)
/// Difficulty: Easy

public class Solution {
    public int MaxProfit(int[] prices) {
        // 执行用时: 1520 ms, 在所有 C# 提交中击败了 5.36% 的用户
        // 内存消耗: 25.3 MB, 在所有 C# 提交中击败了 5.95% 的用户

        int maxProfit = 0;
        for (int i = 0; i < prices.Length - 1; i++) {
            for (int j = i + 1; j < prices.Length; j++) {
                int priceDiff = prices[j] - prices[i];
                if (priceDiff > maxProfit) {
                    maxProfit = priceDiff;
                }
            }
        }
        
        return maxProfit;
    }
}