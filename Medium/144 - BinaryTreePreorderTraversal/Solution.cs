/// Question 144. Binary Tree Preorder Traversal (https://leetcode-cn.com/problems/binary-tree-preorder-traversal/)

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
    /// 执行用时 : 316 ms, 在所有 C# 提交中击败了 27.43% 的用户
    /// 内存消耗 : 30.2 MB, 在所有 C# 提交中击败了 14.29% 的用户

    public IList<int> PreorderTraversal(TreeNode root)
    {
        IList<int> traversedNodes = new List<int>();

        if (root != null)
        {
            traversedNodes.Add(root.val);
            traversedNodes = traversedNodes.Concat(PreorderTraversal(root.left)).ToList();
            traversedNodes = traversedNodes.Concat(PreorderTraversal(root.right)).ToList();
        }

        return traversedNodes;
    }
}

public class SolutionDFS
{
    /// 执行用时: 272 ms, 在所有 C# 提交中击败了 93.14% 的用户
    /// 内存消耗: 30 MB, 在所有 C# 提交中击败了 14.29% 的用户
    public IList<int> PreorderTraversal(TreeNode root)
    {
        IList<int> traversedNodes = new List<int>();

        if (root == null) { return traversedNodes; }

        Stack<TreeNode> treeStack = new Stack<TreeNode>();
        treeStack.Push(root);

        while (treeStack.Count > 0)
        {
            TreeNode currentNode = treeStack.Pop();
            traversedNodes.Add(currentNode.val);

            if (currentNode.right != null)
            {
                treeStack.Push(currentNode.right);
            }

            if (currentNode.left != null)
            {
                treeStack.Push(currentNode.left);
            }
        }

        return traversedNodes;
    }
}