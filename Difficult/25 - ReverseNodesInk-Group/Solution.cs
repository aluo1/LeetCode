/// Question 25. Reverse Nodes in k-Group (https://leetcode-cn.com/problems/reverse-nodes-in-k-group/)

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
    // 执行用时: 124 ms, 在所有 C# 提交中击败了 36.43% 的用户
    // 内存消耗: 27 MB, 在所有 C# 提交中击败了 100.00% 的用户
    // Acknowledgement: This solution gets idea from [this solution](https://leetcode-cn.com/problems/reverse-nodes-in-k-group/solution/kge-yi-zu-fan-zhuan-lian-biao-by-powcai/).
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        Stack<ListNode> stack = new Stack<ListNode>();
        ListNode hair = new ListNode(0);

        ListNode currentPointer = hair;

        while (currentPointer != null)
        {
            ListNode currentHead = head;
            while (stack.Count != k && head != null)
            {
                stack.Push(head);
                head = head.next;
            }

            if (stack.Count != k)
            {
                currentPointer.next = currentHead;
                break;
            }

            while (stack.Any())
            {
                currentPointer.next = stack.Pop();
                currentPointer = currentPointer.next;
            }
        }

        return hair.next;
    }
}