// Question 141. Linked List Cycle (https://leetcode-cn.com/problems/linked-list-cycle/)

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution
{
    /// <summary>
    /// 执行用时：124 ms, 在所有 C# 提交中击败了 29.64% 的用户
    /// 内存消耗：26.6 MB, 在所有 C# 提交中击败了 5.21% 的用户
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public bool HasCycle(ListNode head)
    {
        Dictionary<ListNode, bool> visited = new Dictionary<ListNode, bool>();

        while (head != null)
        {
            if (visited.ContainsKey(head))
            {
                return true;
            }

            visited[head] = true;
            head = head.next;
        }

        return false;
    }

    /// <summary>
    /// 执行用时：116 ms, 在所有 C# 提交中击败了 68.19% 的用户
    /// 内存消耗：24.9 MB, 在所有 C# 提交中击败了 96.09% 的用户
    /// 
    /// Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/linked-list-cycle/solution/huan-xing-lian-biao-by-leetcode-solution/)
    /// 
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public bool HasCycleUsingFloydAlgorithm(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return false;
        }

        ListNode fast = head.next;
        ListNode slow = head;

        while (fast != slow)
        {
            if (fast == null || fast.next == null)
            {
                return false;
            }

            slow = slow.next;
            fast = fast.next.next;
        }

        return true;
    }
}

