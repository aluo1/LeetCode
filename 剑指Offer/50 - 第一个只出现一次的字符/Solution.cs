/// 面试题50. 第一个只出现一次的字符 (https://leetcode-cn.com/problems/di-yi-ge-zhi-chu-xian-yi-ci-de-zi-fu-lcof/)
/// Difficulty: Easy

using System.Collections.Specialized;

public class Solution
{
    public char FirstUniqChar(string s)
    {
        // 执行用时: 200 ms, 在所有 C# 提交中击败了 7.84% 的用户
        // 内存消耗: 34.6 MB, 在所有 C# 提交中击败了 100.00% 的用户

        Dictionary<char, (int, int)> freqDictionary = new Dictionary<char, (int, int)>();
        for (int i = 0; i < s.Length; i++)
        {
            char currentChar = s[i];
            if (freqDictionary.ContainsKey(currentChar))
            {
                (int, int) charInfo = freqDictionary[currentChar];
                freqDictionary[currentChar] = (charInfo.Item1 + 1, charInfo.Item2);
            }
            else
            {
                freqDictionary[currentChar] = (1, i);
            }
        }

        try
        {
            return freqDictionary?.Where(charFreqInfo => charFreqInfo.Value.Item1 == 1)
                                ?.OrderBy(charFreqInfo => charFreqInfo.Value.Item2)
                                ?.Select(charFreqInfo => charFreqInfo.Key)
                                ?.First() ?? ' ';
        }
        catch
        {
            return ' ';
        }
    }


    public char FirstUniqCharUsingOrderedDictionary(string s)
    {
        // 执行用时: 776 ms, 在所有 C# 提交中击败了 5.88% 的用户
        // 内存消耗: 36.9 MB, 在所有 C# 提交中击败了 100.00% 的用户
        OrderedDictionary freqDictionary = new OrderedDictionary();
        for (int i = 0; i < s.Length; i++)
        {
            char currentChar = s[i];
            if (freqDictionary.Contains(currentChar))
            {
                freqDictionary.Remove(currentChar);
                freqDictionary.Add(currentChar, false);
            }
            else
            {
                freqDictionary.Add(currentChar, true);
            }
        }

        try
        {
            foreach (DictionaryEntry dictionaryEntry in freqDictionary)
            {
                bool? uniqChar = dictionaryEntry.Value as bool?;
                if (uniqChar.HasValue && uniqChar.Value)
                {
                    char? uniqCharKey = dictionaryEntry.Key as char?;
                    return uniqCharKey.HasValue ? uniqCharKey.Value : ' ';
                }
            }

            return ' ';
        }
        catch
        {
            return ' ';
        }
    }

}