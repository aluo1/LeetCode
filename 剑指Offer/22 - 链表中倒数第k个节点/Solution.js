/**
 * 面试题22. 链表中倒数第k个节点 (https://leetcode-cn.com/problems/lian-biao-zhong-dao-shu-di-kge-jie-dian-lcof/)
 * Difficulty: Easy
 * 
 * 执行用时: 68 ms, 在所有 JavaScript 提交中击败了 70.60% 的用户
 * 内存消耗: 33.7 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 * 
 * Definition for singly-linked list.
 * function ListNode(val) {
 *     this.val = val;
 *     this.next = null;
 * }
 */
/**
 * @param {ListNode} head
 * @param {number} k
 * @return {ListNode}
 */
var getKthFromEnd = function (head, k) {
  let nodeLength = 0;
  let headPointer = head;

  while (head != null) {
    head = head.next;
    nodeLength++;
  }

  while (nodeLength !== k) {
    headPointer = headPointer.next;
    nodeLength--;
  }

  return headPointer;
};
