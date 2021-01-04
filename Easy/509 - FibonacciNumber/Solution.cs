// Question 509. Fibonacci Number (https://leetcode-cn.com/problems/fibonacci-number/)

/// <summary>
/// 执行用时：56 ms, 在所有 C# 提交中击败了 38.69% 的用户
/// 内存消耗：14.8 MB, 在所有 C# 提交中击败了 74.82% 的用户
/// </summary>
public class Solution 
{
    public int Fib(int n) 
    {
        if (n < 2) { return n; }
        return Fib(n - 1) + Fib(n - 2);
    }
}