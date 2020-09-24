/**
 * Question 501. Find Mode in Binary Search Tree (https://leetcode-cn.com/problems/find-mode-in-binary-search-tree/)
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
 * 执行用时：104 ms, 在所有 typescript 提交中击败了 25.00% 的用户
 * 内存消耗：45.5 MB, 在所有 typescript 提交中击败了 100.00% 的用户
 *
 * Acknowledgement: This solution is a Typescript duplication of the [solution provided](https://leetcode-cn.com/problems/find-mode-in-binary-search-tree/solution/er-cha-shu-zhong-xu-bian-li-de-liang-chong-fang-sh/).
 *
 * @param {(TreeNode | null)} root
 * @returns {number[]}
 */
function findMode(root: TreeNode | null): number[] {
  return inorderTraversal(root, [], 0, 0, 0)[0];
}

function inorderTraversal(
  root: TreeNode | null,
  mList: number[],
  currentValue: number,
  currentCount: number,
  maxCount: number
): [number[], number, number, number] {
  if (!root) {
    return [mList, currentValue, currentCount, maxCount];
  }

  [mList, currentValue, currentCount, maxCount] = inorderTraversal(
    root.left,
    mList,
    currentValue,
    currentCount,
    maxCount
  );

  const rootValue: number = root.val;
  if (rootValue === currentValue) {
    currentCount++;
  } else {
    currentCount = 1;
    currentValue = rootValue;
  }

  if (currentCount === maxCount) {
    mList.push(rootValue);
  } else if (currentCount > maxCount) {
    mList = [rootValue];
    maxCount = currentCount;
  }

  [mList, currentValue, currentCount, maxCount] = inorderTraversal(
    root.right,
    mList,
    currentValue,
    currentCount,
    maxCount
  );

  return [mList, currentValue, currentCount, maxCount];
}
