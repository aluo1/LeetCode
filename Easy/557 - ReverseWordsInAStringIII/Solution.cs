/// Question 557. Reverse Words in a String III (https://leetcode-cn.com/problems/reverse-words-in-a-string-iii/)

public class Solution
{
    // 执行用时: 180 ms, 在所有 C# 提交中击败了 22.67% 的用户
    // 内存消耗: 35.1 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public string ReverseWords(string s)
    {
        return string.Join(" ", s.Split(" ").Select(word =>
        {
            char[] charArray = word.ToArray();
            Array.Reverse(charArray);
            return string.Join("", charArray);
        }));
    }
}

/// <summary>
/// 执行用时：264 ms, 在所有 C# 提交中击败了 13.68% 的用户
/// 内存消耗：42.9 MB, 在所有 C# 提交中击败了 12.50% 的用户
/// </summary>
public class SolutionTwo
{
    public string ReverseWords(string s)
    {
        string reversedWords = "";
        string[] words = s.Split(" ");
        int wordsCount = words.Length;

        for (int i = 0; i < wordsCount; i++)
        {
            string word = words[i];
            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);
            string reversedWord = string.Join("", charArray);

            reversedWords += reversedWord;
            if (i != wordsCount - 1)
            {
                reversedWords += " ";
            }
        }

        return reversedWords;
    }
}