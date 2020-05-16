// Question 836. Rectangle Overlap (https://leetcode-cn.com/problems/rectangle-overlap/)

public class Solution
{
    // 执行用时: 132 ms, 在所有 C# 提交中击败了 17.50% 的用户
    // 内存消耗: 24.1 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public bool IsRectangleOverlap(int[] rec1, int[] rec2)
    {
        return !(rec1[0] >= rec2[2] || rec1[1] >= rec2[3] || rec2[0] >= rec1[2] || rec2[1] >= rec1[3]);
    }
}