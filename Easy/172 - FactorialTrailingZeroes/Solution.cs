/// Question 172. Factorial Trailing Zeroes (https://leetcode-cn.com/problems/factorial-trailing-zeroes/)

public class Solution
{
    // 执行用时: 48 ms, 在所有 C# 提交中击败了 78.48% 的用户
    // 内存消耗: 14.4 MB, 在所有 C# 提交中击败了 50.00% 的用户
    public int TrailingZeroes(int n)
    {
        int count = 0;
        while (n > 0)
        {
            count += n / 5;
            n /= 5;
        }

        return count;
    }
}