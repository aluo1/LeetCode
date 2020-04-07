/// Question 206. Reverse Linked List (https://leetcode-cn.com/problems/reverse-linked-list/)

/**
 *
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        // 执行用时: 104 ms, 在所有 C# 提交中击败了 90.42% 的用户
        // 内存消耗: 24.5 MB, 在所有 C# 提交中击败了 7.14% 的用户
        ListNode reversedNode = null;

        while (head != null)
        {
            ListNode current = reversedNode;
            reversedNode = new ListNode(head.val);
            reversedNode.next = current;
            head = head.next;
        }

        return reversedNode;
    }

    public ListNode ReverseListWithoutNewNode(ListNode head)
    {
        // 执行用时: 108 ms, 在所有 C# 提交中击败了 74.65% 的用户
        // 内存消耗: 24.1 MB, 在所有 C# 提交中击败了 7.14% 的用户
        ListNode reversedNode = null;

        while (head != null)
        {
            ListNode current = reversedNode;

            reversedNode = head;
            head = head.next;

            reversedNode.next = current;
        }

        return reversedNode;
    }
}