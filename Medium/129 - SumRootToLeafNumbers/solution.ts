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
 * 执行用时：84 ms, 在所有 typescript 提交中击败了 82.35% 的用户
 * 内存消耗：40.6 MB, 在所有 typescript 提交中击败了 5.88% 的用户
 *
 * @param {(TreeNode | null)} root
 * @returns {number}
 */
function sumNumbers(root: TreeNode | null): number {
  if (!root) {
    return 0;
  }

  let sum: number = 0;

  let nodeQueue: TreeNode[] = [root];
  let valueQueue: number[] = [root.val];

  while (nodeQueue.length && valueQueue.length) {
    const currentNode: TreeNode = nodeQueue.shift() as TreeNode;
    let currentValue: number = valueQueue.shift() as number;

    if (!currentNode.left && !currentNode.right) {
      sum += currentValue;
    } else {
      if (currentNode.left) {
        nodeQueue.push(currentNode.left);
        valueQueue.push(currentValue * 10 + currentNode.left.val);
      }

      if (currentNode.right) {
        nodeQueue.push(currentNode.right);
        valueQueue.push(currentValue * 10 + currentNode.right.val);
      }
    }
  }

  return sum;
}
