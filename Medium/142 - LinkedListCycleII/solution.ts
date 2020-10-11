/**
 * Question 142. Linked List Cycle II (https://leetcode-cn.com/problems/linked-list-cycle-ii/)
 * 
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
 * 执行用时：96 ms, 在所有 typescript 提交中击败了 100.00% 的用户
 * 内存消耗：41.2 MB, 在所有 typescript 提交中击败了 100.00% 的用户
 *
 * @param {(ListNode | null)} head
 * @returns {(ListNode | null)}
 */
function detectCycle(head: ListNode | null): ListNode | null {
  const visited: Set<ListNode> = new Set<ListNode>();

  while (head) {
    if (visited.has(head)) {
      return head;
    }

    visited.add(head);
    head = head.next;
  }

  return null;
}

/**
 * 执行用时：84 ms, 在所有 typescript 提交中击败了 100.00% 的用户
 * 内存消耗：41.1 MB, 在所有 typescript 提交中击败了 100.00% 的用户
 *
 * Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/linked-list-cycle-ii/solution/huan-xing-lian-biao-ii-by-leetcode-solution/)
 *
 * @param {(ListNode | null)} head
 * @returns {(ListNode | null)}
 */
function detectCycleUsingFastSlowPointers(
  head: ListNode | null
): ListNode | null {
  if (!head || !head.next) {
    return null;
  }

  let slow: ListNode = head;
  let fast: ListNode | null = head;

  while (fast) {
    if (!fast.next) {
      return null;
    }

    slow = slow.next as ListNode;
    fast = fast.next.next;

    // cycle found
    if (fast === slow) {
      console.log(fast.val);
      let pointer: ListNode = head;

      while (pointer !== slow) {
        pointer = pointer.next as ListNode;
        slow = slow.next as ListNode;
      }

      return slow;
    }
  }

  return null;
}
