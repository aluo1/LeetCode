// Question 19. Remove Nth Node From End of List (https://leetcode-cn.com/problems/remove-nth-node-from-end-of-list/)

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
 * 执行用时：88 ms, 在所有 typescript 提交中击败了 73.45% 的用户
 * 内存消耗：40.6 MB, 在所有 typescript 提交中击败了 5.51% 的用户
 *
 * @param {(ListNode | null)} head
 * @param {number} n
 * @returns {(ListNode | null)}
 */
function removeNthFromEnd(head: ListNode | null, n: number): ListNode | null {
  if (!head) {
    return head;
  }

  const nodeStack: ListNode[] = [];
  while (head) {
    nodeStack.push(head);
    head = head.next;
  }

  let iLast: number = 0;
  while (nodeStack.length) {
    iLast++;

    const tail: ListNode = nodeStack.pop() as ListNode;
    if (iLast !== n) {
      tail.next = head;
      head = tail;
    }
  }

  return head;
}
