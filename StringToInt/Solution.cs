/// Question 8. String to Integer (atoi) (https://leetcode-cn.com/problems/string-to-integer-atoi/)
/// Difficulty: Medium

using System.Text.RegularExpressions;

public class Solution
{
    public int MyAtoi(string str)
    {

    }

    public int MyAtoiFirstTry(string str)
    {
        // 执行用时: 88 ms, 在所有 C# 提交中击败了 88.83% 的用户
        // 内存消耗: 25.3 MB, 在所有 C# 提交中击败了 14.81% 的用户

        if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(str.Trim())) { return 0; }

        str = str.Trim();
        int integerSign = 1;

        char firstChar = str[0];
        if (firstChar != '+' && firstChar != '-' && !char.IsDigit(firstChar))
        {
            return 0;
        }

        string longestIntStr = "";
        if (firstChar == '-')
        {
            integerSign *= -1;
        }
        else if (char.IsDigit(firstChar))
        {
            longestIntStr += firstChar;
        }

        for (int i = 1; i < str.Length; i++)
        {
            if (char.IsDigit(str[i]))
            {
                longestIntStr += str[i];
            }
            else
            {
                break;
            }
        }

        int parsedInt = 0;
        if (longestIntStr.Length > 0)
        {
            try
            {
                parsedInt = integerSign * Int32.Parse(longestIntStr);
            }
            catch (OverflowException)
            {
                if (integerSign > 0)
                {
                    parsedInt = Int32.MaxValue;
                }
                else
                {
                    parsedInt = Int32.MinValue;
                }
            }
        }

        return parsedInt;
    }

    public int MyAtoiSecondTry(string str)
    {
        // 执行用时 : 132 ms, 在所有 C# 提交中击败了 11.44% 的用户
        // 内存消耗 : 28.5 MB, 在所有 C# 提交中击败了 7.41% 的用户
        Regex regex = new Regex(@"^[+|-]?\d+");
        MatchCollection matches = regex.Matches(str.Trim());

        if (matches.Count > 0)
        {
            string matchedString = matches[0].Value;

            try
            {
                return Math.Max(Math.Min(Int32.Parse(matchedString), Int32.MaxValue), Int32.MinValue);
            }
            catch (OverflowException)
            {
                return matchedString[0] == '-' ? Int32.MinValue : Int32.MaxValue;
            }
        };

        return 0;
    }
}