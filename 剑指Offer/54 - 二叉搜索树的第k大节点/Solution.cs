/// 面试题54. 二叉搜索树的第k大节点 (https://leetcode-cn.com/problems/er-cha-sou-suo-shu-de-di-kda-jie-dian-lcof/)

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
    // 执行用时: 116 ms, 在所有 C# 提交中击败了 93.94% 的用户
    // 内存消耗: 28.3 MB, 在所有 C# 提交中击败了 100.00% 的用户
    private int k;
    private int answer;

    public int KthLargest(TreeNode root, int k)
    {
        this.k = k;
        this.DFS(root);
        return this.answer;
    }

    private void DFS(TreeNode root)
    {
        if (root == null) { return; }

        this.DFS(root.right);

        if (--this.k == 0)
        {
            this.answer = root.val;
            return;
        }

        this.DFS(root.left);
    }
}