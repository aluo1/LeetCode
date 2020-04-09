/// Question 20. Valid Parentheses (https://leetcode-cn.com/problems/valid-parentheses/)

public class Solution
{
    /// 执行用时 : 84 ms, 在所有 C# 提交中击败了 85.88% 的用户
    /// 内存消耗 : 22 MB, 在所有 C# 提交中击败了 11.54% 的用户

    private readonly Dictionary<char, char> VALID_BRACKETS = new Dictionary<char, char>() { { '(', ')' }, { '[', ']' }, { '{', '}' } };

    public bool IsValid(string s)
    {
        Stack<char> brackets = new Stack<char>();

        if (string.IsNullOrEmpty(s)) { return true; }

        brackets.Push(s[0]);

        for (int i = 1; i < s.Length; i++)
        {
            char currentChar = s[i];

            if (brackets.Count == 0 && !this.VALID_BRACKETS.Keys.Contains(currentChar))
            {
                return false;
            }

            if (this.VALID_BRACKETS.Keys.Contains(currentChar))
            {
                // current char is an openning bracket.
                brackets.Push(currentChar);
            }
            else
            {
                char prevChar = brackets.Peek();
                if (this.VALID_BRACKETS.Keys.Contains(prevChar) && this.VALID_BRACKETS[prevChar].Equals(currentChar))
                {
                    brackets.Pop();
                }
                else
                {
                    return false;
                }
            }
        }

        return brackets.Count == 0;
    }
}

public class SolutionWithLengthChecking
{
    /// 执行用时 : 96 ms, 在所有 C# 提交中击败了 32.70% 的用户
    /// 内存消耗 : 22 MB, 在所有 C# 提交中击败了 11.54% 的用户
    public bool IsValid(string s)
    {
        Stack<char> brackets = new Stack<char>();

        if (string.IsNullOrEmpty(s)) { return true; }
        if (s.Length % 2 != 0) { return false; }

        Dictionary<char, char> VALID_BRACKETS = new Dictionary<char, char>() { { '(', ')' }, { '[', ']' }, { '{', '}' } };
        brackets.Push(s[0]);

        for (int i = 1; i < s.Length; i++)
        {
            char currentChar = s[i];

            if (brackets.Count == 0 && !VALID_BRACKETS.Keys.Contains(currentChar))
            {
                return false;
            }

            if (VALID_BRACKETS.Keys.Contains(currentChar))
            {
                // current char is an openning bracket.
                brackets.Push(currentChar);
            }
            else
            {
                char prevChar = brackets.Peek();
                if (VALID_BRACKETS.Keys.Contains(prevChar) && VALID_BRACKETS[prevChar].Equals(currentChar))
                {
                    brackets.Pop();
                }
                else
                {
                    return false;
                }
            }
        }

        return brackets.Count == 0;
    }
}