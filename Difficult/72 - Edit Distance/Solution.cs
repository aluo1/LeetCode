/// Question 72. Edit Distance (https://leetcode-cn.com/problems/edit-distance/)
/// Difficulty: Difficult/Hard
/// 
/// Acknowledgement: This solution borrows from the [official solution](https://leetcode-cn.com/problems/edit-distance/solution/bian-ji-ju-chi-by-leetcode-solution/).
/// 
/// Todo: Try this again at a later time.
/// 
/// 执行用时: 188 ms, 在所有 C# 提交中击败了 5.56% 的用户
/// 内存消耗: 26.4 MB, 在所有 C# 提交中击败了 33.33% 的用户

public class Solution
{
    public int MinDistance(string word1, string word2)
    {
        int word1Length = word1.Length;
        int word2Length = word2.Length;

        if (word1Length * word2Length == 0)
        {
            return word1Length + word2Length;
        }

        int[][] dp = new int[word1Length + 1][];

        for (int i = 0; i <= word1.Length; i++)
        {
            dp[i] = new int[word2Length + 1];
            dp[i][0] = i;
        }

        for (int j = 0; j <= word2Length; j++)
        {
            dp[0][j] = j;
        }

        for (int i = 1; i <= word1Length; i++)
        {
            for (int j = 1; j <= word2Length; j++)
            {
                int left = 1 + dp[i - 1][j];
                int bottom = 1 + dp[i][j - 1];
                int bottomLeft = dp[i - 1][j - 1];
                if (!word1[i - 1].Equals(word2[j - 1]))
                {
                    bottomLeft++;
                }
                dp[i][j] = (new int[] { left, bottom, bottomLeft }).Min();
            }
        }

        return dp[word1Length][word2Length];
    }
}