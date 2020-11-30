// Question 767. Reorganize String (https://leetcode-cn.com/problems/reorganize-string/)

/// <summary>
/// 执行用时：96 ms, 在所有 C# 提交中击败了 88.89% 的用户
/// 内存消耗：23 MB, 在所有 C# 提交中击败了 25.00% 的用户
/// 
/// Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/reorganize-string/solution/zhong-gou-zi-fu-chuan-by-leetcode-solution/)
/// </summary>
public class Solution 
{
    public string ReorganizeString(string S) 
    {
        int N = S.Length;
        int maxFreq = 0;
        Dictionary<char, int> charFreq = new Dictionary<char, int>();
        HashSet<char> uniqueChars = new HashSet<char>();

        foreach (char c in S)
        {
            uniqueChars.Add(c);

            if (charFreq.ContainsKey(c))
            {
                charFreq[c] += 1;
                maxFreq = Math.Max(maxFreq, charFreq[c]);
            }
            else
            {
                charFreq[c] = 1;
            }
        }

        if (maxFreq > (N + 1) / 2) { return ""; }

        char[] reorganizedString = new char[N];
        int evenIndex = 0;
        int oddIndex = 1;
        int halfLength = N / 2;
        for (int i = 0; i < 26; i++) 
        {
            char c = (char) ('a' + i);
            // System.Console.WriteLine(c);

            if (charFreq.ContainsKey(c))
            {
                while (charFreq[c] > 0 && charFreq[c] <= halfLength && oddIndex < N)
                {
                    reorganizedString[oddIndex] = c;
                    charFreq[c]--;
                    oddIndex += 2;
                }

                while (charFreq[c] > 0)
                {
                    reorganizedString[evenIndex] = c;
                    charFreq[c]--;
                    evenIndex += 2;
                }
            }
        }

        return string.Join("", reorganizedString);
    }
}