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

/**
 * 执行用时：144 ms, 在所有 typescript 提交中击败了 52.00% 的用户
 * 内存消耗：45.7 MB, 在所有 typescript 提交中击败了 11.76% 的用户
 *
 * @param {(TreeNode | null)} root
 * @param {number} val
 * @returns {(TreeNode | null)}
 */
function insertIntoBST(root: TreeNode | null, val: number): TreeNode | null {
  if (!root) {
    return new TreeNode(val);
  }

  insertIntoTree(root, val);

  return root;
}

function insertIntoTree(root: TreeNode, val: number): void {
  if (root.val > val) {
    if (!root.left) {
      root.left = new TreeNode(val);
    } else {
      insertIntoTree(root.left, val);
    }
  } else {
    // root.val < val
    if (!root.right) {
      root.right = new TreeNode(val);
    } else {
      insertIntoTree(root.right, val);
    }
  }
}
