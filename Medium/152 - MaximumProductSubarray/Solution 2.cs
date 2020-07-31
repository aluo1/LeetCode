/// Question 152. Maximum Product Subarray (https://leetcode-cn.com/problems/maximum-product-subarray/)

public class Solution
{
    // 执行用时: 112 ms, 在所有 C# 提交中击败了 67.44% 的用户
    // 内存消耗: 27.2 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public int MaxProduct(int[] nums)
    {
        int maxProduct = nums[0];
        int localMax = nums[0];
        int localMin = nums[0];

        for (int i = 1; i < nums.Count(); i++)
        {
            int num = nums[i];
            int tempMax = localMax;
            int tempMin = localMin;

            localMax = new[] { num, tempMin * num, tempMax * num }.Max();
            localMin = new[] { num, tempMin * num, tempMax * num }.Min();

            maxProduct = Math.Max(maxProduct, localMax);
        }

        return maxProduct;
    }
}