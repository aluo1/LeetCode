/**
 * Question 143. Reorder List (https://leetcode-cn.com/problems/reorder-list/)
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
 * Do not return anything, modify head in-place instead.
 * 
 * 执行用时：140 ms, 在所有 typescript 提交中击败了 22.22% 的用户
 * 内存消耗：47.5 MB, 在所有 typescript 提交中击败了 14.29% 的用户
 * 
 * Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/reorder-list/solution/zhong-pai-lian-biao-by-leetcode-solution/).
 * 
 */
function reorderList(head: ListNode | null): void {
  if (!head) {
    return;
  }

  const nodeList: ListNode[] = [];
  while (head) {
    nodeList.push(head);
    head = head.next;
  }

  let left: number = 0;
  let right: number = nodeList.length - 1;

  while (left < right) {
    nodeList[left].next = nodeList[right];
    left++;

    if (left === right) {
      break;
    }

    nodeList[right].next = nodeList[left];
    right--;
  }

  nodeList[left].next = null;
}
