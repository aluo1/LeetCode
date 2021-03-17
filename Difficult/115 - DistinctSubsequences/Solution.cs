// Question 115. Distinct Subsequences (https://leetcode-cn.com/problems/distinct-subsequences/)

/// <summary>
/// 执行用时：84 ms, 在所有 C# 提交中击败了 91.67% 的用户
/// 内存消耗：22.7 MB, 在所有 C# 提交中击败了 8.33% 的用户
/// 
/// Acknowledgement: This solution is the C#-version duplication of the 
/// [official solutiton](https://leetcode-cn.com/problems/distinct-subsequences/solution/bu-tong-de-zi-xu-lie-by-leetcode-solutio-urw3/)
/// </summary>
public class Solution 
{
    public int NumDistinct(string s, string t) 
    {
        int sLength = s.Count();
        int tLength = t.Count();

        if (sLength < tLength) { return 0; }

        // initialize the dp.
        int[][] dp = new int[sLength + 1][];
        for (int i = 0; i <= sLength; i++)
        {
            int[] row = new int[tLength + 1];
            for (int j = 0; j <= tLength; j++)
            {
                if (j == tLength)
                {
                    row[j] = 1;
                }
                else
                {
                    row[j] = 0;
                }
            }
            dp[i] = row;
        }

        for (int i = sLength - 1; i >= 0; i--)
        {
            char sChar = s[i];

            for (int j = tLength - 1; j >= 0; j--)
            {
                char tChar = t[j];
                
                dp[i][j] = dp[i+1][j];
                
                if (sChar == tChar)
                {
                    dp[i][j] += dp[i+1][j+1];
                }
            }
        }

        return dp[0][0];
    }
}