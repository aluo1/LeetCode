// 面试题 02.01. 移除重复节点 (https://leetcode-cn.com/problems/remove-duplicate-node-lcci/)
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
    // 执行用时 : 132 ms, 在所有 C# 提交中击败了 74.51% 的用户
    // 内存消耗 : 30.6 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public ListNode RemoveDuplicateNodes(ListNode head)
    {
        HashSet<int> recordedValues = new HashSet<int>();
        ListNode headPointer = head;

        while (head != null)
        {
            recordedValues.Add(head.val);

            ListNode nextPointer = head.next;
            while (nextPointer != null && recordedValues.Contains(nextPointer.val))
            {
                nextPointer = nextPointer.next;
            }

            head.next = nextPointer;
            head = head.next;
        }

        return headPointer;
    }
}