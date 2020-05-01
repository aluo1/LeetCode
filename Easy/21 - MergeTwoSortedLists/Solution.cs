// Question 21. Merge Two Sorted Lists (https://leetcode-cn.com/problems/merge-two-sorted-lists/)
// Difficulty: Easy

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
    // 执行用时: 108 ms, 在所有 C# 提交中击败了 82.64% 的用户
    // 内存消耗: 25.9 MB, 在所有 C# 提交中击败了 5.71% 的用户

    public ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {
        if (l1 == null) { return l2; }
        if (l2 == null) { return l1; }

        ListNode mergedNode;

        if (l1.val < l2.val)
        {
            mergedNode = new ListNode(l1.val);
            l1 = l1.next;
        }
        else
        {
            mergedNode = new ListNode(l2.val);
            l2 = l2.next;
        }

        bool breakLoop = false;
        ListNode iterationNode = mergedNode;

        while (l1 != null || l2 != null)
        {
            ListNode newNode;


            if (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    newNode = new ListNode(l1.val);
                    l1 = l1.next;
                }
                else
                {
                    newNode = new ListNode(l2.val);
                    l2 = l2.next;
                }
            }
            else if (l1 != null)
            {
                // l2 is null now.
                newNode = l1;
                breakLoop = true;
            }
            else
            {
                // l1 is null, l2 is not null now.
                newNode = l2;
                breakLoop = true;
            }

            iterationNode.next = newNode;
            iterationNode = iterationNode.next;

            if (breakLoop)
            {
                break;
            }
        }

        return mergedNode;
    }
}


public class Solution
{
    // 执行用时: 104 ms, 在所有 C# 提交中击败了 93.70% 的用户
    // 内存消耗: 25.8 MB, 在所有 C# 提交中击败了 25.00% 的用户
    public ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {
        if (l1 == null) { return l2; }
        if (l2 == null) { return l1; }

        ListNode mergedNode = l1.val > l2.val ? l2 : l1;
        ListNode currentNode = mergedNode;

        while (l1 != null && l2 != null)
        {
            ListNode swappingNode;

            if (l1.val > l2.val)
            {
                swappingNode = l2;
                l2 = l2.next;
            }
            else
            {
                swappingNode = l1;
                l1 = l1.next;
            }

            currentNode.next = swappingNode;
            currentNode = currentNode.next;
        }

        currentNode.next = l1 == null ? l2 : l1;

        return mergedNode;
    }
}