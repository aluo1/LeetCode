package com.aluo1.leetcode.easy;

/**
 * Author: An Luo
 * email: aluo1.developer@gmail.com
 * <p>
 * Problem Website: https://leetcode.com/problems/maximum-depth-of-binary-tree
 * <p>
 * Description: Definition for a binary tree node.
 * Acknowledgement: This code is provided by LeetCode.
 */

public class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;

    TreeNode(int x) {
        val = x;
    }

    public void insertNode(TreeNode node) {
        if (node.val >= val) {
            this.right = node;
        } else {
            this.left = node;
        }
    }
}
