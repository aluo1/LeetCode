// Question 349. Intersection of Two Arrays (https://leetcode-cn.com/problems/intersection-of-two-arrays/)

using System;
using System.Collections.Generic;

public class Solution
{
    /// <summary>
    /// 执行用时：272 ms, 在所有 C# 提交中击败了 98.92% 的用户
    /// 内存消耗：31.5 MB, 在所有 C# 提交中击败了 12.36% 的用户
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns></returns>
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        HashSet<int> uniqueNum1 = new HashSet<int>(nums1);
        HashSet<int> uniqueNum2 = new HashSet<int>(nums2);

        uniqueNum1.RemoveWhere(num => !uniqueNum2.Contains(num));


        return uniqueNum1.ToArray();
    }
}