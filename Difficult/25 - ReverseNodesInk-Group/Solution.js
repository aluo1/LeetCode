/**
 * Question 25. Reverse Nodes in k-Group (https://leetcode-cn.com/problems/reverse-nodes-in-k-group/)
 *
 * 执行用时: 88 ms, 在所有 JavaScript 提交中击败了 75.24% 的用户
 * 内存消耗: 37.6 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 * Acknowledgement: This solution gets idea from [this solution](https://leetcode-cn.com/problems/reverse-nodes-in-k-group/solution/kge-yi-zu-fan-zhuan-lian-biao-by-powcai/).
 * 
 * Definition for singly-linked list.
 * function ListNode(val) {
 *     this.val = val;
 *     this.next = null;
 * }
 */
/**
 * @param {ListNode} head
 * @param {number} k
 * @return {ListNode}
 */
var reverseKGroup = function (head, k) {
  let kStack = [];
  const hair = new ListNode(0);
  let currentPointer = hair;

  while (currentPointer) {
    // Add k nodes to stack.
    let count = 1;
    let currentHead = head;
    while (kStack.length !== k && head) {
      kStack.push(head);
      head = head.next;
    }

    if (kStack.length !== k) {
      currentPointer.next = currentHead;
      break;
    }

    // Pop nodes from stack to reverse it.
    while (kStack.length) {
      currentPointer.next = kStack.pop();
      currentPointer = currentPointer.next;
    }
  }

  return hair.next;
};
