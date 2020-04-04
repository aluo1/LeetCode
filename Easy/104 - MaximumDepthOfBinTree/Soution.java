/**
 * Author: An Luo email: aluo1.developer@gmail.com
 * <p>
 * Problem Website: https://leetcode.com/problems/maximum-depth-of-binary-tree.
 * 
 * 执行用时 : 0 ms, 在所有 Java 提交中击败了 100.00% 的用户
 * 内存消耗 : 39.8 MB, 在所有 Java 提交中击败了 5.24% 的用户
 * 
 * <p>
 * Description: Solution for the question "Find the maximum depth of a binary
 * tree.
 * <p>
 * Acknowledgement: This code is based on the template provided by LeetCode.
 */

public class Soution {
    public int maxDepth(TreeNode root) {
        return findDepth(root);
    }

    private int findDepth(TreeNode node) {
        int leftBranchDepth, rightBranchDepth;

        if (node == null) {
            return 0;
        }

        leftBranchDepth = findDepth(node.left) + 1;
        rightBranchDepth = findDepth(node.right) + 1;

        return leftBranchDepth > rightBranchDepth ? leftBranchDepth : rightBranchDepth;
    }
}
