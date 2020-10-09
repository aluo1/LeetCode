// Question 141. Linked List Cycle (https://leetcode-cn.com/problems/linked-list-cycle/)

/**
 * Definition for singly-linked list.
 * function ListNode(val) {
 *     this.val = val;
 *     this.next = null;
 * }
 */

/**
 * 执行用时：92 ms, 在所有 JavaScript 提交中击败了 68.23% 的用户
 * 内存消耗：40.6 MB, 在所有 JavaScript 提交中击败了 5.03% 的用户
 *
 * Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/linked-list-cycle/solution/huan-xing-lian-biao-by-leetcode-solution/)
 *
 * @param {ListNode} head
 * @return {boolean}
 */
var hasCycle = function (head) {
  if (!head || !head.next) {
    return false;
  }

  let fast = head.next;
  let slow = head;

  while (fast != slow) {
    if (!fast || !fast.next) {
      return false;
    }

    fast = fast.next.next;
    slow = slow.next;
  }

  return true;
};
