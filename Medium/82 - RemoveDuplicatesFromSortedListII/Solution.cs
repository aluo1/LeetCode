// Question 82. Remove Duplicates from Sorted List II (https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list-ii/)

/**
 * Definition for singly-linked list.
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

/// <summary>
/// 执行用时：112 ms, 在所有 C# 提交中击败了 66.67% 的用户
/// 内存消耗：25.8 MB, 在所有 C# 提交中击败了 39.13% 的用户
/// 
/// Acknowledgement: This solution borrows idea from the 
/// [official solution](https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list-ii/solution/shan-chu-pai-xu-lian-biao-zhong-de-zhong-oayn/)
/// </summary>
public class Solution
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null) { return head; }

        ListNode dummyHead = new ListNode(0, head);

        head = dummyHead;
        while (head.next != null && head.next.next != null)
        {
            if (head.next.val == head.next.next.val)
            {
                int x = head.next.val;
                while (head.next != null && head.next.val == x)
                {
                    head.next = head.next.next;
                }
            }
            else
            {
                head = head.next;
            }
        }

        return dummyHead.next;
    }
}