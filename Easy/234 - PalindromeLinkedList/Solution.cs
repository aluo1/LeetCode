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
/// 执行用时：120 ms, 在所有 C# 提交中击败了 77.78% 的用户
/// 内存消耗：29.7 MB, 在所有 C# 提交中击败了 19.21% 的用户
/// 
/// Acknowledgement: This solution borrows idea from the [official solution method II](https://leetcode-cn.com/problems/palindrome-linked-list/solution/hui-wen-lian-biao-by-leetcode-solution/)
/// </summary>
public class Solution
{
    private ListNode frontPointer { get; set; }

    public bool IsPalindrome(ListNode head)
    {
        this.frontPointer = head;
        return this.RecursivelyCheck(head);
    }

    private bool RecursivelyCheck(ListNode head)
    {
        if (head != null)
        {
            if (!this.RecursivelyCheck(head.next))
            {
                return false;
            }

            if (head.val != this.frontPointer.val)
            {
                return false;
            }

            this.frontPointer = this.frontPointer.next;
        }

        return true;
    }
}