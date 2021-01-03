// Question 86. Partition List (https://leetcode-cn.com/problems/partition-list/)

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */

public class ListNode 
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

/// <summary>
/// 执行用时：100 ms, 在所有 C# 提交中击败了 100.00% 的用户
/// 内存消耗：25.1 MB, 在所有 C# 提交中击败了 6.06% 的用户
/// </summary>
public class Solution 
{
    public ListNode Partition(ListNode head, int x) 
    {
        ListNode newHead = new ListNode(-1);
        newHead.next = head;

        ListNode slow = newHead;
        ListNode fast = head;

        ListNode greaterListHead = new ListNode(-1);
        ListNode greaterList = greaterListHead;

        while (fast != null)
        {
            // System.Console.WriteLine($"slow = {slow.val}, fast = {fast.val}, greaterList = {greaterList.val}");

            ListNode next = fast.next;
            
            if (fast.val < x)
            {
                slow.next = fast;
                slow = slow.next;
                slow.next = null;
            }
            else
            {
                greaterList.next = fast;
                greaterList = greaterList.next;
                greaterList.next = null;
            }
            fast = next;
        }

        // System.Console.WriteLine($"slow = {slow.val}, fast = {fast}, greaterList = {greaterList.val}, greaterListHead.next = {greaterListHead.next.val}");
        slow.next = greaterListHead.next;

        return newHead.next;
    }
}