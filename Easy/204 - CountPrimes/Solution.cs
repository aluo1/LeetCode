// Question 204. Count Primes (https://leetcode-cn.com/problems/count-primes/)

/// <summary>
/// 执行用时：944 ms, 在所有 C# 提交中击败了 5.36% 的用户
/// 内存消耗：14.8 MB, 在所有 C# 提交中击败了 81.71% 的用户
/// </summary>
public class Solution 
{
    public int CountPrimes(int n) 
    {
        if (n <= 1) { return 0; }

        int count = 0;
        for (int i = 2; i < n; i++) 
        {
            count += this.IsPrime(i) ? 1 : 0;
        }

        return count;
    }

    private bool IsPrime(int n)
    {
        for (int i = 2; i * i <= n; i++) 
        {
            if (n % i == 0) { return false; }
        }

        return true;
    }
}