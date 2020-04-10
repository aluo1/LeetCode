/// Question 155. Min Stack (https://leetcode-cn.com/problems/min-stack/)

public class MinStack
{
    /// 执行用时: 160 ms, 在所有 C# 提交中击败了 78.40% 的用户
    /// 内存消耗: 35.1 MB, 在所有 C# 提交中击败了 20.00% 的用户

    List<int> minStack;
    int minVal;


    /** initialize your data structure here. */
    public MinStack()
    {
        this.minStack = new List<int>();
        this.minVal = int.MaxValue;
    }

    public void Push(int x)
    {
        this.minStack.Add(x);
        if (x < this.minVal)
        {
            this.minVal = x;
        }
    }

    public void Pop()
    {
        this.minStack.RemoveAt(this.minStack.Count() - 1);
        if (this.minStack.Count() > 0)
        {
            this.minVal = this.minStack.Min();
        }
        else
        {
            this.minVal = int.MaxValue;
        }
    }

    public int Top()
    {
        return this.minStack.ElementAt(this.minStack.Count() - 1);
    }

    public int GetMin()
    {
        return this.minVal;
    }
}

public class MinStackWithAsyncHelperStack
{
    /// 执行用时 : 152 ms, 在所有 C# 提交中击败了 94.67% 的用户
    /// 内存消耗 : 35.1 MB, 在所有 C# 提交中击败了 20.00% 的用户

    List<int> minStack;
    List<int> minValStack;

    /** initialize your data structure here. */
    public MinStack()
    {
        this.minStack = new List<int>();
        this.minValStack = new List<int>();
    }

    public void Push(int x)
    {
        this.minStack.Add(x);

        if (this.minValStack.Count() == 0 || this.minValStack.ElementAt(this.minValStack.Count() - 1) >= x)
        {
            this.minValStack.Add(x);
        }
    }

    public void Pop()
    {
        int valueToRemove = this.minStack.ElementAt(this.minStack.Count() - 1);
        int currentMinValue = this.minValStack.ElementAt(this.minValStack.Count() - 1);

        this.minStack.RemoveAt(this.minStack.Count() - 1);

        if (currentMinValue == valueToRemove)
        {
            this.minValStack.RemoveAt(this.minValStack.Count() - 1);
        }
    }

    public int Top()
    {
        return this.minStack.ElementAt(this.minStack.Count() - 1);
    }

    public int GetMin()
    {
        return this.minValStack.ElementAt(this.minValStack.Count() - 1);
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
