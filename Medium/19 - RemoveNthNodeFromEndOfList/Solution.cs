using System.Collections.Generic;
// Question 19. Remove Nth Node From End of List (https://leetcode-cn.com/problems/remove-nth-node-from-end-of-list/)

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
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    /// <summary>
    /// 执行用时：100 ms, 在所有 C# 提交中击败了 97.11% 的用户
    /// 内存消耗：24.7 MB, 在所有 C# 提交中击败了 30.28% 的用户
    /// 
    /// Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/remove-nth-node-from-end-of-list/)
    /// 
    /// </summary>
    /// <param name="head"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var headPointer = new ListNode(0, head);
        var fast = head;
        var slow = headPointer;

        for (int i = 0; i < n; i++)
        {
            fast = fast.next;
        }

        while (fast != null)
        {
            fast = fast.next;
            slow = slow.next;
        }

        if (slow.next.next != null)
        {
            slow.next = slow.next.next;
        }

        return headPointer.next;
    }
}