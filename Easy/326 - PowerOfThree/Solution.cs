/// Question 326. Power of Three
/// Difficulty: Easy
/// 执行用时: 88 ms, 在所有 C# 提交中击败了 94.89% 的用户
/// 内存消耗: 16.6 MB, 在所有 C# 提交中击败了 50.00% 的用户

public class Solution
{
    public bool IsPowerOfThree(int n)
    {
        if (n <= 0) { return false; }

        if (n == 1) { return true; }

        while (n > 1)
        {
            if (n % 3 != 0)
            {
                return false;
            }

            n /= 3;
        }

        return true;
    }
}