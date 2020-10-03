/// Question 1. Two Sum (https://leetcode-cn.com/problems/two-sum/)
/// Difficulty: Easy


public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        /// 执行用时: 480 ms.
        /// 内存消耗: 30.5 MB.
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new int[] { i, j };
                }
            }
        }

        return new int[2];
    }

    public int[] TwoSumUsingDictionary(int[] nums, int target)
    {
        // 执行用时：300 ms, 在所有 C# 提交中击败了 75.69% 的用户
        // 内存消耗：31.9 MB, 在所有 C# 提交中击败了 5.01% 的用户
        Dictionary<int, List<int>> indexDictionary = new Dictionary<int, List<int>>();

        for (int index = 0; index < nums.Length; index++)
        {
            int num = nums[index];
            if (indexDictionary.ContainsKey(num))
            {
                indexDictionary[num].Add(index);
            }
            else
            {
                indexDictionary[nums[index]] = new List<int>() { index };
            }
        }

        foreach (int num in nums)
        {
            if (indexDictionary.ContainsKey(num))
            {
                int remainingValue = target - num;

                if (remainingValue == num)
                {
                    if (indexDictionary[remainingValue].Count >= 2)
                    {
                        return indexDictionary[remainingValue].Take(2).ToArray();
                    }
                }
                else
                {
                    if (indexDictionary.ContainsKey(remainingValue))
                    {
                        return new int[] { indexDictionary[num][0], indexDictionary[remainingValue][0] };
                    }
                }
            }
        }

        // This will never be reached as it is guaranteed to have exactly one solution.
        return new int[2];
    }
}
