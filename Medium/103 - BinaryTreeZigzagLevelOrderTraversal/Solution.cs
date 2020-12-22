// Question 103. Binary Tree Zigzag Level Order Traversal (https://leetcode-cn.com/problems/binary-tree-zigzag-level-order-traversal/)

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
/// 执行用时：284 ms, 在所有 C# 提交中击败了 86.21% 的用户
/// 内存消耗：30.2 MB, 在所有 C# 提交中击败了 52.33% 的用户
/// 
/// Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/binary-tree-zigzag-level-order-traversal/solution/er-cha-shu-de-ju-chi-xing-ceng-xu-bian-l-qsun/)
/// </summary>
public class Solution 
{
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) 
    {
        List<IList<int>> zigzagTree = new List<IList<int>>();
        if (root == null) { return zigzagTree; }

        Queue<TreeNode> currentLevelNodes = new Queue<TreeNode>();
        currentLevelNodes.Enqueue(root);
        bool isFromLeft = true;

        while (currentLevelNodes.Count() > 0)
        {
            List<int> currentLevelNodesValue = new List<int>();

            int nodeCounts = currentLevelNodes.Count();
            for (int i = 0; i < nodeCounts; i++)
            {
                TreeNode currentNode = currentLevelNodes.Dequeue();

                if (isFromLeft) 
                {
                    currentLevelNodesValue.Add(currentNode.val);
                }
                else
                {
                    currentLevelNodesValue.Insert(0, currentNode.val);
                }

                if (currentNode.left != null)
                {
                    currentLevelNodes.Enqueue(currentNode.left);
                }

                if (currentNode.right != null)
                {
                    currentLevelNodes.Enqueue(currentNode.right);
                }
            }

            zigzagTree.Add(currentLevelNodesValue);
            isFromLeft = !isFromLeft;
        }

        return zigzagTree;
    }
}