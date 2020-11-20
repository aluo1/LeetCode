// Question 147. Insertion Sort List (https://leetcode-cn.com/problems/insertion-sort-list/)

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */

/// <summary>
/// 执行用时：140 ms, 在所有 C# 提交中击败了 46.67% 的用户
/// 内存消耗：25.4 MB, 在所有 C# 提交中击败了 13.33% 的用户
/// </summary>
public class ListNode 
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution 
{
    public ListNode InsertionSortList(ListNode head) 
    {
        var sortedList = new ListNode(-1);
        var SORTED_LIST_HEAD = sortedList;

        while (head != null)
        {
            ListNode currentNode = head;
            head = head.next;

            sortedList = SORTED_LIST_HEAD;
            while (sortedList.next != null && sortedList.next.val < currentNode.val)
            {
                sortedList = sortedList.next;
            }
            currentNode.next = sortedList.next;
            sortedList.next = currentNode;
        }

        return SORTED_LIST_HEAD.next;
    }
}