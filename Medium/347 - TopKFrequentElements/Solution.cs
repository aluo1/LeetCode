/// <summary>
/// Question 347. Top K Frequent Elements (https://leetcode-cn.com/problems/top-k-frequent-elements/)
/// 
/// 执行用时：284 ms, 在所有 C# 提交中击败了 99.40% 的用户
/// 内存消耗：32.6 MB, 在所有 C# 提交中击败了 44.21% 的用户
/// </summary>
public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> frequency = new Dictionary<int, int>();
        foreach (int num in nums)
        {
            frequency[num] = frequency.ContainsKey(num) ? frequency[num] + 1 : 1;
        }

        List<KeyValuePair<int, int>> frequencyList = frequency.ToList();
        frequencyList.Sort((a, b) => b.Value - a.Value);
        return frequencyList.Take(k).Select(a => a.Key).ToArray();
    }
}