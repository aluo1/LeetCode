/**
 * Question 2. Add Two Numbers (https://leetcode-cn.com/problems/add-two-numbers/)
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
 * 执行用时：156 ms, 在所有 typescript 提交中击败了 30.86% 的用户
 * 内存消耗：43.7 MB, 在所有 typescript 提交中击败了 14.72% 的用户
 *
 * @param {(ListNode | null)} l1
 * @param {(ListNode | null)} l2
 * @returns {(ListNode | null)}
 */
function addTwoNumbers(
  l1: ListNode | null,
  l2: ListNode | null
): ListNode | null {
  if (!l1 && !l2) {
    return null;
  }

  let sum: number = (((l1?.val ?? 0) as number) + (l2?.val ?? 0)) as number;
  let increaseByTen: number = 0;
  increaseByTen = Math.floor(sum / 10);
  sum = Math.floor(sum % 10);

  let sumNode: ListNode = new ListNode(sum);
  const sumNodePointer: ListNode = sumNode;
  l1 = l1?.next ?? null;
  l2 = l2?.next ?? null;

  while (l1 || l2) {
    if (l1 && l2) {
      sum = l1.val + l2.val + increaseByTen;
      increaseByTen = Math.floor(sum / 10);
      sum = Math.floor(sum % 10);

      sumNode.next = new ListNode(sum);
      sumNode = sumNode.next;
      l1 = l1.next;
      l2 = l2.next;
    } else if (l1) {
      sum = l1.val + increaseByTen;
      increaseByTen = Math.floor(sum / 10);
      sum = Math.floor(sum % 10);
      sumNode.next = new ListNode(sum);
      sumNode = sumNode.next;
      l1 = l1.next;
    } else if (l2) {
      sum = l2.val + increaseByTen;
      increaseByTen = Math.floor(sum / 10);
      sum = Math.floor(sum % 10);
      sumNode.next = new ListNode(sum);
      sumNode = sumNode.next;
      l2 = l2.next;
    }
  }

  if (increaseByTen) {
    sumNode.next = new ListNode(increaseByTen);
  }

  return sumNodePointer;
}
