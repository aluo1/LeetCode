// Question 389. Find the Difference (https://leetcode-cn.com/problems/find-the-difference/)

/// <summary>
/// 执行用时：112 ms, 在所有 C# 提交中击败了 57.89% 的用户
/// 内存消耗：25.2 MB, 在所有 C# 提交中击败了 5.27% 的用户
/// </summary>
public class Solution 
{
    public char FindTheDifference(string s, string t) 
    {
        Dictionary<char, int> sCharCount = new Dictionary<char, int>();
        Dictionary<char, int> tCharCount = new Dictionary<char, int>();

        foreach (char c in s) 
        {
            sCharCount[c] = this.GetOrDefault(sCharCount, c) + 1;
        }

        foreach (char c in t) 
        {
            tCharCount[c] = this.GetOrDefault(tCharCount, c) + 1;
        }

        // System.Console.WriteLine($"sCharCount['t'] = {sCharCount['t']}, tCharCount['t'] = {tCharCount['t']}");

        foreach (char c in tCharCount.Keys)
        {
            if (!sCharCount.ContainsKey(c) || sCharCount[c] != tCharCount[c]) { return c; }
        }

        return s[0];
    }

    private int GetOrDefault(Dictionary<char, int> charCount, char searchChar)
    {
        if (!charCount.ContainsKey(searchChar)) { return 0; }
        

        return charCount[searchChar];
    }

    /// <summary>
    /// 执行用时：108 ms, 在所有 C# 提交中击败了 78.95% 的用户
    /// 内存消耗：24.5 MB, 在所有 C# 提交中击败了 45.26% 的用户
    /// 
    /// Acknowledgement: This solution borrows 2nd method from 
    /// the [official solution](https://leetcode-cn.com/problems/find-the-difference/solution/zhao-bu-tong-by-leetcode-solution-mtqf/)
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public char FindTheDifferenceByCalculatingSumDifference(string s, string t) 
    {
        int sSum = 0;
        int tSum = 0;

        foreach (char c in s) { sSum += (int) c; }
        foreach (char c in t) { tSum += (int) c; }


        return (char) (tSum - sSum);
    }
}