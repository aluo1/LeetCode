/// Question 938. Range Sum of BST
/// Difficulty: Easy
/// 执行用时: 400 ms, 在所有 C# 提交中击败了 27.66% 的用户
/// 内存消耗: 43.3 MB, 在所有 C# 提交中击败了 100.00% 的用户

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public int RangeSumBST(TreeNode root, int L, int R) {
        int rootVal = root.val;
        int rangeSum = (rootVal >= L && rootVal <= R) ? rootVal : 0;
        
        if (root.left == null && root.right == null) {
            return rangeSum;
        }
        
        if (root.left == null && root.right != null) {
            // Check the right branch.
            return rangeSum + RangeSumBST(root.right, L, R);
        }
        
        if (root.left != null && root.right == null) {
            // Check the left branch.
            return rangeSum + RangeSumBST(root.left, L, R);
        }
        
        return rangeSum + RangeSumBST(root.right, L, R) + RangeSumBST(root.left, L, R);
    }
}