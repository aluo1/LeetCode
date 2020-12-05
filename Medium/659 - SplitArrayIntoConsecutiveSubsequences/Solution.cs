// Question 659. Split Array into Consecutive Subsequences (https://leetcode-cn.com/problems/split-array-into-consecutive-subsequences/)

/// <summary>
/// 执行用时：264 ms, 在所有 C# 提交中击败了 100.00% 的用户
/// 内存消耗：43.4 MB, 在所有 C# 提交中击败了 33.33% 的用户
/// 
/// Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/split-array-into-consecutive-subsequences/solution/fen-ge-shu-zu-wei-lian-xu-zi-xu-lie-by-l-lbs5/)
/// </summary>
public class Solution 
{
    public bool IsPossible(int[] nums) 
    {
        int N = nums.Count();
        Dictionary<int, int> countMap = new Dictionary<int, int>();
        Dictionary<int, int> endMap = new Dictionary<int, int>();
    
        foreach (int num in nums)
        {
            countMap[num] = this.GetOrDefault(countMap, num) + 1;
        }

        foreach (int num in nums)
        {            
            int count = this.GetOrDefault(countMap, num);
            if (count > 0)
            {
                int previousEndCount = this.GetOrDefault(endMap, num - 1);

                if (previousEndCount > 0)
                {
                    countMap[num] = count - 1;
                    endMap[num - 1] = previousEndCount - 1;
                    endMap[num] = this.GetOrDefault(endMap, num) + 1;
                }
                else
                {
                    int count1 = this.GetOrDefault(countMap, num + 1);
                    int count2 = this.GetOrDefault(countMap, num + 2);

                    if (count1 > 0 && count2 > 0)
                    {
                        countMap[num] = count - 1;
                        countMap[num + 1] = count1 - 1;
                        countMap[num + 2] = count2 - 1;
                        endMap[num + 2] = this.GetOrDefault(endMap, num + 2) + 1;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    public int GetOrDefault(Dictionary<int, int> targetDictionary, int key, int defaultValue = 0)
    {
        if (targetDictionary.ContainsKey(key)) { return targetDictionary[key]; }

        return defaultValue;
    }
}