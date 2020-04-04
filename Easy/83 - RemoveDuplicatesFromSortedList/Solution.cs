/// Question 83. Remove Duplicates from Sorted List (https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list/submissions/)
/// Difficulty: Easy
/// 执行用时: 116 ms, 在所有 C# 提交中击败了 53.43% 的用户
/// 内存消耗: 25.8 MB, 在所有 C# 提交中击败了 12.50% 的用户

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
    public ListNode DeleteDuplicates(ListNode head)
    {
        ListNode headPointer = head;

        while (head != null)
        {
            while (head.next != null && head.val == head.next.val)
            {
                head.next = head.next.next;
            }

            head = head.next;
        }

        return headPointer;
    }
}