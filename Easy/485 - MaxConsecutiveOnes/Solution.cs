// Question 485. Max Consecutive Ones (https://leetcode-cn.com/problems/max-consecutive-ones/)

/// <summary>
/// 执行用时：168 ms, 在所有 C# 提交中击败了 51.81% 的用户
/// 内存消耗：35 MB, 在所有 C# 提交中击败了 17.57% 的用户
/// </summary>
public class Solution 
{
    public int FindMaxConsecutiveOnes(int[] nums) 
    {
        int maxLength = 0;
        int startIndex = 0;
        int endIndex = 0;

        int N = nums.Count();
        for (var i = 0; i < N; i++)
        {
            if (nums[i] == 1)
            {
                if (nums[startIndex] != 1)
                {
                    startIndex = i;
                    endIndex = i;
                    maxLength = Math.Max(maxLength, 1);
                }
                else
                {
                    endIndex = i;
                    maxLength = Math.Max(maxLength, endIndex - startIndex + 1);
                }
            }
            else
            {
                startIndex = i;
                endIndex = i;
            }
        }

        return maxLength;
    }
}