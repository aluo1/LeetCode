/** Question 110. Balanced Binary Tree (https://leetcode-cn.com/problems/balanced-binary-tree/) */

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */

/**
 * This is the bottom up solution provided by the [Leetcode Official](https://leetcode-cn.com/problems/balanced-binary-tree/solution/ping-heng-er-cha-shu-by-leetcode-solution/)
 * 
 * 执行用时：1 ms, 在所有 Java 提交中击败了 99.76% 的用户
 * 内存消耗：39.6 MB, 在所有 Java 提交中击败了 96.14% 的用户
 */
class Solution {
    public boolean isBalanced(TreeNode root) {
        return getTreeHeight(root) >= 0;
    }

    public int getTreeHeight(TreeNode root) {
        if (root == null) {
            return 0;
        }

        int leftTreeHeight = getTreeHeight(root.left);
        int rightTreeHeight = getTreeHeight(root.right);

        if (leftTreeHeight == -1 || rightTreeHeight == -1 || Math.abs(leftTreeHeight - rightTreeHeight) > 1) {
            return -1;
        }

        return Math.max(leftTreeHeight, rightTreeHeight) + 1;
    }
}