/// Question 1248. Count Number of Nice Subarrays (https://leetcode-cn.com/problems/count-number-of-nice-subarrays/)

public class Solution
{
    /// 执行用时: 300 ms, 在所有 C# 提交中击败了 50.00% 的用户
    /// 内存消耗: 44 MB, 在所有 C# 提交中击败了 100.00% 的用户
    /// Acknowledgement: This idea is borrowed from the [official solution](https://leetcode-cn.com/problems/count-number-of-nice-subarrays/solution/tong-ji-you-mei-zi-shu-zu-by-leetcode-solution/).
    public int NumberOfSubarrays(int[] nums, int k)
    {
        // Initialize with -1 at index 0
        List<int> oddNumsIndex = new List<int>() { -1 };

        for (int i = 0; i < nums.Count(); i++)
        {
            if (nums[i] % 2 == 1)
            {
                oddNumsIndex.Add(i);
            }
        }

        oddNumsIndex.Add(nums.Count());

        int arrayCount = 0;
        for (int i = 1; i < oddNumsIndex.Count() - k; i++)
        {
            arrayCount += (oddNumsIndex.ElementAt(i) - oddNumsIndex.ElementAt(i - 1)) * (oddNumsIndex.ElementAt(i + k) - oddNumsIndex.ElementAt(i + k - 1));
        }

        return arrayCount;
    }
}