/// Question 145. Binary Tree Postorder Traversal (https://leetcode-cn.com/problems/binary-tree-postorder-traversal/)

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
    /// 执行用时 : 276 ms , 在所有 C# 提交中击败了 83.33% 的用户
    /// 内存消耗 : 30.3 MB, 在所有 C# 提交中击败了 25.00% 的用户

    public IList<int> PostorderTraversal(TreeNode root)
    {
        IList<int> traversedNodes = new List<int>();

        if (root != null)
        {
            traversedNodes = traversedNodes.Concat(PostorderTraversal(root.left)).ToList();
            traversedNodes = traversedNodes.Concat(PostorderTraversal(root.right)).ToList();
            traversedNodes.Add(root.val);
        }

        return traversedNodes;
    }
}