// Question 191. Number of 1 Bits (https://leetcode-cn.com/problems/number-of-1-bits/)

/// <summary>
/// 执行用时：48 ms, 在所有 C# 提交中击败了 65.25% 的用户
/// 内存消耗：16.2 MB, 在所有 C# 提交中击败了 5.67% 的用户
/// </summary>
public class Solution 
{
    public int HammingWeight(uint n) 
    {
        return Convert.ToString(n, 2).Where(elem => elem == '1').Count();
    }
}