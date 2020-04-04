/// Question 237. Delete Node in a Linked List
/// Difficulty: Easy
/// 执行用时: 110840 ms, 在所有 C# 提交中击败了 89.51% 的用户
/// 内存消耗: 25.3 MB, 在所有 C# 提交中击败了 8.70% 的用户

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution
{
    public void DeleteNode(ListNode node)
    {
        node.val = node.next.val;
        node.next = node.next.next;
    }
}