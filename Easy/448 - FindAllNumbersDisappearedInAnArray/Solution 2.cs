/// Question 448. Find All Numbers Disappeared in an Array (https://leetcode-cn.com/problems/find-all-numbers-disappeared-in-an-array/)

public class Solution
{
    // 执行用时: 368 ms, 在所有 C# 提交中击败了 88.89% 的用户
    // 内存消耗: 43.3 MB, 在所有 C# 提交中击败了 33.33% 的用户 
    // Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/find-all-numbers-disappeared-in-an-array/solution/zhao-dao-suo-you-shu-zu-zhong-xiao-shi-de-shu-zi-2/)
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        int arrayLength = nums.Count();
        for (int i = 0; i < arrayLength; i++)
        {
            if (nums[Math.Abs(nums[i]) - 1] > 0)
            {
                nums[Math.Abs(nums[i]) - 1] *= -1;
            }
        }

        return nums.Select((num, index) => num > 0 ? index + 1 : -1)
                   .Where(index => index > 0)
                   .ToList();
    }
}