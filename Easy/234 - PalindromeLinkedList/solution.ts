/**
 * Question 234. Palindrome Linked List (https://leetcode-cn.com/problems/palindrome-linked-list/)
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
 * 执行用时：100 ms, 在所有 typescript 提交中击败了 33.33% 的用户
 * 内存消耗：43.2 MB, 在所有 typescript 提交中击败了 30.56% 的用户
 *
 * @param {(ListNode | null)} head
 * @returns {boolean}
 */
function isPalindrome(head: ListNode | null): boolean {
  if (!head) {
    return true;
  }

  let currentNode: ListNode = head;
  const listNodes: number[] = [];

  while (currentNode) {
    listNodes.push(currentNode.val);
    currentNode = currentNode.next as ListNode;
  }

  let leftIndex: number = 0;
  let rightIndex: number = listNodes.length - 1;

  while (leftIndex <= rightIndex) {
    if (listNodes[leftIndex] !== listNodes[rightIndex]) {
      return false;
    }
    leftIndex++;
    rightIndex--;
  }

  return true;
}

/**
 * 执行用时：104 ms, 在所有 typescript 提交中击败了 27.78% 的用户
 * 内存消耗：41.9 MB, 在所有 typescript 提交中击败了 63.89% 的用户
 *
 * Acknowledgement: This solution borrows idea from the [official solution method III](https://leetcode-cn.com/problems/palindrome-linked-list/solution/hui-wen-lian-biao-by-leetcode-solution/)
 *
 * @param {(ListNode | null)} head
 * @returns {boolean}
 */
function isPalindromeUsingTwoPointers(head: ListNode | null): boolean {
  if (!head) {
    return true;
  }

  let firstHalfEnd: ListNode = getEndOfFirstHalf(head);
  let secondHalfStart: ListNode = reverseList(firstHalfEnd.next as ListNode);

  let firstPointer: ListNode = head;
  let secondPointer: ListNode = secondHalfStart;

  let result: boolean = true;
  while (secondPointer) {
    if (firstPointer.val !== secondPointer.val) {
      result = false;
    }
    firstPointer = firstPointer.next as ListNode;
    secondPointer = secondPointer.next as ListNode;
  }

  // Revert the list back.
  firstHalfEnd.next = reverseList(secondHalfStart);

  return result;
}

function reverseList(head: ListNode): ListNode {
  let previous: ListNode | null = null;
  let current: ListNode | null = head;

  while (current) {
    let next: ListNode | null = current.next;
    current.next = previous;
    previous = current as ListNode;
    current = next;
  }

  return previous ?? head;
}

function getEndOfFirstHalf(head: ListNode): ListNode {
  let slow: ListNode = head;
  let fast: ListNode = head;

  while (fast.next && fast.next.next) {
    fast = fast.next.next;
    slow = slow.next as ListNode;
  }

  return slow;
}
