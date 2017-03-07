package com.aluo1.leetcode.easy;

public class Main {

    public static void main(String[] args) {
	    /* A Tree with max depth 2 */
        TreeNode root = new TreeNode(2);
        TreeNode right = new TreeNode(3);
        TreeNode left = new TreeNode(1);
        TreeNode rightMost = new TreeNode(5);

        /* A tree-depth counter */
        Soution solver = new Soution();

        /* insert node to tree */
        root.insertNode(left);
        right.insertNode(rightMost);
        root.insertNode(right);

        System.out.println(solver.maxDepth(root));
    }
}
