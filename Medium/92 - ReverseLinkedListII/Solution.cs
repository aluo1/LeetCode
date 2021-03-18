// Question 92. Reverse Linked List II (https://leetcode-cn.com/problems/reverse-linked-list-ii/)

/**
 * Definition for singly-linked list.
 */
public class ListNode 
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

/// <summary>
/// 执行用时：100 ms, 在所有 C# 提交中击败了 90.27% 的用户
/// 内存消耗：24 MB, 在所有 C# 提交中击败了 88.49% 的用户
/// 
/// Acknowledgement: This solution is the C#-version duplicate of the 
/// [official solution](https://leetcode-cn.com/problems/reverse-linked-list-ii/solution/fan-zhuan-lian-biao-ii-by-leetcode-solut-teyq/)
/// </summary>
public class Solution 
{
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        if (left == right) { return head; }

        ListNode dummyHead = new ListNode(-1);
        dummyHead.next = head;

        ListNode previousNode = dummyHead;
        int currentIndex = 1;

        // Move to left node's parent.
        for (currentIndex = 0; currentIndex < left - 1; currentIndex++)
        { 
            previousNode = previousNode.next;
        }

        ListNode currentPointer = previousNode.next;
        ListNode nexNode;

        while (currentIndex < right - 1)
        {
            nexNode = currentPointer.next;
            currentPointer.next = nexNode.next;
            nexNode.next = previousNode.next;
            previousNode.next = nexNode;
            currentIndex++;
        }

        return dummyHead.next;
    }
}