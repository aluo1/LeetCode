// Question 328. Odd Even Linked List (https://leetcode-cn.com/problems/odd-even-linked-list/)

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class ListNode 
{
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) 
    {
        this.val = val;
        this.next = next;
    }
}

/// <summary>
/// 执行用时：108 ms, 在所有 C# 提交中击败了 84.71% 的用户
/// 内存消耗：25.7 MB, 在所有 C# 提交中击败了 9.41% 的用户
/// </summary>
public class Solution 
{
    public ListNode OddEvenList(ListNode head) 
    {
        if (head == null || head.next == null) { return head; }
        ListNode HEAD_POINTER = head;
        ListNode EVEN_HEAD_POINTER = head.next;
        ListNode evenNode = head.next;

        while (evenNode != null && evenNode.next != null)
        {
            head.next = evenNode.next;
            head = head.next;

            evenNode.next = head.next;
            evenNode = evenNode.next;
        }

        head.next = EVEN_HEAD_POINTER;
        return HEAD_POINTER;
    }
}