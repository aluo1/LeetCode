/// Question 23. Merge k Sorted Lists (https://leetcode-cn.com/problems/merge-k-sorted-lists/)

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
    // 执行用时: 1376 ms, 在所有 C# 提交中击败了 5.14% 的用户
    // 内存消耗: 29.4 MB, 在所有 C# 提交中击败了 50.00% 的用户
    public ListNode MergeKLists(ListNode[] lists)
    {
        int listCount = lists.Count();
        if (listCount == 0 || (listCount == 1 && lists[0] == null)) { return null; }

        ListNode mergedSortedLinkedList = new ListNode();
        ListNode currentPointer = mergedSortedLinkedList;

        List<ListNode> nodesList = new List<ListNode>(lists).Where(node => node != null).ToList();
        listCount = nodesList.Count();
        if (listCount == 0) { return null; }

        int currentMin = nodesList.Select(node => node.val).Min();
        int nodeIndexToUpdate = 0;
        ListNode currentNode;

        while (listCount > 1)
        {
            for (int i = 0; i < listCount; i++)
            {
                currentNode = nodesList.ElementAt(i);

                if (currentNode.val == currentMin)
                {
                    currentPointer.next = currentNode;
                    currentPointer = currentPointer.next;
                    nodeIndexToUpdate = i;
                    break;
                }
            }

            nodesList.RemoveAt(nodeIndexToUpdate);
            if (currentPointer.next != null)
            {
                nodesList.Insert(nodeIndexToUpdate, currentPointer.next);
            }
            else
            {
                listCount--;
            }

            currentMin = nodesList.Select(node => node.val).Min();
        }

        if (listCount == 1)
        {
            currentPointer.next = nodesList.ElementAt(0);
        }

        mergedSortedLinkedList = mergedSortedLinkedList.next;
        return mergedSortedLinkedList;
    }
}


public class Solution
{
    // 执行用时: 132 ms, 在所有 C# 提交中击败了 85.98% 的用户
    // 内存消耗: 29.4 MB, 在所有 C# 提交中击败了 50.00% 的用户
    // Acknowledgement: This idea borrows from the [official solution](https://leetcode-cn.com/problems/merge-k-sorted-lists/solution/he-bing-kge-pai-xu-lian-biao-by-leetcode-solutio-2/).
    public ListNode MergeKLists(ListNode[] lists)
    {
        return this.Merge(lists, 0, lists.Count() - 1);
    }

    private ListNode Merge(ListNode[] lists, int left, int right)
    {
        if (left > right) { return null; }
        if (left == right) { return lists[left]; }

        int mid = (left + right) / 2;

        return this.MergeTwoLists(Merge(lists, left, mid), Merge(lists, mid + 1, right));
    }

    private ListNode MergeTwoLists(ListNode lists1, ListNode lists2)
    {
        if (lists1 == null || lists2 == null) { return lists1 == null ? lists2 : lists1; }
        ListNode head = new ListNode();
        ListNode tail = head;

        while (lists1 != null && lists2 != null)
        {
            if (lists1.val < lists2.val)
            {
                tail.next = lists1;
                lists1 = lists1.next;
            }
            else
            {
                tail.next = lists2;
                lists2 = lists2.next;
            }

            tail = tail.next;
        }

        tail.next = lists1 != null ? lists1 : lists2;

        return head.next;
    }
}