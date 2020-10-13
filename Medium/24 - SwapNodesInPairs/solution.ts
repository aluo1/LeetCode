// Question 24. Swap Nodes in Pairs (https://leetcode-cn.com/problems/swap-nodes-in-pairs/)

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
 * This is the solution I tried, but it does not work if the number of node is odd.
 * e.g. [1,2,3,4,5]
 *
 * @param {(ListNode | null)} head
 * @returns {(ListNode | null)}
 */
function swapPairsFailed(head: ListNode | null): ListNode | null {
  if (!head || !head.next) {
    return head;
  }

  let pointer: ListNode | null = new ListNode(-1, head);
  let currentNode: ListNode | null = pointer;

  const stack: ListNode[] = [head, head.next];

  head = head.next;
  let count: number = 2;

  while (head) {
    const nextNode: ListNode | null = head.next;
    count++;

    // console.log(
    //   `head?.val = ${head?.val ?? -100}, currentNode?.val = ${
    //     currentNode?.val ?? -100
    //   }, nextNode?.val = ${nextNode?.val ?? -100}, stack = ${stack
    //     .map((node) => node?.val ?? -1)
    //     .join(", ")}`
    // );

    if (stack.length === 2) {
      let newHead: ListNode | null = stack.pop() as ListNode | null;
      let newTail: ListNode | null = stack.pop() as ListNode | null;

      //   console.log(
      //     `newHead?.val = ${newHead?.val ?? -100}, newTail?.val = ${
      //       newTail?.val ?? -100
      //     }`
      //   );

      if (currentNode) {
        currentNode.next = newHead;

        if (newHead) {
          newHead.next = newTail;
        }
        currentNode = newTail;
      }
    }

    if (nextNode) {
      stack.push(nextNode);
    }
    head = nextNode;
  }

  if (currentNode && count % 2 === 1) {
    currentNode.next = null;
  }

  //   while (pointer) {
  //     console.log(`pointer.val = ${pointer.val}`);
  //     pointer = pointer.next;
  //   }

  //   console.log(
  //     `pointer?.val = ${pointer?.val ?? -100}, pointer?.next?.val = ${
  //       pointer?.next?.val ?? -100
  //     }`
  //   );

  return pointer.next;
}

/**
 * 执行用时：112 ms, 在所有 typescript 提交中击败了 5.41% 的用户
 * 内存消耗：40.2 MB, 在所有 typescript 提交中击败了 5.77% 的用户
 *
 * Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/swap-nodes-in-pairs/solution/liang-liang-jiao-huan-lian-biao-zhong-de-jie-di-91/)
 *
 * @param {(ListNode | null)} head
 * @returns {(ListNode | null)}
 */
function swapPairs(head: ListNode | null): ListNode | null {
  let pointer: ListNode = new ListNode(-1, head);
  let temp: ListNode | null = pointer;

  while (temp.next && temp.next.next) {
    const originNext: ListNode = temp.next;
    const originNextAfter: ListNode = temp.next.next;

    temp.next = originNextAfter;
    originNext.next = originNextAfter.next;
    originNextAfter.next = originNext;

    temp = originNext;
  }

  return pointer.next;
}

/**
 * 执行用时：92 ms, 在所有 typescript 提交中击败了 24.32% 的用户
 * 内存消耗：40.2 MB, 在所有 typescript 提交中击败了 5.77% 的用户
 *
 * Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/swap-nodes-in-pairs/solution/liang-liang-jiao-huan-lian-biao-zhong-de-jie-di-91/)
 *
 * @param {(ListNode | null)} head
 * @returns {(ListNode | null)}
 */
function swapPairs(head: ListNode | null): ListNode | null {
  if (!head || !head.next) {
    return head;
  }

  let newHead: ListNode | null = head.next;
  head.next = swapPairs(newHead.next);
  newHead.next = head;

  return newHead;
}
