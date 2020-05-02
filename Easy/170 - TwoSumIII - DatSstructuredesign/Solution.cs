/// Question 170. Two Sum III - Data structure design (https://leetcode-cn.com/problems/two-sum-iii-data-structure-design/)

public class TwoSum
{
    // 执行用时: 340 ms, 在所有 C# 提交中击败了 25.00% 的用户
    // 内存消耗: 41.7 MB, 在所有 C# 提交中击败了 100.00% 的用户


    Dictionary<int, int> twoSums;

    /** Initialize your data structure here. */
    public TwoSum()
    {
        this.twoSums = new Dictionary<int, int>();
    }

    /** Add the number to an internal data structure.. */
    public void Add(int number)
    {
        if (!this.twoSums.ContainsKey(number))
        {
            this.twoSums[number] = 1;
        }
        else
        {
            this.twoSums[number] = this.twoSums[number] + 1;
        }
    }

    /** Find if there exists any pair of numbers which sum is equal to the value. */
    public bool Find(int value)
    {
        foreach (KeyValuePair<int, int> currentValue in this.twoSums)
        {
            int remainingVal = value - currentValue.Key;

            if (remainingVal == currentValue.Key)
            {
                if (currentValue.Value > 1)
                {
                    return true;
                }
            }
            else
            {
                if (this.twoSums.ContainsKey(remainingVal))
                {
                    return true;
                }
            }
        }

        return false;
    }
}

/**
 * Your TwoSum object will be instantiated and called as such:
 * TwoSum obj = new TwoSum();
 * obj.Add(number);
 * bool param_2 = obj.Find(value);
 */
