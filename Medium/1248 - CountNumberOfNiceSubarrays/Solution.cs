/// Question 1248. Count Number of Nice Subarrays (https://leetcode-cn.com/problems/count-number-of-nice-subarrays/)

public class Solution
{
    public int NumberOfSubarrays(int[] nums, int k)
    {
        int count = 0;
        int arrayLength = nums.Count();

        for (int i = 0; i < arrayLength; i++)
        {
            int oddCount = 0;
            for (int j = i; j < arrayLength; j++)
            {
                int currentNumber = nums[j];
                if (currentNumber % 2 != 0)
                {
                    oddCount += 1;
                }

                if (oddCount == k)
                {
                    count++;
                }
                else if (oddCount > k)
                {
                    break;
                }
            }
        }

        return count;
    }
}