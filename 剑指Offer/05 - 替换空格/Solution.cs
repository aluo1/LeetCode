/// 面试题05. 替换空格 (https://leetcode-cn.com/problems/ti-huan-kong-ge-lcof/)
/// Difficulty: Easy
/// 执行用时: 100 ms, 在所有 C# 提交中击败了 69.34% 的用户
/// 内存消耗: 24.9 MB, 在所有 C# 提交中击败了 100.00% 的用户
public class Solution
{
    public string ReplaceSpace(string s)
    {
        string updatedString = "";
        for (int i = 0; i < s.Length; i++)
        {
            updatedString += s[i] == ' ' ? "%20" : s[i].ToString();
        }

        return updatedString;
    }
}