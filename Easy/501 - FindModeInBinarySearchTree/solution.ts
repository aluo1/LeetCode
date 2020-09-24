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
 * 执行用时：140 ms, 在所有 typescript 提交中击败了 25.00% 的用户
 * 内存消耗：47.8 MB, 在所有 typescript 提交中击败了 100.00% 的用户
 *
 * @param {(TreeNode | null)} root
 * @returns {number[]}
 */
function findMode(root: TreeNode | null): number[] {
  const [frequencyDictionary, highestFrequency] = traverseTree(
    root,
    new Map<number, number>(),
    0
  );

  return Array.from(frequencyDictionary.entries())
    .filter(([_, frequency]) => frequency === highestFrequency)
    .map(([value, _]) => value);
}

function traverseTree(
  root: TreeNode | null,
  frequencyDictionary: Map<number, number>,
  highestFrequency: number
): [Map<number, number>, number] {
  if (!root) {
    return [frequencyDictionary, highestFrequency];
  }

  const rootValue: number = root.val;

  if (frequencyDictionary.has(rootValue)) {
    const newFrequency: number =
      (frequencyDictionary.get(rootValue) as number) + 1;
    highestFrequency = Math.max(newFrequency, highestFrequency);
    frequencyDictionary.set(rootValue, newFrequency);
  } else {
    highestFrequency = Math.max(1, highestFrequency);
    frequencyDictionary.set(rootValue, 1);
  }

  [frequencyDictionary, highestFrequency] = traverseTree(
    root.left,
    frequencyDictionary,
    highestFrequency
  );
  [frequencyDictionary, highestFrequency] = traverseTree(
    root.right,
    frequencyDictionary,
    highestFrequency
  );

  return [frequencyDictionary, highestFrequency];
}
