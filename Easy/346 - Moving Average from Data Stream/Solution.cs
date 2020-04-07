/// Question 346. Moving Average from Data Stream (https://leetcode-cn.com/problems/moving-average-from-data-stream/)
/// 
/// 执行用时: 776 ms, 在所有 C# 提交中击败了 7.14% 的用户
/// 内存消耗: 33.6 MB, 在所有 C# 提交中击败了 100.00% 的用户

public class MovingAverage
{
    private Queue queue;
    private int queueSize;

    /** Initialize your data structure here. */
    public MovingAverage(int size)
    {
        this.queue = new Queue(size);
        this.queueSize = size;
    }

    public double Next(int val)
    {
        if (this.queue.Count >= this.queueSize)
        {
            this.queue.Dequeue();
        }
        this.queue.Enqueue(val);
        return this.queue.ToArray().Select(queueVal => queueVal as int?).Where(nullableInt => nullableInt.HasValue).Select(nullableInt => nullableInt.Value).Sum() / (1.0 * this.queue.Count);
    }
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */
