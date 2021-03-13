// Question 705. Design HashSet (https://leetcode-cn.com/problems/design-hashset/)

/// <summary>
/// 执行用时：276 ms, 在所有 C# 提交中击败了 66.67% 的用户
/// 内存消耗：50.3 MB, 在所有 C# 提交中击败了 6.67% 的用户
/// 
/// Acknowledgement: This solution borrows idea from the 
/// [official solution](https://leetcode-cn.com/problems/design-hashset/solution/she-ji-ha-xi-ji-he-by-leetcode-solution-xp4t/)
/// </summary>
public class MyHashSet 
{
    private bool[] hashSet;

    /** Initialize your data structure here. */
    public MyHashSet() 
    {
        this.hashSet = new bool[1000000];
    }
    
    public void Add(int key) 
    {
        this.hashSet[key] = true;
    }
    
    public void Remove(int key) 
    {
        this.hashSet[key] = false;
    }
    
    /** Returns true if this set contains the specified element */
    public bool Contains(int key) 
    {
        return this.hashSet[key];
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */