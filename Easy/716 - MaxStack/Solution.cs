/// Question 716. Max Stack (https://leetcode-cn.com/problems/max-stack/)

public class MaxStack
{
    // 执行用时: 236 ms, 在所有 C# 提交中击败了 52.94% 的用户
    // 内存消耗: 44.3 MB, 在所有 C# 提交中击败了 100.00% 的用户

    Stack<int> maxStack;
    Stack<int> stack;


    /** initialize your data structure here. */
    public MaxStack()
    {
        this.maxStack = new Stack<int>();
        this.stack = new Stack<int>();
    }

    public void Push(int x)
    {
        this.stack.Push(x);

        int max = this.maxStack.Any() ? this.maxStack.Peek() : x;
        this.maxStack.Push(Math.Max(max, x));
    }

    public int Pop()
    {
        this.maxStack.Pop();
        return this.stack.Pop();
    }

    public int Top()
    {
        return this.stack.Peek();
    }

    public int PeekMax()
    {
        return this.maxStack.Peek();
    }

    public int PopMax()
    {
        int max = this.PeekMax();

        Stack<int> bufferStack = new Stack<int>();
        while (this.Top() != max) { bufferStack.Push(this.Pop()); }
        this.Pop();
        while (bufferStack.Any()) { this.Push(bufferStack.Pop()); }

        return max;
    }
}

/**
 * Your MaxStack object will be instantiated and called as such:
 * MaxStack obj = new MaxStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.PeekMax();
 * int param_5 = obj.PopMax();
 */
