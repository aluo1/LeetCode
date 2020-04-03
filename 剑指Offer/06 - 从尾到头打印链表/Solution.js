/**
 * 面试题06. 从尾到头打印链表 (https://leetcode-cn.com/problems/cong-wei-dao-tou-da-yin-lian-biao-lcof/)
 * Difficulty: Easy
 * 执行用时: 80 ms, 在所有 JavaScript 提交中击败了 49.02% 的用户
 * 内存消耗: 34.9 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 *
 * Definition for singly-linked list.
 * function ListNode(val) {
 *     this.val = val;
 *     this.next = null;
 * }
 */

/**
 * @param {ListNode} head
 * @return {number[]}
 */
var reversePrint = function(head) {
  const valList = [];

  while (head != null) {
    valList.push(head.val);
    head = head.next;
  }

  valList.reverse();
  return valList;
};
