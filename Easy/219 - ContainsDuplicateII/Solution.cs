/// Question 219. Contains Duplicate II (https://leetcode-cn.com/problems/contains-duplicate-ii/)

public class Solution
{
    // 执行用时: 160 ms, 在所有 C# 提交中击败了 11.46% 的用户
    // 内存消耗: 36.2 MB, 在所有 C# 提交中击败了 100.00% 的用户

    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        Dictionary<int, List<int>> numDictionary = new Dictionary<int, List<int>>();

        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            if (numDictionary.ContainsKey(num))
            {
                List<int> existingIndex = numDictionary[num];
                for (int j = 0; j < existingIndex.Count(); j++)
                {
                    if (Math.Abs(existingIndex[j] - i) <= k)
                    {
                        return true;
                    }
                }

                existingIndex.Add(i);
            }
            else
            {
                numDictionary[num] = new List<int>() { i };
            }
        }

        return false;
    }
}