/** Question 110. Balanced Binary Tree (https://leetcode-cn.com/problems/balanced-binary-tree/) */

/**
 * Definition for a binary tree node.
 * class TreeNode {
 *     val: number
 *     left: TreeNode | null
 *     right: TreeNode | null
 *     constructor(val?: number, left?: TreeNode | null, right?: TreeNode | null) {
 *         this.val = (val===undefined ? 0 : val)
 *         this.left = (left===undefined ? null : left)
 *         this.right = (right===undefined ? null : right)
 *     }
 * }
 */

class TreeNode {
  val: number;
  left: TreeNode | null;
  right: TreeNode | null;
  constructor(val?: number, left?: TreeNode | null, right?: TreeNode | null) {
    this.val = val === undefined ? 0 : val;
    this.left = left === undefined ? null : left;
    this.right = right === undefined ? null : right;
  }
}

/**
 * This is the bottom up solution provided by the [Leetcode Official](https://leetcode-cn.com/problems/balanced-binary-tree/solution/ping-heng-er-cha-shu-by-leetcode-solution/)
 *
 * 执行用时：100 ms, 在所有 typescript 提交中击败了 54.05% 的用户
 * 内存消耗：42.1 MB, 在所有 typescript 提交中击败了 81.25% 的用户
 *
 * @param {(TreeNode | null)} root
 * @returns {boolean}
 */
function isBalanced(root: TreeNode | null): boolean {
  return getTreeHeight(root) >= 0;
}

function getTreeHeight(root: TreeNode | null): number {
  if (root == null) {
    return 0;
  }

  const leftTreeHeight: number = getTreeHeight(root.left);
  const rightTreeHeight: number = getTreeHeight(root.right);

  if (
    leftTreeHeight === -1 ||
    rightTreeHeight === -1 ||
    Math.abs(leftTreeHeight - rightTreeHeight) > 1
  ) {
    return -1;
  }

  return Math.max(leftTreeHeight, rightTreeHeight) + 1;
}
