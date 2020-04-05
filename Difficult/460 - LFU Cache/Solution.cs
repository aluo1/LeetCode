/// Question 460. LFU Cache (https://leetcode-cn.com/problems/lfu-cache/submissions/)
/// Difficulty: Difficult

public class LFUCache
{
    /// 执行用时: 772 ms, 在所有 C# 提交中击败了 20.00% 的用户
    /// 内存消耗: 50.4 MB, 在所有 C# 提交中击败了 100.00% 的用户


    // Tuple: <value, reference count, last used time>
    private Dictionary<string, Tuple<int, int, DateTime>> cache;
    private int capacity;

    public LFUCache(int capacity)
    {
        this.cache = new Dictionary<string, Tuple<int, int, DateTime>>();
        this.capacity = capacity;
    }

    public int Get(int key)
    {
        if (!this.cache.ContainsKey(key.ToString())) { return -1; }

        string keyString = key.ToString();
        this.UpdateKeyReferenceDetails(keyString);

        return this.cache[keyString].Item1;
    }

    public void Put(int key, int value)
    {
        string keyString = key.ToString();

        // Check cache capacity first.
        if (this.capacity != 0)
        {
            if (!this.cache.ContainsKey(keyString))
            {
                if (this.cache.Count >= this.capacity)
                {
                    int leastUsedCount = this.cache.Min(record => record.Value.Item2);

                    string leastRecentlyUsedKey = this.cache.Where(record => record.Value.Item2.Equals(leastUsedCount))
                                                            .OrderBy(record => record.Value.Item3)
                                                            .Select(record => record.Key)
                                                            .First();

                    // Console.WriteLine($"Least used count = {leastUsedCount}");
                    // Console.WriteLine($"leastRecentlyUsedKey = {leastRecentlyUsedKey}\n");

                    this.cache.Remove(leastRecentlyUsedKey);
                }
                this.cache[keyString] = new Tuple<int, int, DateTime>(value, 1, DateTime.Now);
            }
            else
            {
                this.UpdateKeyReferenceDetails(keyString, value);
            }
        }

    }

    private void UpdateKeyReferenceDetails(string keyString, int newValue = -1)
    {
        Tuple<int, int, DateTime> currentRecord = this.cache[keyString];
        Tuple<int, int, DateTime> newRecord;
        if (newValue == -1)
        {
            newRecord = new Tuple<int, int, DateTime>(currentRecord.Item1, currentRecord.Item2 + 1, DateTime.Now);
        }
        else
        {
            newRecord = new Tuple<int, int, DateTime>(newValue, currentRecord.Item2 + 1, DateTime.Now);
        }
        this.cache[keyString] = newRecord;
    }
}

public class LFUCacheIntAsKey {
    /// 执行用时: 676 ms, 在所有 C# 提交中击败了 20.00% 的用户
    /// 内存消耗: 50.3 MB, 在所有 C# 提交中击败了 100.00% 的用户


    // Tuple: <value, reference count, last used time>
    private Dictionary<int, Tuple<int, int, DateTime>> cache;
    private int capacity;

    public LFUCache(int capacity) {
        this.cache = new Dictionary<int, Tuple<int, int, DateTime>>();
        this.capacity = capacity;
    }
    
    public int Get(int key) {
        if (!this.cache.ContainsKey(key)) { return -1; }

        this.UpdateKeyReferenceDetails(key);

        return this.cache[key].Item1;
    }
    
    public void Put(int key, int value) {
        // Check cache capacity first.
        if (this.capacity != 0) {
            if (!this.cache.ContainsKey(key)) {
                if (this.cache.Count >= this.capacity) {
                    int leastUsedCount = this.cache.Min(record => record.Value.Item2);

                    int leastRecentlyUsedKey = this.cache.Where(record => record.Value.Item2.Equals(leastUsedCount))
                                                            .OrderBy(record => record.Value.Item3)
                                                            .Select(record => record.Key)
                                                            .First();
                    this.cache.Remove(leastRecentlyUsedKey);
                }
                this.cache[key] = new Tuple<int, int, DateTime>(value, 1, DateTime.Now);
            } else {
                this.UpdateKeyReferenceDetails(key, value);
            }
        }

    }

    private void UpdateKeyReferenceDetails(int key, int newValue = -1) {
        Tuple<int, int, DateTime> currentRecord = this.cache[key];
        Tuple<int, int, DateTime> newRecord;
        if (newValue == -1) {
            newRecord = new Tuple<int, int, DateTime>(currentRecord.Item1, currentRecord.Item2 + 1, DateTime.Now);
        } else {
            newRecord = new Tuple<int, int, DateTime>(newValue, currentRecord.Item2 + 1, DateTime.Now);
        }
        this.cache[key] = newRecord;
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
