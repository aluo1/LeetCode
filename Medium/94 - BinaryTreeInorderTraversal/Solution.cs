/// Question 94. Binary Tree Inorder Traversal (https://leetcode-cn.com/problems/binary-tree-inorder-traversal/)

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
    // 执行用时: 292 ms, 在所有 C# 提交中击败了 32.51% 的用户
    // 内存消耗: 30.2 MB, 在所有 C# 提交中击败了 9.09% 的用户

    public IList<int> InorderTraversal(TreeNode root)
    {
        IList<int> traversedNodes = new List<int>();

        if (root != null)
        {
            traversedNodes = traversedNodes.Concat(InorderTraversal(root.left)).ToList();
            traversedNodes.Add(root.val);
            traversedNodes = traversedNodes.Concat(InorderTraversal(root.right)).ToList();
        }

        return traversedNodes;
    }
}

public class SolutionUsingStack
{
    // 执行用时: 276 ms, 在所有 C# 提交中击败了 85.87% 的用户
    // 内存消耗: 30 MB, 在所有 C# 提交中击败了 9.09% 的用户
    public IList<int> InorderTraversal(TreeNode root)
    {
        IList<int> traversedNodes = new List<int>();

        if (root == null) { return traversedNodes; }

        Stack<TreeNode> treeStack = new Stack<TreeNode>();
        TreeNode currentNode = root;

        while (currentNode != null || treeStack.Count > 0)
        {
            while (currentNode != null)
            {
                treeStack.Push(currentNode);
                currentNode = currentNode.left;
            }

            currentNode = treeStack.Pop();
            traversedNodes.Add(currentNode.val);

            currentNode = currentNode.right;
        }

        return traversedNodes;
    }
}