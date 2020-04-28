/// Question 98. Validate Binary Search Tree (https://leetcode-cn.com/problems/validate-binary-search-tree/)

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
    // 执行用时: 116 ms , 在所有 C# 提交中击败了 74.62% 的用户
    // 内存消耗: 26.2 MB, 在所有 C# 提交中击败了 33.33% 的用户
    // Acknowledgement: This solution is borrowed from [this solution](https://leetcode-cn.com/problems/validate-binary-search-tree/solution/yan-zheng-er-cha-sou-suo-shu-shang-xia-jie-pan-din/)
    public bool IsValidBST(TreeNode root)
    {
        return this.IsValidBST(root, null, null);
    }

    private bool IsValidBST(TreeNode root, TreeNode min, TreeNode max)
    {
        if (root == null) { return true; }

        if (min != null && root.val <= min.val) { return false; }
        if (max != null && root.val >= max.val) { return false; }

        return this.IsValidBST(root.left, min, root) && this.IsValidBST(root.right, root, max);
    }
}