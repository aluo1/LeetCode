/// Question 876. Middle of the Linked List
/// Difficulty: Easy

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode MiddleNode(ListNode head) {
        // FirstAttemptMiddleNode(head);
        return SecondAttemptMiddleNode(head);
    }

    /// <summary>
    /// My First Attempt.
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public ListNode FirstAttemptMiddleNode(ListNode head) {
        /// 执行用时: 108 ms, 在所有 C# 提交中击败了 44.12% 的用户
        /// 内存消耗: 23.6 MB, 在所有 C# 提交中击败了 7.41 % 的用户

        List<ListNode> listNodes = new List<ListNode>();
        
        while (head.next != null) {
            listNodes.Add(head);
            head = head.next;
        }
        
        listNodes.Add(head);

        int nodeCounts = listNodes.Count;

        if (nodeCounts % 2 != 0) {
            return listNodes[(nodeCounts - 1) / 2];
        } else {
            return listNodes[nodeCounts / 2];
        }
    }

    /// <summary>
    /// My Second Attempt.
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public ListNode SecondAttemptMiddleNode(ListNode head) {
        /// 执行用时: 96 ms, 在所有 C# 提交中击败了 98.53% 的用户
        /// 内存消耗: 23.8 MB, 在所有 C# 提交中击败了 7.41 % 的用户

        List<ListNode> listNodes = new List<ListNode>();
        
        while (head.next != null) {
            listNodes.Add(head);
            head = head.next;
        }
        
        listNodes.Add(head);

        int nodeCounts = listNodes.Count;

        if (nodeCounts % 2 != 0) {
            return listNodes[(nodeCounts - 1) / 2];
        } else {
            return listNodes[nodeCounts / 2];
        }
    }
}