// Question 1052. Grumpy Bookstore Owner (https://leetcode-cn.com/problems/grumpy-bookstore-owner/)

/// <summary>
/// 执行用时：156 ms, 在所有 C# 提交中击败了 100.00% 的用户
/// 内存消耗：33.5 MB, 在所有 C# 提交中击败了 7.14% 的用户
/// </summary>
public class Solution 
{
    public int MaxSatisfied(int[] customers, int[] grumpy, int X) 
    {
        int MINUTES = customers.Count();
        int total = 0;
        for (var i = 0; i < MINUTES; i++)
        {
            total += (1 - grumpy[i]) * customers[i];
        }

        int maxIncrease = 0;
        int increase = 0;

        for (var i = 0; i < X; i++)
        {
            increase += grumpy[i] * customers[i];
        }
        maxIncrease = increase;

        for (var i = X; i < MINUTES; i++)
        {           
            increase = increase - grumpy[i - X] * customers[i - X] + grumpy[i] * customers[i];
            maxIncrease = Math.Max(maxIncrease, increase);
        }

        maxIncrease = Math.Max(maxIncrease, increase);

        return maxIncrease + total;
    }
}