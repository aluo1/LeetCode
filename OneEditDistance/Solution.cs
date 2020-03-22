/// Question 161. One Edit Distance (https://leetcode-cn.com/problems/one-edit-distance/)
/// Difficulty: Medium
/// 执行用时: 88 ms, 在所有 C# 提交中击败了 60.00% 的用户
/// 内存消耗: 23.9 MB, 在所有 C# 提交中击败了 100.00% 的用户

public class Solution
{
    public bool IsOneEditDistance(string s, string t)
    {
        int sLength = s.Length;
        int tLength = t.Length;

        // s is always shorter than t;
        if (sLength > tLength)
        {
            return IsOneEditDistance(t, s);
        }

        if (tLength - sLength > 1)
        {
            return false;
        }

        bool diffFound = false;
        for (int i = 0; i < sLength; i++)
        {
            if (!char.Equals(s[i], t[i]))
            {
                if (sLength != tLength)
                {
                    return string.Equals(s.Substring(i), t.Substring(i + 1));
                }
                else
                {
                    return string.Equals(s.Substring(i + 1), t.Substring(i + 1));
                }
            }
        }

        return tLength - sLength == 1;
    }
}