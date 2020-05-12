/// Question 572. Subtree of Another Tree (https://leetcode-cn.com/problems/subtree-of-another-tree/)

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
    // 执行用时: 164 ms, 在所有 C# 提交中击败了 18.18% 的用户
    // 内存消耗: 27.9 MB, 在所有 C# 提交中击败了 100.00% 的用户

    Queue<TreeNode> nodes = new Queue<TreeNode>();
    public bool IsSubtree(TreeNode s, TreeNode t)
    {
        if (s == null && t == null) { return true; }
        if (s == null || t == null) { return false; }

        this.GetNodeWithSameValue(s, t.val);
        if (this.nodes.Count == 0) { return false; }

        while (this.nodes.Any())
        {
            TreeNode subTreeS = this.nodes.Dequeue();
            bool exists = this.AreSameTree(subTreeS, t);
            if (exists) { return exists; }
        }

        return false;
    }

    private void GetNodeWithSameValue(TreeNode s, int value)
    {
        if (s == null) { return; }
        if (s.val == value) { this.nodes.Enqueue(s); }
        this.GetNodeWithSameValue(s.left, value);
        this.GetNodeWithSameValue(s.right, value);
    }

    private bool AreSameTree(TreeNode s, TreeNode t)
    {
        if (s == null && t == null) { return true; }
        if (s == null || t == null) { return false; }
        if (s.val != t.val) { return false; }
        return this.AreSameTree(s.left, t.left) && this.AreSameTree(s.right, t.right);
    }
}

public class SolutionRecursionOnly
{
    // 执行用时: 136 ms, 在所有 C# 提交中击败了 54.55% 的用户
    // 内存消耗: 27.9 MB, 在所有 C# 提交中击败了 100.00% 的用户
    // Acknowledgement: The main section is implemented by myself, but the idea of removing queue is borrowed from [this solution](https://leetcode-cn.com/problems/subtree-of-another-tree/solution/java-di-gui-ban-by-kelly2018/)

    public bool IsSubtree(TreeNode s, TreeNode t)
    {
        if (t == null) { return true; }
        if (s == null) { return false; }

        return this.AreSameTree(s, t) || this.IsSubtree(s.left, t) || this.IsSubtree(s.right, t);
    }

    private bool AreSameTree(TreeNode s, TreeNode t)
    {
        if (s == null && t == null) { return true; }
        if (s == null || t == null) { return false; }
        if (s.val != t.val) { return false; }
        return this.AreSameTree(s.left, t.left) && this.AreSameTree(s.right, t.right);
    }
}