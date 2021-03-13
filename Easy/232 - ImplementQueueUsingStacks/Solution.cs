// Question 232. Implement Queue using Stacks (https://leetcode-cn.com/problems/implement-queue-using-stacks/)

/// <summary>
/// 执行用时：116 ms, 在所有 C# 提交中击败了 88.37% 的用户
/// 内存消耗：23.8 MB, 在所有 C# 提交中击败了 97.67% 的用户
/// </summary>
public class MyQueue
{
    private Stack<int> queueInStack;

    /** Initialize your data structure here. */
    public MyQueue()
    {
        this.queueInStack = new Stack<int>();
    }

    /** Push element x to the back of queue. */
    public void Push(int x)
    {
        this.queueInStack.Push(x);
    }

    /** Removes the element from in front of queue and returns that element. */
    public int Pop()
    {
        int[] queueArray = this.queueInStack.ToArray();
        int topElement = queueArray[queueArray.Count() - 1];

        this.queueInStack = new Stack<int>(queueArray.Take(queueArray.Count() - 1).Reverse());

        return topElement;
    }

    /** Get the front element. */
    public int Peek()
    {
        return this.queueInStack.ToArray()[this.queueInStack.Count - 1];
    }

    /** Returns whether the queue is empty. */
    public bool Empty()
    {
        return this.queueInStack.Count == 0;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */
