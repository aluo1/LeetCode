// Question 217. Contains Duplicate (https://leetcode-cn.com/problems/contains-duplicate/)

/// <summary>
/// 执行用时：136 ms, 在所有 C# 提交中击败了 56.51% 的用户
/// 内存消耗：31.8 MB, 在所有 C# 提交中击败了 20.56% 的用户
/// </summary>
public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        Dictionary<int, bool> existence = new Dictionary<int, bool>();
        foreach (int num in nums)
        {
            if (existence.ContainsKey(num))
            {
                return true;
            }

            existence[num] = true;
        }

        return false;
    }
}