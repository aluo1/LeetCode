/// Question 100. Same Tree (https://leetcode-cn.com/problems/same-tree/)

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution
{
    // 执行用时: 100 ms, 在所有 C# 提交中击败了 97.02% 的用户
    // 内存消耗: 24.3 MB, 在所有 C# 提交中击败了 16.67% 的用户
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p != null && q != null)
        {
            if (p.val != q.val) { return false; }

            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        return p == null && q == null;
    }
}