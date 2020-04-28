/// Question 700. Search in a Binary Search Tree (https://leetcode-cn.com/problems/search-in-a-binary-search-tree/)

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
    // 执行用时: 160 ms, 在所有 C# 提交中击败了 17.14% 的用户
    // 内存消耗: 34.1 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public TreeNode SearchBST(TreeNode root, int val)
    {
        if (root == null) { return root; }

        if (root.val == val)
        {
            return root;
        }

        if (root.val > val)
        {
            return SearchBST(root.left, val);
        }
        else
        {
            return SearchBST(root.right, val);
        }
    }
}