/// Question 4. Median of Two Sorted Arrays (https://leetcode-cn.com/problems/median-of-two-sorted-arrays/)

public class Solution
{
    // 执行用时: 164 ms, 在所有 C# 提交中击败了 23.48% 的用户
    // 内存消耗: 27.8 MB, 在所有 C# 提交中击败了 15.38% 的用户
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        List<int> mergedNums = new List<int>(nums1).Concat(new List<int>(nums2)).ToList();
        mergedNums.Sort();

        if (mergedNums.Count % 2 == 0)
        {
            return (mergedNums.ElementAt(mergedNums.Count / 2) + mergedNums.ElementAt(mergedNums.Count / 2 - 1)) / 2.0;
        }

        return (double)mergedNums.ElementAt(mergedNums.Count / 2);
    }
}