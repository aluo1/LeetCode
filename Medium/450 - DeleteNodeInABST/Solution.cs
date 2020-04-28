/// Question 450. Delete Node in a BST (https://leetcode-cn.com/problems/delete-node-in-a-bst/)

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
    // 执行用时: 128 ms, 在所有 C# 提交中击败了 78.57% 的用户
    // 内存消耗: 30 MB, 在所有 C# 提交中击败了 11.11% 的用户
    // Acknowledgement: This idea is borrowed from the [official solution](https://leetcode-cn.com/problems/delete-node-in-a-bst/solution/shan-chu-er-cha-sou-suo-shu-zhong-de-jie-dian-by-l/)
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        if (root == null) { return root; }

        if (root.val > key)
        {
            root.left = this.DeleteNode(root.left, key);
        }
        else if (root.val < key)
        {
            root.right = this.DeleteNode(root.right, key);
        }
        else
        {
            if (root.left == null && root.right == null)
            {
                root = null;
            }
            else if (root.left == null)
            {
                // Find the successor.
                root.val = this.InorderTraversedSuccessorValue(root);
                root.right = this.DeleteNode(root.right, root.val);
            }
            else
            {
                // Find the predecessor.
                root.val = this.InorderTraversedPredecessorValue(root);
                root.left = this.DeleteNode(root.left, root.val);
            }
        }

        return root;
    }

    private int InorderTraversedSuccessorValue(TreeNode root)
    {
        // The assumption is that root is not null.
        root = root.right;
        while (root.left != null) { root = root.left; }
        return root.val;
    }

    private int InorderTraversedPredecessorValue(TreeNode root)
    {
        // The assumption is that root is not null.
        root = root.left;
        while (root.right != null) { root = root.right; }
        return root.val;
    }
}


