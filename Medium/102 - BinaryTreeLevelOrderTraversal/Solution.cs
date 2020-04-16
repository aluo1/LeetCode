/// Question 102. Binary Tree Level Order Traversal (https://leetcode-cn.com/problems/binary-tree-level-order-traversal/)

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
    /// 执行用时 : 280 ms, 在所有 C# 提交中击败了 89.90% 的用户
    /// 内存消耗 : 31.2 MB, 在所有 C# 提交中击败了 12.50% 的用户

    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        IList<IList<int>> levelOrderTraversal = new List<IList<int>>();

        if (root == null) { return levelOrderTraversal; }

        Queue<(TreeNode, int)> queue = new Queue<(TreeNode, int)>();
        int orderLevel = 0;
        queue.Enqueue((root, orderLevel));

        IList<int> currentLevelTraversal = new List<int>();

        while (queue.Count > 0)
        {
            (TreeNode currentNode, int nodeLevel) = queue.Dequeue();

            if (nodeLevel == orderLevel)
            {
                currentLevelTraversal.Add(currentNode.val);
            }
            else
            {
                levelOrderTraversal.Add(currentLevelTraversal);
                currentLevelTraversal = new List<int>() { currentNode.val };
                orderLevel++;
            }

            if (currentNode.left != null)
            {
                queue.Enqueue((currentNode.left, nodeLevel + 1));
            }

            if (currentNode.right != null)
            {
                queue.Enqueue((currentNode.right, nodeLevel + 1));
            }
        }

        levelOrderTraversal.Add(currentLevelTraversal);

        return levelOrderTraversal;
    }
}