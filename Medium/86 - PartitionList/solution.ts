// Question 86. Partition List (https://leetcode-cn.com/problems/partition-list/)

/**
 * Definition for singly-linked list.
 * class ListNode {
 *     val: number
 *     next: ListNode | null
 *     constructor(val?: number, next?: ListNode | null) {
 *         this.val = (val===undefined ? 0 : val)
 *         this.next = (next===undefined ? null : next)
 *     }
 * }
 */
class ListNode {
  val: number;
  next: ListNode | null;
  constructor(val?: number, next?: ListNode | null) {
    this.val = val === undefined ? 0 : val;
    this.next = next === undefined ? null : next;
  }
}

/**
 * 执行用时：84 ms, 在所有 TypeScript 提交中击败了 100.00% 的用户
 * 内存消耗：40.4 MB, 在所有 TypeScript 提交中击败了 57.14% 的用户
 *
 * Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/partition-list/solution/fen-ge-lian-biao-by-leetcode-solution-7ade/)
 * 
 * @param {(ListNode | null)} head
 * @param {number} x
 * @returns {(ListNode | null)}
 */
function partition(head: ListNode | null, x: number): ListNode | null {
  const smallHead: ListNode = new ListNode(-1, head);
  let small: ListNode = smallHead;

  const largeHead: ListNode = new ListNode(-1, head);
  let large: ListNode = largeHead;

  while (head) {
    const next: ListNode | null = head.next;
    if (head.val < x) {
      small.next = head;
      small = small.next;
    } else {
      large.next = head;
      large = large.next;
    }
    head = next;
  }

  large.next = null;
  small.next = largeHead.next;
  return smallHead.next;
}
