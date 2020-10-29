// Question 129. Sum Root to Leaf Numbers (https://leetcode-cn.com/problems/sum-root-to-leaf-numbers/)

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

/// <summary>
/// 执行用时：112 ms, 在所有 C# 提交中击败了 58.82% 的用户
/// 内存消耗：24.3 MB, 在所有 C# 提交中击败了 16.33% 的用户
/// </summary>
public class Solution
{
    private int _sum = 0;

    public int SumNumbers(TreeNode root)
    {
        if (root == null) { return this._sum; }

        if (root.left == null && root.right == null) { return root.val; }

        this.TraverseUntilLeaf(root.left, root.val);
        this.TraverseUntilLeaf(root.right, root.val);

        return this._sum;
    }

    private void TraverseUntilLeaf(TreeNode root, int accumulatedValue)
    {
        if (root == null)
        {
            return;
        }

        accumulatedValue = accumulatedValue * 10 + root.val;

        Console.WriteLine($"root = {root.val}, accumulatedValue = {accumulatedValue}");

        if (root.left == null && root.right == null)
        {
            this._sum += accumulatedValue;
            return;
        }

        if (root.left != null)
        {
            this.TraverseUntilLeaf(root.left, accumulatedValue);
        }

        if (root.right != null)
        {
            this.TraverseUntilLeaf(root.right, accumulatedValue);
        }
    }
}