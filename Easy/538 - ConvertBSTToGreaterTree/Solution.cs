/**
 * Question 538. Convert BST to Greater Tree (https://leetcode-cn.com/problems/convert-bst-to-greater-tree/)
 *
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
    /// <summary>
    /// 执行用时：136 ms, 在所有 C# 提交中击败了 45.31% 的用户
    /// 内存消耗：28.7 MB, 在所有 C# 提交中击败了 23.68% 的用户
    /// 
    /// Acknowledgement: This is the provided answer, which utilize reverse-inorder-traverse.
    /// </summary>

    private int sum = 0;

    public TreeNode ConvertBST(TreeNode root)
    {
        if (root != null)
        {
            ConvertBST(root.right);
            sum += root.val;
            root.val = sum;
            ConvertBST(root.left);
        }

        return root;
    }
}