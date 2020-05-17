/**
 * Definition for singly-linked list.
 * function ListNode(val) {
 *     this.val = val;
 *     this.next = null;
 * }
 */
/**
 * 面试题 02.01. 移除重复节点 (https://leetcode-cn.com/problems/remove-duplicate-node-lcci/)
 * Difficulty: Easy
 *
 * 执行用时 : 100 ms, 在所有 JavaScript 提交中击败了 49.27% 的用户
 * 内存消耗 : 39.5 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 *
 * @param {ListNode} head
 * @return {ListNode}
 */
var removeDuplicateNodes = function (head) {
  const recordedNodesVal = new Set();
  const headPointer = head;

  while (head) {
    recordedNodesVal.add(head.val);

    let nextPointer = head.next;

    while (nextPointer && recordedNodesVal.has(nextPointer.val)) {
      nextPointer = nextPointer.next;
    }

    head.next = nextPointer;
    head = head.next;
  }

  return headPointer;
};
