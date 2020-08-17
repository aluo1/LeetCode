/** Question 110. Balanced Binary Tree (https://leetcode-cn.com/problems/balanced-binary-tree/) */

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
    /// <summary>
    /// This is the Top down solution provided by the [Leetcode Official](https://leetcode-cn.com/problems/balanced-binary-tree/solution/ping-heng-er-cha-shu-by-leetcode-solution/)
    /// 
    /// 执行用时：128 ms, 在所有 C# 提交中击败了 17.86% 的用户
    /// 内存消耗：27.3 MB, 在所有 C# 提交中击败了 85.71% 的用户 
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public bool IsBalanced(TreeNode root)
    {
        if (root == null)
        {
            return true;
        }

        return Math.Abs(HeightOfTree(root.left) - HeightOfTree(root.right)) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
    }

    /// <summary>
    /// Get the height of tree.
    /// </summary>
    /// <param name="tree"></param>
    /// <returns></returns>
    public int HeightOfTree(TreeNode tree)
    {
        if (tree == null)
        {
            return 0;
        }

        return Math.Max(HeightOfTree(tree.left), HeightOfTree(tree.right)) + 1;
    }
}


/// <summary>
/// This is the bottom up solution provided by the [Leetcode Official](https://leetcode-cn.com/problems/balanced-binary-tree/solution/ping-heng-er-cha-shu-by-leetcode-solution/)
///
/// 执行用时：116 ms, 在所有 C# 提交中击败了 79.29% 的用户
/// 内存消耗：27.3 MB, 在所有 C# 提交中击败了 71.43% 的用户
/// </summary>
public class BottomUpSolution
{
    public bool IsBalanced(TreeNode root)
    {
        return HeightOfTree(root) >= 0;
    }

    /** 
    * Get the height of tree.
    */
    public int HeightOfTree(TreeNode tree)
    {
        if (tree == null)
        {
            return 0;
        }

        int leftTreeHeight = HeightOfTree(tree.left);
        int rightTreeHeight = HeightOfTree(tree.right);

        if (leftTreeHeight == -1 || rightTreeHeight == -1 || Math.Abs(leftTreeHeight - rightTreeHeight) > 1)
        {
            return -1;
        }

        return Math.Max(leftTreeHeight, rightTreeHeight) + 1;
    }
}