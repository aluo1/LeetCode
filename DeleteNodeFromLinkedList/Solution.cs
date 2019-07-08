/// Question 237. Delete Node in a Linked List
/// Difficulty: Easy
/// 执行用时: 140 ms, 在所有 C# 提交中击败了 95.78% 的用户
/// 内存消耗: 23.1 MB, 在所有 C# 提交中击败了 29.41% 的用户

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public void DeleteNode(ListNode node) {
        node.val = node.next.val;
        node.next = node.next.next;
    }
}