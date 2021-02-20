// Question 697. Degree of an Array (https://leetcode-cn.com/problems/degree-of-an-array/)

/// <summary>
/// 执行用时：140 ms, 在所有 C# 提交中击败了 100.00% 的用户
/// 内存消耗：32.1 MB, 在所有 C# 提交中击败了 76.00% 的用户
/// </summary>
public class Solution 
{
    public int FindShortestSubArray(int[] nums) 
    {
        Dictionary<int, (int, int, int)> elementsMapping = new Dictionary<int, (int, int, int)>();
        int N = nums.Count();
        int maxFrequency = 0;

        // Create a mapping for elements.
        for (int i = 0; i < N; i++)
        {
            int element = nums[i];
            if (elementsMapping.ContainsKey(element))
            {
                (int startIndex, int endIndex, int frequency) = elementsMapping[element];
                frequency++;
                elementsMapping[element] = (startIndex, Math.Max(endIndex, i), frequency);
                maxFrequency = Math.Max(frequency, maxFrequency);
            }
            else
            {
                elementsMapping[element] = (i, i, 1);
                maxFrequency = Math.Max(1, maxFrequency);
            }
        }

        int minLength = N;
        foreach ((int startIndex, int endIndex, int frequency) in elementsMapping.Values)
        {
            if (frequency == maxFrequency)
            {
                minLength = Math.Min(minLength, endIndex - startIndex + 1);
            }
        }

        return minLength;
    }
}