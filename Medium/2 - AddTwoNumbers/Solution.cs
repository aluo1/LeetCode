/// Question 2. Add Two Numbers (https://leetcode-cn.com/problems/add-two-numbers/)
/// Difficulty: Easy
/// 
/// 执行用时 : 136 ms, 在所有 C# 提交中击败了 36.34% 的用户
/// 内存消耗 : 27.6 MB, 在所有 C# 提交中击败了 6.11% 的用户

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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode sumNode = new ListNode(0);
        ListNode pointer = sumNode;
        int tenShift = 0;

        while (l1 != null || l2 != null)
        {
            int l1Val = l1?.val ?? 0;
            int l2Val = l2?.val ?? 0;

            int sum = l1Val + l2Val + tenShift;
            tenShift = sum / 10;

            sumNode.next = new ListNode(sum % 10);
            sumNode = sumNode.next;

            if (l1 != null)
            {
                l1 = l1.next;
            }

            if (l2 != null)
            {
                l2 = l2.next;
            }
        }

        if (tenShift > 0)
        {
            sumNode.next = new ListNode(1);
            sumNode = sumNode.next;
        }

        return pointer.next;
    }
}