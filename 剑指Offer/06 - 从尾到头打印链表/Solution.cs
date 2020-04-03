/// 面试题06. 从尾到头打印链表 (https://leetcode-cn.com/problems/cong-wei-dao-tou-da-yin-lian-biao-lcof/)
/// Difficulty: Easy


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
    public int[] ReversePrint(ListNode head)
    {
        // 执行用时 : 416 ms, 在所有 C# 提交中击败了 5.23% 的用户
        // 内存消耗 : 31.4 MB, 在所有 C# 提交中击败了 100.00% 的用户
        List<int> valueList = new List<int>();

        while (head != null)
        {
            valueList.Add(head.val);
            head = head.next;
        }

        valueList.Reverse();
        return valueList.ToArray();
    }
}