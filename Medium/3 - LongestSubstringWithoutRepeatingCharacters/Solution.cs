/// Question 3. Longest Substring Without Repeating Characters (https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/)

public class Solution
{
    // 执行用时: 104 ms, 在所有 C# 提交中击败了 61.99% 的用户
    // 内存消耗: 25.8 MB, 在所有 C# 提交中击败了 6.67% 的用户
    // Acknowledgement: This idea is borrowed from the [official solution](https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/solution/wu-zhong-fu-zi-fu-de-zui-chang-zi-chuan-by-leetc-2/)
    public int LengthOfLongestSubstring(string s)
    {
        HashSet<char> uniqueChars = new HashSet<char>();
        int sLength = s.Length;

        int rightPointer = -1;
        int ans = 0;

        for (int i = 0; i < sLength; i++)
        {
            if (i != 0)
            {
                uniqueChars.Remove(s[i - 1]);
            }

            while (rightPointer + 1 < sLength && !uniqueChars.Contains(s[rightPointer + 1]))
            {
                uniqueChars.Add(s[rightPointer + 1]);
                rightPointer++;
            }

            ans = Math.Max(rightPointer + 1 - i, ans);
        }

        return ans;
    }
}