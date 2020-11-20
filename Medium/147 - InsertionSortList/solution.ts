// Question 147. Insertion Sort List (https://leetcode-cn.com/problems/insertion-sort-list/)

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
 * 执行用时：124 ms, 在所有 typescript 提交中击败了 44.44% 的用户
 * 内存消耗：41.9 MB, 在所有 typescript 提交中击败了 11.11% 的用户
 *
 * Acknowledgement: This solution is the TypeScript-version duplicate of the [official solution](https://leetcode-cn.com/problems/insertion-sort-list/solution/dui-lian-biao-jin-xing-cha-ru-pai-xu-by-leetcode-s/)
 *
 * @param {(ListNode | null)} head
 * @returns {(ListNode | null)}
 */
function insertionSortList(head: ListNode | null): ListNode | null {
  if (!head) {
    return head;
  }

  const dummyHead: ListNode = new ListNode(-1, head);
  let lastSorted: ListNode | null = head;
  let current: ListNode | null = head.next;

  while (current) {
    if (lastSorted && lastSorted.val <= current.val) {
      lastSorted = lastSorted.next;
    } else {
      let previous: ListNode | null = dummyHead;
      while (previous && previous.next && previous.next.val <= current.val) {
        previous = previous.next;
      }

      if (lastSorted && previous) {
        lastSorted.next = current.next;
        current.next = previous.next;
        previous.next = current;
      }
    }

    current = lastSorted?.next ?? null;
  }

  return dummyHead.next;
}
