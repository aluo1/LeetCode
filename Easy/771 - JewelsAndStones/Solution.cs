/// Question 771. Jewels and Stones
/// Difficulty: Easy

public class Solution
{
    public int NumJewelsInStones(string J, string S)
    {
        return NumJewelsInStones(J, S);
    }

    public int NumJewelsInStonesIndexOf(string J, string S)
    {
        // 执行用时: 96 ms, 在所有 C# 提交中击败了 93.98% 的用户
        // 内存消耗: 23.2 MB, 在所有 C# 提交中击败了 5.00% 的用户
        int jewelsCount = 0;
        foreach (char s in S)
        {
            if (J.IndexOf(s) >= 0)
            {
                jewelsCount++;
            }
        }
        return jewelsCount;
    }

    public int NumJewelsInStonesLinq(string J, string S)
    {
        // 执行用时: 80 ms, 在所有 C# 提交中击败了 93.98% 的用户
        // 内存消耗: 23.2 MB, 在所有 C# 提交中击败了 5.00% 的用户
        int jewelsCount = 0;
        foreach (char s in S)
        {
            if (J.Contains(s))
            {
                jewelsCount++;
            }
        }
        return jewelsCount;
    }
}