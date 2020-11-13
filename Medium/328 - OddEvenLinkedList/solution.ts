// Question 328. Odd Even Linked List (https://leetcode-cn.com/problems/odd-even-linked-list/)

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
 * 执行用时：104 ms, 在所有 typescript 提交中击败了 41.67% 的用户
 * 内存消耗：41.6 MB, 在所有 typescript 提交中击败了 16.67% 的用户
 *
 * @param {(ListNode | null)} head
 * @returns {(ListNode | null)}
 */
function oddEvenList(head: ListNode | null): ListNode | null {
  if (!head || !head.next) {
    return head;
  }

  const HEAD_POINTER: ListNode = head;
  const EVEN_HEAD_POINTER: ListNode = head.next;
  let evenPointer: ListNode | null = EVEN_HEAD_POINTER;

  while (evenPointer && evenPointer.next) {
    head.next = evenPointer.next;
    head = head.next;

    evenPointer.next = head.next;
    evenPointer = evenPointer.next;
  }

  head.next = EVEN_HEAD_POINTER;

  return HEAD_POINTER;
}
