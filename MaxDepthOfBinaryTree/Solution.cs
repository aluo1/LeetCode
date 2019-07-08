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