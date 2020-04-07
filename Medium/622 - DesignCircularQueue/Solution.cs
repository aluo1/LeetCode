/// Question 622. Design Circular Queue (https://leetcode-cn.com/problems/design-circular-queue/)
/// Difficulty: Medium
/// 执行用时: 232 ms, 在所有 C# 提交中击败了 6.85% 的用户
/// 内存消耗: 34.7 MB, 在所有 C# 提交中击败了 100.00% 的用户


public class MyCircularQueue
{
    private readonly int queueSize;
    private int[] queue;
    private int headPointer, tailPointer;

    /** Initialize your data structure here. Set the size of the queue to be k. */
    public MyCircularQueue(int k)
    {
        this.queueSize = k;
        this.queue = new int[k];
        this.headPointer = 0;
        this.tailPointer = 0;
    }

    /** Insert an element into the circular queue. Return true if the operation is successful. */
    public bool EnQueue(int value)
    {
        if (this.IsFull()) { return false; }

        this.queue[this.tailPointer % this.queueSize] = value;
        this.tailPointer++;
        return true;
    }

    /** Delete an element from the circular queue. Return true if the operation is successful. */
    public bool DeQueue()
    {
        if (this.IsEmpty()) { return false; }

        this.headPointer++;
        return true;
    }

    /** Get the front item from the queue. */
    public int Front()
    {
        if (this.IsEmpty()) { return -1; }

        return this.queue[this.headPointer % this.queueSize];
    }

    /** Get the last item from the queue. */
    public int Rear()
    {
        if (this.IsEmpty()) { return -1; }

        return this.queue[(this.tailPointer - 1) % this.queueSize];
    }

    /** Checks whether the circular queue is empty or not. */
    public bool IsEmpty()
    {
        return this.headPointer.Equals(this.tailPointer);
    }

    /** Checks whether the circular queue is full or not. */
    public bool IsFull()
    {
        return this.tailPointer - this.headPointer == this.queueSize;
    }
}

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */
