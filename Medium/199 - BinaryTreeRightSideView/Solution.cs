/// Question 199. Binary Tree Right Side View (https://leetcode-cn.com/problems/binary-tree-right-side-view/)
/// Acknowledgement: I tried the BFS, but failed on some edge cases, and I then get the idea from the [official solution] (https://leetcode-cn.com/problems/binary-tree-right-side-view/solution/er-cha-shu-de-you-shi-tu-by-leetcode-solution/).

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

public class SolutionWithDFS
{
    // 执行用时: 284 ms, 在所有 C# 提交中击败了 64.52% 的用户
    // 内存消耗: 30.9 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public IList<int> RightSideView(TreeNode root)
    {
        List<int> rightSideView = new List<int>();
        if (root == null) { return rightSideView; }

        Dictionary<int, int> depthNodeVal = new Dictionary<int, int>();
        int maxDepth = -1;

        Stack<TreeNode> nodeStack = new Stack<TreeNode>();
        nodeStack.Push(root);
        TreeNode currentNode = root;

        Stack<int> depthStack = new Stack<int>();
        depthStack.Push(0);
        int currentDepth = 0;

        while (nodeStack.Any() && depthStack.Any())
        {
            currentNode = nodeStack.Pop();
            currentDepth = depthStack.Pop();

            if (currentNode != null)
            {
                maxDepth = Math.Max(maxDepth, currentDepth);

                if (!depthNodeVal.ContainsKey(currentDepth))
                {
                    depthNodeVal[currentDepth] = currentNode.val;
                }

                nodeStack.Push(currentNode.left);
                nodeStack.Push(currentNode.right);

                depthStack.Push(currentDepth + 1);
                depthStack.Push(currentDepth + 1);
            }
        }

        for (int i = 0; i <= maxDepth; i++)
        {
            rightSideView.Add(depthNodeVal[i]);
        }

        return rightSideView;
    }
}