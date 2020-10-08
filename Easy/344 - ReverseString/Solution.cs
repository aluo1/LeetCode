// Question 344. Reverse String (https://leetcode-cn.com/problems/reverse-string/)

public class Solution
{
    /// <summary>
    /// 执行用时：440 ms, 在所有 C# 提交中击败了 95.36% 的用户
    /// 内存消耗：33.9 MB, 在所有 C# 提交中击败了 62.25% 的用户
    /// </summary>
    /// <param name="s"></param>
    public void ReverseString(char[] s)
    {
        int N = s.Count();

        for (int i = 0; i < N / 2; i++)
        {
            var character = s[i];
            var reverseIndex = N - 1 - i;
            s[i] = s[reverseIndex];
            s[reverseIndex] = character;
        }
    }
}