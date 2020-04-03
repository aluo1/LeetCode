/// Question 121. Best Time to Buy and Sell Stock (https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock/)
/// Difficulty: Easy

public class Solution {
    public int MaxProfit(int[] prices) {
        return MaxProfitSecondTry(prices);
    }

    public int MaxProfitFirstTry(int[] prices) {
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

    public int MaxProfitSecondTry(int[] prices) {
        // 执行用时: 108 ms, 在所有 C# 提交中击败了 88.47% 的用户
        // 内存消耗: 25.5 MB, 在所有 C# 提交中击败了 5.95% 的用户
        //
        // Acknowledgement: This code is borrowed from official solution (https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock/solution/121-mai-mai-gu-piao-de-zui-jia-shi-ji-by-leetcode-/).
        int maxProfit = 0;
        int minValue = int.MaxValue;

        for (int i = 0; i < prices.Length; i++) {
           if (prices[i] < minValue) {
               minValue = prices[i];
           }

           if (prices[i] - minValue > maxProfit) {
               maxProfit = prices[i] - minValue;
           }
        }

        return maxProfit;
    }
}