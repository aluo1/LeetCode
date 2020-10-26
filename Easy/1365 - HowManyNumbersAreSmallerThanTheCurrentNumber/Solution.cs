// Question 1365. How Many Numbers Are Smaller Than the Current Number (https://leetcode-cn.com/problems/how-many-numbers-are-smaller-than-the-current-number/)

public class Solution
{
    /// <summary>
    /// 执行用时：304 ms, 在所有 C# 提交中击败了 67.83% 的用户
    /// 内存消耗：32.1 MB, 在所有 C# 提交中击败了 5.51% 的用户
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] SmallerNumbersThanCurrent(int[] nums)
    {
        int originalArraySize = nums.Count();
        if (originalArraySize == 0) { return nums; }

        Dictionary<int, int> counts = new Dictionary<int, int>();
        int[] sorted = new int[originalArraySize];

        Array.Copy(nums, sorted, originalArraySize);
        Array.Sort(sorted);

        (int last, int lastCount) = (sorted[0], 0);
        counts[last] = lastCount;

        for (var i = 1; i < originalArraySize; i++)
        {
            // Console.WriteLine($"last = {last}, lastCount = {lastCount}");
            var num = sorted[i];
            lastCount++;
            if (num == last) { continue; }

            counts[num] = lastCount;
            last = num;
        }

        int[] results = new int[originalArraySize];
        for (var i = 0; i < originalArraySize; i++)
        {
            results[i] = counts[nums[i]];
        }

        return results;
    }
}