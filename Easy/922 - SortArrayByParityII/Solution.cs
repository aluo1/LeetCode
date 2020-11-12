// Question 922. Sort Array By Parity II (https://leetcode-cn.com/problems/sort-array-by-parity-ii/)

/// <summary>
/// 执行用时：324 ms, 在所有 C# 提交中击败了 62.00% 的用户
/// 内存消耗：37.5 MB, 在所有 C# 提交中击败了 6.12% 的用户
/// </summary>
public class Solution 
{
    public int[] SortArrayByParityII(int[] A) 
    {
        int arraySize = A.Count();

        Queue<int> oddQueue = new Queue<int>();
        Queue<int> evenQueue = new Queue<int>();

        for (int i = 0; i < arraySize; i++)
        {
            int currentValue = A[i];
            if (i % 2 == 0)
            {
                evenQueue.Enqueue(currentValue);
            }
            else
            {
                oddQueue.Enqueue(currentValue);
            }
        }

        int[] sortedArray = new int[arraySize];
        
        for (int i = 0; i < arraySize; i++)
        {
            sortedArray[i] = i % 2 == 0 ? evenQueue.Dequeue() : oddQueue.Dequeue();
        }

        return sortedArray;
    }
}