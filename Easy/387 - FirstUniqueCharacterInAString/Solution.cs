// Question 387. First Unique Character in a String (https://leetcode-cn.com/problems/first-unique-character-in-a-string/)

/// <summary>
/// 执行用时：116 ms, 在所有 C# 提交中击败了 71.09% 的用户
/// 内存消耗：31.6 MB, 在所有 C# 提交中击败了 69.07% 的用户
/// </summary>
public class Solution 
{
    public int FirstUniqChar(string s) 
    {
        int N = s.Length;

        for (int i = 0; i < N; i++)
        {
            char currentChar = s[i];

            if (s.IndexOf(currentChar) == s.LastIndexOf(currentChar))
            {
                return i;
            }
        }

        return -1;
    }
}