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

public class SolutionOfficialSolution
{
    // 执行用时: 132 ms, 在所有 C# 提交中击败了 39.58% 的用户
    // 内存消耗: 27.7 MB, 在所有 C# 提交中击败了 100.00% 的用户
    // Acknowledgement: This is a C#-version replicate of the [official solution](https://leetcode-cn.com/problems/contains-duplicate-ii/solution/cun-zai-zhong-fu-yuan-su-ii-by-leetcode/)
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        HashSet<int> numSet = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int currentValue = nums[i];

            if (numSet.Contains(currentValue))
            {
                return true;
            }

            numSet.Add(currentValue);
            if (numSet.Count() > k)
            {
                numSet.Remove(nums[i - k]);
            }
        }

        return false;
    }
}

public class SolutionTopRated
{
    // 执行用时: 132 ms, 在所有 C# 提交中击败了 39.58% 的用户
    // 内存消耗: 29.3 MB, 在所有 C# 提交中击败了 100.00% 的用户
    // Acknowledgement: This is the top rated solution, but I cannot achieve the same time/space consumption as it is.
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (dic.ContainsKey(nums[i]))
            {
                if (i - dic[nums[i]] <= k) return true;
                else if (i - dic[nums[i]] > k) dic[nums[i]] = i;
            }

            else dic.Add(nums[i], i);
        }
        return false;
    }
}