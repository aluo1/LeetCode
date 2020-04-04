/// Question 42. Trapping Rain Water (https://leetcode-cn.com/problems/trapping-rain-water/)
/// Difficulty: Difficult
/// 
/// 执行用时 : 108 ms, 在所有 C# 提交中击败了 74.84% 的用户
/// 内存消耗 : 25 MB, 在所有 C# 提交中击败了9.09% 的用户
/// 
/// Acknowledgement: https://leetcode-cn.com/problems/trapping-rain-water/solution/jie-yu-shui-by-leetcode/
/// 
/// I tried to use the brute force approach, but was told it was time out.

public class Solution
{
    public int Trap(int[] height)
    {
        int water = 0;
        int left = 0;
        int right = height.Count() - 1;
        int leftMax = 0;
        int rightMax = 0;

        while (left < right)
        {
            if (height[left] < height[right])
            {
                if (height[left] > leftMax)
                {
                    leftMax = height[left];
                }
                else
                {
                    water += leftMax - height[left];
                }
                ++left;
            }
            else
            {
                if (height[right] > rightMax)
                {
                    rightMax = height[right];
                }
                else
                {
                    water += rightMax - height[right];
                }
                --right;
            }
        }

        return water;
    }
}