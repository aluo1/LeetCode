/// 面试题22. 链表中倒数第k个节点 (https://leetcode-cn.com/problems/lian-biao-zhong-dao-shu-di-kge-jie-dian-lcof/)
/// Difficulty: Easy
/// 执行用时: 104 ms, 在所有 C# 提交中击败了 91.75% 的用户
/// 内存消耗: 24.5 MB, 在所有 C# 提交中击败了 100.00% 的用户
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
    public ListNode GetKthFromEnd(ListNode head, int k)
    {
        int listLength = 0;
        ListNode headPointer = head;

        while (head != null)
        {
            listLength++;
            head = head.next;
        }

        while (listLength != k)
        {
            headPointer = headPointer.next;
            listLength--;
        }

        return headPointer;
    }
}