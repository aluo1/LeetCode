/// Question 202. Happy Number (https://leetcode-cn.com/problems/happy-number/submissions/)

public class Solution
{
    // 执行用时: 56 ms, 在所有 C# 提交中击败了 27.27% 的用户
    // 内存消耗: 16.7 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public bool IsHappy(int n)
    {
        HashSet<int> numberSet = new HashSet<int>();
        while (n != 1 && !numberSet.Contains(n))
        {
            numberSet.Add(n);
            n = this.GetSumOfDigit(n);
        }

        return n == 1;
    }

    private int GetSumOfDigit(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            int digit = n % 10;
            n /= 10;
            sum += digit * digit;
        }

        return sum;
    }
}