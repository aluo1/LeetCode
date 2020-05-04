/// Question 100. Same Tree (https://leetcode-cn.com/problems/same-tree/)

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
    // 执行用时: 100 ms, 在所有 C# 提交中击败了 97.02% 的用户
    // 内存消耗: 24.3 MB, 在所有 C# 提交中击败了 16.67% 的用户
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p != null && q != null)
        {
            if (p.val != q.val) { return false; }

            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        return p == null && q == null;
    }
}

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class SolutionUsingQueue
{
    // 执行用时: 112 ms, 在所有 C# 提交中击败了 48.68% 的用户
    // 内存消耗: 24.4 MB, 在所有 C# 提交中击败了 16.67% 的用户
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        Queue<TreeNode> pQueue = new Queue<TreeNode>();
        pQueue.Enqueue(p);

        Queue<TreeNode> qQueue = new Queue<TreeNode>();
        qQueue.Enqueue(q);

        while (pQueue.Any())
        {
            TreeNode pNode = pQueue.Dequeue();

            if (!qQueue.Any()) { return false; }
            TreeNode qNode = qQueue.Dequeue();

            if (!IsSameNode(pNode, qNode)) { return false; }

            if (pNode != null && qNode != null)
            {
                pQueue.Enqueue(pNode.left);
                pQueue.Enqueue(pNode.right);

                qQueue.Enqueue(qNode.left);
                qQueue.Enqueue(qNode.right);
            }
        }

        return !qQueue.Any();

    }

    private bool IsSameNode(TreeNode pNode, TreeNode qNode)
    {
        if (pNode != null && qNode != null)
        {
            return pNode.val == qNode.val;
        }

        return pNode == null && qNode == null;
    }
}