// Question 222. Count Complete Tree Nodes (https://leetcode-cn.com/problems/count-complete-tree-nodes/)

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
/// 执行用时：120 ms, 在所有 C# 提交中击败了 94.12% 的用户
/// 内存消耗：33.2 MB, 在所有 C# 提交中击败了 7.84% 的用户
/// </summary>
public class Solution 
{
    public int CountNodes(TreeNode root) 
    {
        int count = 0;
        if (root == null) { return count; }
        

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count() > 0)
        {
            TreeNode current = queue.Dequeue();
            count++;

            if (current.left != null) 
            {
                queue.Enqueue(current.left);
            }

            if (current.right != null) 
            {
                queue.Enqueue(current.right);
            }
        }

        return count;
    }
}