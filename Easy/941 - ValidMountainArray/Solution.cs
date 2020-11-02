// Question 941. Valid Mountain Array (https://leetcode-cn.com/problems/valid-mountain-array/)

public class Solution
{
    /// <summary>
    /// 执行用时：156 ms, 在所有 C# 提交中击败了 44.19% 的用户
    /// 内存消耗：32.8 MB, 在所有 C# 提交中击败了 17.14% 的用户
    /// </summary>
    /// <param name="A"></param>
    /// <returns></returns>
    public bool ValidMountainArray(int[] A)
    {
        var aLength = A.Count();
        if (aLength < 3)
        {
            return false;
        }

        var peak = A[0];
        var previousValue = A[0];
        var isDeclining = false;

        for (int i = 1; i < aLength; i++)
        {
            var currentValue = A[i];
            if (currentValue == previousValue) { return false; }

            if (isDeclining)
            {
                if (currentValue >= previousValue)
                {
                    return false;
                }
            }
            else
            {
                if (currentValue > peak)
                {
                    peak = currentValue;
                }
                else
                {
                    if (i == 1) { return false; }
                    isDeclining = true;
                }
            }

            previousValue = currentValue;
        }

        return isDeclining;
    }
}