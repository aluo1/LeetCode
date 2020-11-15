// Question 402. Remove K Digits (https://leetcode-cn.com/problems/remove-k-digits/)

/// <summary>
/// 执行用时：160 ms, 在所有 C# 提交中击败了 25.00% 的用户
/// 内存消耗：46.5 MB, 在所有 C# 提交中击败了 7.14% 的用户
/// 
/// Acknowledgement: This solution is a C#-version duplicate of the [official solution](https://leetcode-cn.com/problems/remove-k-digits/solution/yi-diao-kwei-shu-zi-by-leetcode-solution/)
/// </summary>
public class Solution 
{
    public string RemoveKdigits(string num, int k) 
    {
        List<char> digitList = new List<char>();
        int STRING_LENGTH = num.Count();

        for (int i = 0; i < STRING_LENGTH; i++)
        {
            char digit = num[i];

            while (digitList.Count() > 0 && k > 0 && digitList[digitList.Count() - 1] > digit)
            {
                digitList.RemoveAt(digitList.Count() - 1);
                k--;
            }

            digitList.Add(digit);
        }

        while (k > 0)
        {
            digitList.RemoveAt(digitList.Count() - 1);
            k--;
        }

        string answer = "";
        bool isLeadingZero = true;
        foreach (char digit in digitList)
        {
            if (isLeadingZero && digit == '0') { continue; }

            isLeadingZero = false;
            answer += digit;
        }

        return string.IsNullOrEmpty(answer) ? "0" : answer;
    }
}