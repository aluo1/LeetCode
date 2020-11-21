// Question 148. Sort List (https://leetcode-cn.com/problems/sort-list/)

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
/// 执行用时：156 ms, 在所有 C# 提交中击败了 35.29% 的用户
/// 内存消耗：34 MB, 在所有 C# 提交中击败了 31.76% 的用户
/// 
/// Acknowledgement: This solution is a C#-version duplicate of the [official solution](https://leetcode-cn.com/problems/sort-list/solution/pai-xu-lian-biao-by-leetcode-solution/) method II - bottom-up merge sort.
/// </summary>
public class Solution 
{
    public ListNode SortList(ListNode head) 
    {
        if (head == null) { return head; }

        // Get node list's length.
        int length = 0;
        ListNode node = head;
        while (node != null) 
        {
            length++;
            node = node.next;
        }

        ListNode SORTED_LIST_HEAD = new ListNode(-1, head);
        
        // Be aware we update subLength using left shift assignment, which means we shift 1 bit to 
        // the left after each iteration.
        for (int subLength = 1; subLength < length; subLength <<= 1)
        {
            ListNode previous = SORTED_LIST_HEAD;
            ListNode current = SORTED_LIST_HEAD.next;

            while (current != null)
            {
                ListNode head1 = current;
                for (int i = 1; i < subLength && current.next != null; i++)
                {
                    current = current.next;
                }

                ListNode head2 = current.next;
                current.next = null;
                current = head2;

                for (int i = 1; i < subLength && current != null && current.next != null; i++)
                {
                    current = current.next;
                }

                ListNode next = null;
                if (current != null)
                {
                    next = current.next;
                    current.next = null;
                }

                ListNode merged = Merge(head1, head2);
                previous.next = merged;
                while (previous.next != null)
                {
                    previous = previous.next;
                }
                current = next;
            }
        }

        return SORTED_LIST_HEAD.next;
    }

    private ListNode Merge(ListNode head1, ListNode head2)
    {
        ListNode dummyHead = new ListNode(0);
        ListNode temp = dummyHead;
        ListNode temp1 = head1;
        ListNode temp2 = head2;

        while (temp1 != null && temp2 != null) 
        {
            if (temp1.val <= temp2.val)
            {
                temp.next = temp1;
                temp1 = temp1.next;
            } 
            else 
            {
                temp.next = temp2;
                temp2 = temp2.next;
            }
            temp = temp.next;
        }

        if (temp1 != null)
        {
            temp.next = temp1;
        }
        else if (temp2 != null)
        {
            temp.next = temp2;
        }

        return dummyHead.next;
    }
}