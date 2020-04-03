/// 面试题59 - II. 队列的最大值
/// Difficulty: Medium
/// 执行用时: 388 ms, 在所有 C# 提交中击败了 16.67% 的用户
/// 内存消耗: 49 MB, 在所有 C# 提交中击败了 100.00% 的用户
/// 
/// 这道题最难的地方在于，读懂题目。。。

public class MaxQueue {
    private List<int> maxQueue;

    public MaxQueue() {
        this.maxQueue = new List<int>();
    }
    
    public int Max_value() {
        if (this.maxQueue.Count == 0) { return -1; }
        return this.maxQueue.Max();
    }
    
    public void Push_back(int value) {
        this.maxQueue.Add(value);
    }
    
    public int Pop_front() {
        if (this.maxQueue.Count == 0) { return -1; }

        int front = this.maxQueue[0];
        this.maxQueue = this.maxQueue.Skip(1).ToList();

        return front;
    }
}

/**
 * Your MaxQueue object will be instantiated and called as such:
 * MaxQueue obj = new MaxQueue();
 * int param_1 = obj.Max_value();
 * obj.Push_back(value);
 * int param_3 = obj.Pop_front();
 */