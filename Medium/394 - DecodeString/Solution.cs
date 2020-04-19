/// Question 394. Decode String (https://leetcode-cn.com/problems/decode-string/)

public class Solution
{
    /// 执行用时: 96 ms, 在所有 C# 提交中击败了 90.00% 的用户
    /// 内存消耗: 22.9 MB, 在所有 C# 提交中击败了 50.00% 的用户
    public string DecodeString(string s)
    {
        Stack<(int, string)> stack = new Stack<(int, string)>();
        string str = "";
        int multi = 0;

        foreach (char character in s)
        {
            if (character.Equals('['))
            {
                stack.Push((multi, str));
                multi = 0;
                str = "";
            }
            else if (character.Equals(']'))
            {
                (int multiplier, string lastRecodedString) = stack.Pop();
                str = lastRecodedString + string.Concat(Enumerable.Repeat(str, multiplier));
            }
            else if (char.IsNumber(character))
            {
                multi = multi * 10 + int.Parse(character.ToString());
            }
            else
            {
                str += character.ToString();
            }
        }

        return str;
    }
}