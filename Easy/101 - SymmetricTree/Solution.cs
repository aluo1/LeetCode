/// Question 101. Symmetric Tree (https://leetcode-cn.com/problems/symmetric-tree/)

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
    /// 执行用时: 108 ms , 在所有 C# 提交中击败了 83.21% 的用户
    /// 内存消耗: 24.7 MB, 在所有 C# 提交中击败了 25.00% 的用户
    public bool IsSymmetric(TreeNode root)
    {
        return this.IsMirror(root, root);
    }

    private bool IsMirror(TreeNode tree1, TreeNode tree2)
    {
        if (tree1 == null && tree2 == null) { return true; }
        if (tree1 == null || tree2 == null) { return false; }

        return tree1.val == tree2.val &&
                this.IsMirror(tree1.left, tree2.right) &&
                this.IsMirror(tree1.right, tree2.left);

    }
}


public class SolutionUsingIteration
{
    /// 执行用时: 108 ms, 在所有 C# 提交中击败了 83.21% 的用户
    /// 内存消耗: 25.2 MB, 在所有 C# 提交中击败了 25.00% 的用户
    public bool IsSymmetric(TreeNode root)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        queue.Enqueue(root);

        while (queue.Any())
        {
            TreeNode node1 = queue.Dequeue();
            TreeNode node2 = queue.Dequeue();

            if (node1 == null && node2 == null) { continue; }
            if (node1 == null || node2 == null) { return false; }
            if (node1.val != node2.val) { return false; }

            queue.Enqueue(node1.left);
            queue.Enqueue(node2.right);
            queue.Enqueue(node1.right);
            queue.Enqueue(node2.left);
        }

        return true;
    }
}