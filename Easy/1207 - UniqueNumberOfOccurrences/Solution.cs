// Question 1207. Unique Number of Occurrences (https://leetcode-cn.com/problems/unique-number-of-occurrences/submissions/)

public class Solution
{
    // 执行用时：132 ms, 在所有 C# 提交中击败了 5.13% 的用户
    // 内存消耗：23.9 MB, 在所有 C# 提交中击败了 21.88% 的用户
    public bool UniqueOccurrences(int[] arr)
    {
        Dictionary<int, int> occurrences = new Dictionary<int, int>();
        foreach (var num in arr)
        {
            if (occurrences.ContainsKey(num))
            {
                occurrences[num] += 1;
            }
            else
            {
                occurrences[num] = 1;
            }
        }

        Dictionary<int, bool> uniqueOccurrences = new Dictionary<int, bool>();
        foreach (var occurrence in occurrences.Values)
        {
            if (uniqueOccurrences.ContainsKey(occurrence))
            {
                return false;
            }
            uniqueOccurrences[occurrence] = true;
        }

        return true;
    }
}