// Question 338. Counting Bits (https://leetcode-cn.com/problems/counting-bits/)

/// <summary>
/// 执行用时：248 ms, 在所有 C# 提交中击败了 82.61% 的用户
/// 内存消耗：29.2 MB, 在所有 C# 提交中击败了 50.00% 的用户
/// 
/// This solution is similar to the mnethod II of the 
/// [official solution](https://leetcode-cn.com/problems/counting-bits/solution/bi-te-wei-ji-shu-by-leetcode-solution-0t1i/).
/// </summary>
public class Solution 
{
    public int[] CountBits(int num) 
    {
        int[] counts = new int[num+1];
        int nearestPower = 0;

        Array.Fill(counts, 0);

        for (int i = 1; i <= num; i++)
        {
            if (i == 1) 
            { 
                counts[i] = 1;
                nearestPower = 1;
                continue;
            }

            if (i == nearestPower * 2)
            {
                counts[i] = 1;
                nearestPower *= 2;
            }
            else
            {
                int remainingValue = i - nearestPower;

                // System.Console.WriteLine($"counts[{i}] = {counts[i]}, counts[{nearestPower}] = {counts[nearestPower]}, counts[{remainingValue}] = {counts[remainingValue]}");

                counts[i] = counts[nearestPower] + counts[remainingValue];
            }
        }

        return counts;
    }
}