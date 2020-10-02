using System.Collections.Generic;
/// Question 771. Jewels and Stones (https://leetcode-cn.com/problems/jewels-and-stones/)
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

    public int NumJewelsInStonesSet(string J, string S)
    {
        // 执行用时：92 ms, 在所有 C# 提交中击败了 45.61% 的用户
        // 内存消耗：22.7 MB , 在所有 C# 提交中击败了 65.69% 的用户
        HashSet<char> jewels = new HashSet<char>();
        foreach (char jewel in J)
        {
            jewels.Add(jewel);
        }

        int jewelsCount = 0;
        foreach (char stone in S)
        {
            if (jewels.Contains(stone))
            {
                jewelsCount++;
            }
        }

        return jewelsCount;
    }
}