/// 面试题 08.03. 魔术索引 (https://leetcode-cn.com/problems/magic-index-lcci/)

public class Solution
{
    // 执行用时：116 ms, 在所有 C# 提交中击败了 94.74% 的用户
    // 内存消耗：28 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public int FindMagicIndex(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == i)
            {
                return i;
            }
        }

        return -1;
    }
}

public class ProvidedSolution
{
    // This is the C# version of [provided solution](https://leetcode-cn.com/problems/magic-index-lcci/solution/mo-zhu-suo-yin-by-leetcode-solution/).

    // 执行用时：128 ms, 在所有 C# 提交中击败了 44.74% 的用户
    // 内存消耗：28.2 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public int FindMagicIndex(int[] nums)
    {
        return GetAnswer(nums, 0, nums.Length - 1);
    }

    public int GetAnswer(int[] nums, int left, int right)
    {
        if (left > right)
        {
            return -1;
        }

        int mid = (right - left) / 2 + left;

        int leftValue = GetAnswer(nums, left, mid - 1);
        if (leftValue != -1)
        {
            return leftValue;
        }
        else if (nums[mid] == mid)
        {
            return mid;
        }
        else
        {
            return GetAnswer(nums, mid + 1, right);
        }
    }

}