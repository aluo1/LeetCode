/// Question 104. Maximum Depth of Binary Tree
/// Difficulty: Easy
/// 执行用时: 160 ms, 在所有 C# 提交中击败了 65.02% 的用户
// 内存消耗: 23.8 MB, 在所有 C# 提交中击败了 5.26% 的用户

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
    public int MaxDepth(TreeNode root) {  
        if (root == null) {
            return 0;
        }
        
        if (root.left == null && root.right == null) {
            // Leaf
            return 1;
        }
        
        if (root.left != null && root.right == null) {
            return 1 + MaxDepth(root.left);
        }
        
        if (root.left == null && root.right != null) {
            return 1 + MaxDepth(root.right);
        }
        
        int leftBranchDepth = MaxDepth(root.left);
        int rightBranchDepth = MaxDepth(root.right);

        return 1 + (leftBranchDepth > rightBranchDepth ? leftBranchDepth : rightBranchDepth);
    }
}