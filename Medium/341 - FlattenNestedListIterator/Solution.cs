// Question 341. Flatten Nested List IEnumerator (https://leetcode-cn.com/problems/flatten-nested-list-iterator/)

/** This is the interface that allows for creating nested lists. */
interface NestedInteger 
{
    // @return true if this NestedInteger holds a single integer, rather than a nested list.
    bool IsInteger();

    // @return the single integer that this NestedInteger holds, if it holds a single integer
    // Return null if this NestedInteger holds a nested list
    int GetInteger();

    // @return the nested list that this NestedInteger holds, if it holds a nested list
    // Return null if this NestedInteger holds a single integer
    IList<NestedInteger> GetList();
}

/// <summary>
/// 执行用时：276 ms, 在所有 C# 提交中击败了 84.62% 的用户
/// 内存消耗：32 MB, 在所有 C# 提交中击败了 100.00% 的用户
/// 
/// Acknowledgement: This solution is a duplicate of this 
/// [C# solution](https://leetcode-cn.com/problems/flatten-nested-list-iterator/solution/cshi-xian-zheng-que-li-jie-jie-kou-by-guan-xiao-er/)
/// </summary>
public class NestedIterator 
{
    private Stack<NestedInteger> _stack;
    private int? _next;

    public NestedIterator(IList<NestedInteger> nestedList) 
    {
        this._stack = new Stack<NestedInteger>();
        foreach (var l in Enumerable.Reverse(nestedList))
        {
            this._stack.Push(l);
        }

        this._next = -1;
        this.Next();
    }

    public bool HasNext() 
    {
        return this._next != null;
    }

    public int Next() 
    {
        if (this._next == null)
        {
            throw new Exception("Iterator is exhausted.");
        }

        var ans = (int) this._next.Value;
        this._next = null;

        while (this._stack.Count > 0 && this._next == null)
        {
            var current = this._stack.Pop();
            if (current.IsInteger())
            {
                this._next = current.GetInteger();
            }
            else
            {
                foreach (var l in Enumerable.Reverse(current.GetList()))
                {
                    this._stack.Push(l);
                }
            }
        }
        
        return ans;
    }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */