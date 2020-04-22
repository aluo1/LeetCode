/// Question 199. Binary Tree Right Side View (https://leetcode-cn.com/problems/binary-tree-right-side-view/)

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
    // 执行用时: 280 ms, 在所有 C# 提交中击败了 80.65% 的用户
    // 内存消耗: 31.2 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public IList<int> RightSideView(TreeNode root)
    {
        List<int> rightSideView = new List<int>();
        if (root == null) { return rightSideView; }

        Dictionary<int, int> depthNodeVal = new Dictionary<int, int>();
        int maxDepth = -1;

        Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
        nodeQueue.Enqueue(root);
        TreeNode currentNode = root;

        Queue<int> depthQueue = new Queue<int>();
        depthQueue.Enqueue(0);
        int currentDepth = 0;

        while (nodeQueue.Any() && depthQueue.Any())
        {
            currentNode = nodeQueue.Dequeue();
            currentDepth = depthQueue.Dequeue();

            if (currentNode != null)
            {
                maxDepth = Math.Max(maxDepth, currentDepth);

                depthNodeVal[currentDepth] = currentNode.val;

                nodeQueue.Enqueue(currentNode.left);
                nodeQueue.Enqueue(currentNode.right);

                depthQueue.Enqueue(currentDepth + 1);
                depthQueue.Enqueue(currentDepth + 1);
            }
        }

        for (int i = 0; i <= maxDepth; i++)
        {
            rightSideView.Add(depthNodeVal[i]);
        }

        return rightSideView;
    }
}