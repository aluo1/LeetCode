/// Question 322. Coin Change
/// Difficulty: Medium

public class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        return CoinChangeOfficialSolution(coins, amount);
    }

    public int CoinChangeFirstTry(int[] coins, int amount)
    {
        // Failed
        // Input: [186,419,83,408], 6249
        // Output: -1
        // Expected Output: 20

        // Sort the coins descending.
        Array.Sort(coins);
        Array.Reverse(coins);

        int coinsCount = 0;

        foreach (int coin in coins)
        {
            int currentCoinCount = amount / coin;
            amount -= currentCoinCount * coin;
            coinsCount += currentCoinCount;
        }

        return amount != 0 ? -1 : coinsCount;
    }

    public int CoinChangeOfficialSolution(int[] coins, int amount)
    {
        // Acknowledgement: https://leetcode-cn.com/problems/coin-change/solution/322-ling-qian-dui-huan-by-leetcode-solution/
        // 执行用时: 128 ms, 在所有 C# 提交中击败了 99.03% 的用户
        // 内存消耗: 27.2 MB, 在所有 C# 提交中击败了 20.00% 的用户

        int max = amount + 1;
        int[] dp = new int[max];
        Array.Fill(dp, max);
        dp[0] = 0;

        for (int i = 1; i <= amount; i++)
        {
            for (int j = 0; j < coins.Length; j++)
            {
                if (coins[j] <= i)
                {
                    dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                }
            }
        }
        return dp[amount] > amount ? -1 : dp[amount];
    }
}