
/// Question 1071. Greatest Common Divisor of Strings (https://leetcode-cn.com/problems/greatest-common-divisor-of-strings/)
/// Difficulty: Easy

public class Solution
{
    public string GcdOfStrings(string str1, string str2)
    {
        /// 执行用时: 112 ms, 在所有 C# 提交中击败了 15.38% 的用户
        /// 内存消耗: 24.8 MB, 在所有 C# 提交中击败了 20.00% 的用户

        List<char> str1Char = str1.ToList().Distinct().ToList();
        List<char> str2Char = str2.ToList().Distinct().ToList();

        if (str1Char.Count != str2Char.Count || str1Char.Intersect(str2Char).Count() != str1Char.Count) { return ""; }

        string shorterStr, longerStr;
        if (str2.Length > str1.Length)
        {
            shorterStr = str1;
            longerStr = str2;
        }
        else
        {
            shorterStr = str2;
            longerStr = str1;
        }

        int leftCharIndex = 0;
        int divisorLength = shorterStr.Length;

        while (divisorLength != 0)
        {
            if (longerStr.Length % divisorLength == 0 && shorterStr.Length % divisorLength == 0)
            {

                string commonDivisor = shorterStr.Substring(leftCharIndex, divisorLength);
                if (longerStr.IndexOf(commonDivisor) != -1)
                {
                    int longerStrIndex = 0;
                    bool found = true;

                    while (longerStrIndex != longerStr.Length)
                    {
                        if (!longerStr.Substring(longerStrIndex, divisorLength).Equals(commonDivisor))
                        {
                            found = false;
                            break;
                        }
                        longerStrIndex += divisorLength;
                    }
                    if (found)
                    {
                        return commonDivisor;
                    }
                }
            }
            divisorLength--;
        }

        return "";
    }
}