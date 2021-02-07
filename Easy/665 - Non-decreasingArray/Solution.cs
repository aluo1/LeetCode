// Question 665. Non-decreasing Array (https://leetcode-cn.com/problems/non-decreasing-array/)

/// <summary>
/// 执行用时：152 ms, 在所有 C# 提交中击败了 31.43% 的用户
/// 内存消耗：31.6 MB, 在所有 C# 提交中击败了 38.57% 的用户
/// </summary>
public class Solution 
{
    public bool CheckPossibility(int[] nums) 
    {
        bool elementModified = false;

        int N = nums.Count();
        for (int i = 0; i < N - 1; i++)
        {
            int x = nums[i];
            int y = nums[i + 1];
            if (x > y)
            {
                if (!elementModified)
                {
                    elementModified = true;

                    if (i > 0 && y < nums[i - 1])
                    nums[i + 1] = x;
                }
                else
                {
                    return false;
                }
            }
        }

        return true;
    }
}