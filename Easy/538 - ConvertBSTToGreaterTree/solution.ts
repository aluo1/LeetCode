/**
 * Question 538. Convert BST to Greater Tree (https://leetcode-cn.com/problems/convert-bst-to-greater-tree/)
 *
 * 执行用时：352 ms, 在所有 typescript 提交中击败了 11.11% 的用户
 * 内存消耗：59.2 MB, 在所有 typescript 提交中击败了 16.67% 的用户
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

function convertBST(root: TreeNode | null): TreeNode | null {
  if (!root) {
    return root;
  }

  const traversedNodes: number[] = getNodes(root, []);
  const sumDictionary: Map<number, number> = getSumDictionary(traversedNodes);
  const greaterTree: TreeNode | null = buildGreaterTree(root, sumDictionary);

  return greaterTree;
}

function getNodes(root: TreeNode | null, traversedNodes: number[]): number[] {
  if (!root) {
    return traversedNodes;
  }

  traversedNodes = getNodes(root.left, traversedNodes);
  traversedNodes = getNodes(root.right, [...traversedNodes, root.val]);

  return traversedNodes;
}

function getSumDictionary(nodes: number[]): Map<number, number> {
  const sumDictionary: Map<number, number> = new Map<number, number>();

  for (let i = 0; i < nodes.length; i++) {
    const currentNode: number = nodes[i];
    let sum: number = 0;

    for (let j = i + 1; j < nodes.length; j++) {
      const nextValue: number = nodes[j];
      if (nextValue > currentNode) {
        sum += nextValue;
      }
    }

    sumDictionary.set(currentNode, sum);
  }

  return sumDictionary;
}

function buildGreaterTree(
  root: TreeNode | null,
  sumDictionary: Map<number, number>
): TreeNode | null {
  if (!root) {
    return null;
  }

  let newNode: TreeNode = new TreeNode(
    root.val + (sumDictionary.get(root.val) || 0)
  );

  newNode.left = buildGreaterTree(root.left, sumDictionary);
  newNode.right = buildGreaterTree(root.right, sumDictionary);

  return newNode;
}
