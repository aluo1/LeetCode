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
 * 执行用时：88 ms, 在所有 typescript 提交中击败了 26.32% 的用户
 * 内存消耗：39.6 MB, 在所有 typescript 提交中击败了 5.68% 的用户
 *
 * @param {(TreeNode | null)} root
 * @returns {number[]}
 */
function preorderTraversal(root: TreeNode | null): number[] {
  return root
    ? [
        root.val,
        ...preorderTraversal(root.left),
        ...preorderTraversal(root.right),
      ]
    : [];
}

/**
 * 执行用时：96 ms, 在所有 typescript 提交中击败了 9.77% 的用户
 * 内存消耗：39.6 MB, 在所有 typescript 提交中击败了 5.68% 的用户
 *
 * @param {(TreeNode | null)} root
 * @returns {number[]}
 */
function preorderTraversalUsingStack(root: TreeNode | null): number[] {
  if (!root) {
    return [];
  }

  const traversed: number[] = [];
  const stack: TreeNode[] = [root];

  while (stack.length) {
    const currentNode: TreeNode = stack.pop() as TreeNode;
    traversed.push(currentNode.val);

    if (currentNode.right) {
      stack.push(currentNode.right);
    }

    if (currentNode.left) {
      stack.push(currentNode.left);
    }
  }

  return traversed;
}
