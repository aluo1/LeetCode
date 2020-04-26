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