/**
 * Question 235. Lowest Common Ancestor of a Binary Search Tree (https://leetcode-cn.com/problems/lowest-common-ancestor-of-a-binary-search-tree/)
 *
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

/// <summary>
/// 执行用时：140 ms, 在所有 C# 提交中击败了 43.36% 的用户
/// 内存消耗：31.2 MB, 在所有 C# 提交中击败了 19.44% 的用户 
/// 
/// Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/lowest-common-ancestor-of-a-binary-search-tree/solution/er-cha-sou-suo-shu-de-zui-jin-gong-gong-zu-xian-26/)
/// </summary>
public class Solution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        TreeNode ancestor = root;

        while (true)
        {
            if (ancestor.val < p.val && ancestor.val < q.val)
            {
                ancestor = ancestor.right;
            }
            else if (ancestor.val > p.val && ancestor.val > q.val)
            {
                ancestor = ancestor.left;
            }
            else
            {
                break;
            }
        }

        return ancestor;
    }
}