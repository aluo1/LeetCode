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
 * 执行用时：128 ms, 在所有 typescript 提交中击败了 20.69% 的用户
 * 内存消耗：45.7 MB, 在所有 typescript 提交中击败了 40.00% 的用户
 *
 * Acknowledgement: This solution borrows idea from the BFS approach of the [official solution](https://leetcode-cn.com/problems/path-sum-ii/solution/lu-jing-zong-he-ii-by-leetcode-solution/).
 *
 * @param {(TreeNode | null)} root
 * @param {number} sum
 * @returns {number[][]}
 */
function pathSum(root: TreeNode | null, sum: number): number[][] {
  if (root === null) {
    return [];
  }

  const nodeQueue: TreeNode[] = [root];
  const nodeValueQueue: number[] = [0];

  const hierarchyMap: Map<TreeNode, TreeNode> = new Map<TreeNode, TreeNode>();
  const paths: number[][] = [];

  while (nodeQueue.length) {
    const currentNode: TreeNode = nodeQueue.shift() as TreeNode;
    const currentValue: number =
      (nodeValueQueue.shift() as number) + currentNode.val;

    if (currentNode.left === null && currentNode.right === null) {
      if (currentValue === sum) {
        paths.push(getPath(currentNode, hierarchyMap));
      }
    } else {
      if (currentNode.left) {
        nodeQueue.push(currentNode.left);
        nodeValueQueue.push(currentValue);
        hierarchyMap.set(currentNode.left, currentNode);
      }

      if (currentNode.right) {
        nodeQueue.push(currentNode.right);
        nodeValueQueue.push(currentValue);
        hierarchyMap.set(currentNode.right, currentNode);
      }
    }
  }

  return paths;
}

function getPath(node: TreeNode, hierarchy: Map<TreeNode, TreeNode>): number[] {
  let path: number[] = [];

  while (hierarchy.has(node)) {
    path = [node.val, ...path];
    node = hierarchy.get(node) as TreeNode;
  }

  path = [node.val, ...path];

  // console.log(path);

  return path;
}
