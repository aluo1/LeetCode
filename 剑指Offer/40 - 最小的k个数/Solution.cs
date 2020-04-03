/// 面试题40. 最小的k个数 (https://leetcode-cn.com/problems/zui-xiao-de-kge-shu-lcof/)
/// Difficulty: Easy

public class Solution
{
    public int[] GetLeastNumbers(int[] arr, int k) {
        // 执行用时: 328 ms, 在所有 C# 提交中击败了 84.31% 的用户
        // 内存消耗: 36.6 MB, 在所有 C# 提交中击败了 100.00% 的用户

        Array.Sort(arr);
        return arr.Take(k).ToArray();
    }
}