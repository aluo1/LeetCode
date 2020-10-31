// Question 381. Insert Delete GetRandom O(1) - Duplicates allowed (https://leetcode-cn.com/problems/insert-delete-getrandom-o1-duplicates-allowed/)

/// <summary>
/// 执行用时：220 ms, 在所有 C# 提交中击败了 80.00% 的用户
/// 内存消耗：40.2 MB, 在所有 C# 提交中击败了 75.00% 的用户
/// </summary>
public class RandomizedCollection
{
    private Dictionary<int, int> _records;
    private List<int> _values;
    private int _valuesCount;
    private Random _random;

    /** Initialize your data structure here. */
    public RandomizedCollection()
    {
        this._records = new Dictionary<int, int>();
        this._values = new List<int>();
        this._valuesCount = 0;
        this._random = new Random();
    }

    /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
    public bool Insert(int val)
    {
        bool exist = this._records.ContainsKey(val);
        this._values.Add(val);
        this._valuesCount++;

        if (exist)
        {
            this._records[val] += 1;
        }
        else
        {
            this._records[val] = 1;
        }

        return !exist;
    }

    /** Removes a value from the collection. Returns true if the collection contained the specified element. */
    public bool Remove(int val)
    {
        bool exist = this._records.ContainsKey(val);

        if (exist)
        {
            this._records[val] -= 1;
            this._values.Remove(val);
            this._valuesCount--;

            if (this._records[val] == 0)
            {
                this._records.Remove(val);
            }
        }


        return exist;
    }

    /** Get a random element from the collection. */
    public int GetRandom()
    {
        return this._values[this._random.Next(this._valuesCount)];
    }
}

/**
 * Your RandomizedCollection object will be instantiated and called as such:
 * RandomizedCollection obj = new RandomizedCollection();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */