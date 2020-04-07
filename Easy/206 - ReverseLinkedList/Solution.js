/**
 * Question 206. Reverse Linked List (https://leetcode-cn.com/problems/reverse-linked-list/)
 *
 * 执行用时: 64 ms, 在所有 JavaScript 提交中击败了 88.95% 的用户
 * 内存消耗: 35.1 MB, 在所有 JavaScript 提交中击败了 78.16% 的用户
 * Definition for singly-linked list.
 * function ListNode(val) {
 *     this.val = val;
 *     this.next = null;
 * }
 */
/**
 * @param {ListNode} head
 * @return {ListNode}
 */
var reverseList = function (head) {
  let currentHead = null;

  while (head != null) {
    let currentNode = currentHead;

    currentHead = head;
    head = head.next;

    currentHead.next = currentNode;
  }

  return currentHead;
};
