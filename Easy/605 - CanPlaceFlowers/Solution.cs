// Question 605. Can Place Flowers (https://leetcode-cn.com/problems/can-place-flowers/)

/// <summary>
/// 执行用时：136 ms, 在所有 C# 提交中击败了 51.85% 的用户
/// 内存消耗：29.6 MB, 在所有 C# 提交中击败了 71.30% 的用户
/// </summary>
public class Solution 
{
    public bool CanPlaceFlowers(int[] flowerbed, int n) 
    {
        if (n == 0) { return true; }

        int plotsCount = flowerbed.Count();

        for (int i = 0; i < plotsCount; i++)
        {
            if (flowerbed[i] == 0)
            {
                if ((i - 1 < 0 || (i - 1 >= 0 && flowerbed[i - 1] == 0)) &&
                    (i + 1 >= plotsCount || (i + 1 < plotsCount && flowerbed[i + 1] == 0)))
                {
                    n--;
                    flowerbed[i] = 1;
                    if (n == 0) { return true; }
                }
            }
        }

        return n == 0;
    }
}