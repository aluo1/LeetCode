/**
 * // Definition for a Node.
 * function Node(val, left, right, next) {
 *    this.val = val === undefined ? null : val;
 *    this.left = left === undefined ? null : left;
 *    this.right = right === undefined ? null : right;
 *    this.next = next === undefined ? null : next;
 * };
 */

function Node(val, left, right, next) {
  this.val = val === undefined ? null : val;
  this.left = left === undefined ? null : left;
  this.right = right === undefined ? null : right;
  this.next = next === undefined ? null : next;
}

const LEVEL_INDEX = 1;

/**
 * 执行用时：116 ms, 在所有 JavaScript 提交中击败了 43.14% 的用户
 * 内存消耗：44.6 MB, 在所有 JavaScript 提交中击败了 5.15% 的用户
 *
 * @param {Node} root
 * @return {Node}
 */
var connect = function (root) {
  if (!root) {
    return root;
  }

  let queueWithLevel = [[root, 1]];

  while (queueWithLevel.length) {
    let [node, currentLevel] = queueWithLevel.shift();

    if (node.left) {
      queueWithLevel.push([node.left, currentLevel + 1]);
    }

    if (node.right) {
      queueWithLevel.push([node.right, currentLevel + 1]);
    }

    while (
      queueWithLevel.length &&
      queueWithLevel[0][LEVEL_INDEX] === currentLevel
    ) {
      let [nextNode, _] = queueWithLevel.shift();
      node.next = nextNode;
      node = nextNode;

      if (node.left) {
        queueWithLevel.push([node.left, currentLevel + 1]);
      }

      if (node.right) {
        queueWithLevel.push([node.right, currentLevel + 1]);
      }
    }

    node.next = null;
  }

  return root;
};
