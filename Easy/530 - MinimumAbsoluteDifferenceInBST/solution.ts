/**
 * Question 530. Minimum Absolute Difference in BST (https://leetcode-cn.com/problems/minimum-absolute-difference-in-bst/)
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
 * 执行用时：112 ms, 在所有 typescript 提交中击败了 30.00% 的用户
 * 内存消耗：45.9 MB, 在所有 typescript 提交中击败了 11.11% 的用户
 * 
 * Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/minimum-absolute-difference-in-bst/solution/er-cha-sou-suo-shu-de-zui-xiao-jue-dui-chai-by-lee/).
 *
 * @param {(TreeNode | null)} root
 * @returns {number}
 */
function getMinimumDifference(root: TreeNode | null): number {
  let answer: number = Number.MAX_SAFE_INTEGER;
  let previous: number = -1;

  [answer, previous] = dfs(root, previous, answer);

  return answer;
}

function dfs(
  root: TreeNode | null,
  previous: number,
  answer: number
): number[] {
  if (!root) {
    return [answer, previous];
  }

  [answer, previous] = dfs(root.left, previous, answer);
  if (previous !== -1) {
    console.log(
      `answer = ${answer}, root.val = ${root.val}, previous = ${previous}`
    );
    answer = Math.min(answer, root.val - previous);
  }

  previous = root.val;

  [answer, previous] = dfs(root.right, previous, answer);

  return [answer, previous];
}
