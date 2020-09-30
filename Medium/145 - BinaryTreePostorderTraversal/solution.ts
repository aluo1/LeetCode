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

/**
 * 执行用时：92 ms, 在所有 typescript 提交中击败了 12.68% 的用户
 * 内存消耗：39.6 MB, 在所有 typescript 提交中击败了 6.25% 的用户
 *
 * @param {(TreeNode | null)} root
 * @returns {number[]}
 */
function postorderTraversalUsingStack(root: TreeNode | null): number[] {
  if (!root) {
    return [];
  }

  const traversed: number[] = [];
  const stack: (TreeNode | null)[] = [];
  let prevNode: TreeNode | null = null;

  while (root || stack.length) {
    // Add all left children to stacks first.
    while (root) {
      stack.push(root);
      root = root.left;
    }

    root = stack.pop() ?? null;

    console.log(`root.right.val = ${root?.right?.val ?? "null"}`);
    console.log(stack);

    if (root && (!root.right || (prevNode && root.right === prevNode))) {
      console.log(
        `line 35, root.val = ${root?.val ?? "null"}, root.right.val = ${
          root?.right?.val ?? "null"
        }\n`
      );
      traversed.push(root.val);
      prevNode = root;
      root = null;
    } else {
      console.log(`line 43, root.val = ${root?.val ?? "null"}`);

      stack.push(root);
      root = root?.right ?? null;

      console.log(`line 47, root.val = ${root?.val ?? "null"}\n`);
    }
  }

  return traversed;
}
