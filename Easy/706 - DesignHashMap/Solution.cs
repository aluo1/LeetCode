// Question 706. Design HashMap (https://leetcode-cn.com/problems/design-hashmap/)

/// <summary>
/// 执行用时：356 ms, 在所有 C# 提交中击败了 60.71% 的用户
/// 内存消耗：48.9 MB, 在所有 C# 提交中击败了 53.57% 的用户
/// </summary>
public class MyHashMap 
{
    private readonly int HASHSET_BASE = 2027;
    private List<List<(int, int)>> _hashMapList;

    private int CalculateHash(int value) 
    {
        return value % this.HASHSET_BASE;
    }

    /** Initialize your data structure here. */
    public MyHashMap() 
    {
        this._hashMapList = new List<List<(int, int)>>();
        for (var i = 0; i < this.HASHSET_BASE; i++)
        {
            this._hashMapList.Add(new List<(int, int)>());
        }
    }
    
    /** value will always be non-negative. */
    public void Put(int key, int value) 
    {
        int hashValue = this.CalculateHash(key);
        this.Remove(key);
        this._hashMapList[hashValue].Add((key, value));
    }
    
    /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
    public int Get(int key) 
    {
        int hashValue = this.CalculateHash(key);
        var hashMapOfValue = this._hashMapList[hashValue];

        foreach ((int hashKey, int valueOfHash) in hashMapOfValue)
        {
            if (hashKey == key) { return valueOfHash; }
        }

        return -1;
    }
    
    /** Removes the mapping of the specified value key if this map contains a mapping for the key */
    public void Remove(int key) 
    {
        int hashValue = this.CalculateHash(key);

        var hashList = this._hashMapList[hashValue];
        var newList = new List<(int, int)>();
        foreach ((int hashKey, int valueOfHash) in hashList)
        {
            if (hashKey != key) 
            {
                newList.Add((hashKey, valueOfHash));
            }
        }
        
        this._hashMapList[hashValue] = newList;
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */