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