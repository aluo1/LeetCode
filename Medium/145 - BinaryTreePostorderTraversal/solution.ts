/**
 * Question 145. Binary Tree Postorder Traversal (https://leetcode-cn.com/problems/binary-tree-postorder-traversal/)
 *
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
 * 执行用时：76 ms, 在所有 typescript 提交中击败了 78.57% 的用户
 * 内存消耗：39.7 MB, 在所有 typescript 提交中击败了 6.38% 的用户
 *
 * @param {(TreeNode | null)} root
 * @returns {number[]}
 */
function postorderTraversal(root: TreeNode | null): number[] {
  return root
    ? [
        ...postorderTraversal(root.left),
        ...postorderTraversal(root.right),
        root.val,
      ]
    : [];
}
