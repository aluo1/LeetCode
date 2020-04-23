/// 面试题 08.11. 硬币 (https://leetcode-cn.com/problems/coin-lcci/)
/// 执行用时: 132 ms, 在所有 C# 提交中击败了 20.00% 的用户
/// 内存消耗: 22.1 MB, 在所有 C# 提交中击败了 100.00% 的用户
/// Acknowledgement: This solution borrows idea from [official solution] (https://leetcode-cn.com/problems/coin-lcci/solution/ying-bi-by-leetcode-solution/) and [another solution](https://leetcode-cn.com/problems/coin-lcci/solution/pythonjsdong-tai-gui-hua-he-zhu-zhan-518-ling-qian/).

public class Solution
{
    private static readonly int[] COIN_OPTIONS = new int[4] { 25, 10, 5, 1 };
    public int WaysToChange(int n)
    {
        if (n == 0) { return 1; }

        int[] coinChanges = new int[n + 1];

        coinChanges[0] = 1;
        for (int i = 0; i < COIN_OPTIONS.Count(); i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (j - COIN_OPTIONS[i] >= 0)
                {
                    coinChanges[j] = (coinChanges[j] + coinChanges[j - COIN_OPTIONS[i]]) % 1000000007;
                }
            }
        }

        return coinChanges[n];
    }
}