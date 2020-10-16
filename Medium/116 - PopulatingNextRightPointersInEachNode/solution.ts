/**
 * Definition for Node.
 * class Node {
 *     val: number
 *     left: Node | null
 *     right: Node | null
 *     next: Node | null
 *     constructor(val?: number, left?: Node, right?: Node, next?: Node) {
 *         this.val = (val===undefined ? 0 : val)
 *         this.left = (left===undefined ? null : left)
 *         this.right = (right===undefined ? null : right)
 *         this.next = (next===undefined ? null : next)
 *     }
 * }
 */
class Node {
  val: number;
  left: Node | null;
  right: Node | null;
  next: Node | null;
  constructor(val?: number, left?: Node, right?: Node, next?: Node) {
    this.val = val === undefined ? 0 : val;
    this.left = left === undefined ? null : left;
    this.right = right === undefined ? null : right;
    this.next = next === undefined ? null : next;
  }
}

/**
 * 执行用时：116 ms, 在所有 typescript 提交中击败了 100.00% 的用户
 * 内存消耗：46.6 MB, 在所有 typescript 提交中击败了 100.00% 的用户
 *
 * @param {(Node | null)} root
 * @returns {(Node | null)}
 */
function connect(root: Node | null): Node | null {
  if (!root) {
    return root;
  }

  const LEVEL_INDEX: number = 1;

  const queue: [[Node, number]] = [[root, 1]];
  while (queue.length) {
    let [currentNode, currentDepth] = queue.shift() as [Node, number];

    addToQueue(currentNode, currentDepth, queue);

    while (queue.length && queue[0][LEVEL_INDEX] === currentDepth) {
      let [nextNode, _] = queue.shift() as [Node, number];
      currentNode.next = nextNode;
      currentNode = nextNode;

      addToQueue(currentNode, currentDepth, queue);
    }
  }

  return root;
}

function addToQueue(
  currentNode: Node,
  currentDepth: number,
  queue: [[Node, number]]
): void {
  if (currentNode.left) {
    queue.push([currentNode.left, currentDepth + 1]);
  }

  if (currentNode.right) {
    queue.push([currentNode.right, currentDepth + 1]);
  }
}
