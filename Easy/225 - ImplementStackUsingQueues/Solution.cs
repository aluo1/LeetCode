/// Question 225. Implement Stack using Queues (https://leetcode-cn.com/problems/implement-stack-using-queues/)
/// 执行用时: 124 ms, 在所有 C# 提交中击败了 63.13% 的用户
/// 内存消耗: 23.7 MB, 在所有 C# 提交中击败了 100.00% 的用户

public class MyStack
{
    private Queue<int> queueForStack;

    /** Initialize your data structure here. */
    public MyStack()
    {
        this.queueForStack = new Queue<int>();
    }

    /** Push element x onto stack. */
    public void Push(int x)
    {
        this.queueForStack.Enqueue(x);
    }

    /** Removes the element on top of the stack and returns that element. */
    public int Pop()
    {
        int[] elements = this.queueForStack.ToArray();
        int lastElem = elements[this.queueForStack.Count - 1];

        this.queueForStack = new Queue<int>(elements.Take(this.queueForStack.Count - 1));
        return lastElem;
    }

    /** Get the top element. */
    public int Top()
    {
        return this.queueForStack.ToArray()[this.queueForStack.Count - 1];
    }

    /** Returns whether the stack is empty. */
    public bool Empty()
    {
        return this.queueForStack.Count == 0;
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */
