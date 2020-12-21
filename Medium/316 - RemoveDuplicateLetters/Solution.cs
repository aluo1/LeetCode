// Question 316. Remove Duplicate Letters (https://leetcode-cn.com/problems/remove-duplicate-letters/)

/// <summary>
/// 执行用时：96 ms, 在所有 C# 提交中击败了 96.88% 的用户
/// 内存消耗：23.9 MB, 在所有 C# 提交中击败了 50.00% 的用户
/// 
/// Acknowledgement: This solution is a C#-version duplicate of the [official solution]
/// (https://leetcode-cn.com/problems/remove-duplicate-letters/solution/qu-chu-zhong-fu-zi-mu-by-leetcode-soluti-vuso/)
/// </summary>
public class Solution 
{
    public string RemoveDuplicateLetters(string s) 
    {
        bool[] vis = new bool[26];
        int[] num = new int[26];

        foreach (char c in s) { num[(int)(c - 'a')]++; }

        string str = "";
        foreach (char c in s)
        {
            if (!vis[(int)(c - 'a')])
            {
                while (!string.IsNullOrEmpty(str) && str[str.Length - 1] > c)
                {
                    if (num[(int)(str[str.Length - 1] - 'a')] > 0)
                    {
                        vis[(int)(str[str.Length - 1] - 'a')] = 0;
                        str = str.Substring(0, str.Length - 1);
                    }   
                    else
                    {
                        break;
                    }
                }

                vis[(int)(c - 'a')] = true;
                str += c;
            }

            num[(int)(c - 'a')] -= 1;
        }

        return str;
    }
}