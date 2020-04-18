/// Question 11. Container With Most Water (https://leetcode-cn.com/problems/container-with-most-water/)

public class Solution
{
    /// 执行用时: 1204 ms, 在所有 C# 提交中击败了 20.97% 的用户
    /// 内存消耗: 27.6 MB, 在所有 C# 提交中击败了 33.33% 的用户 

    public int MaxArea(int[] height)
    {
        int maxArea = 0;

        int length = height.Count();
        for (int i = 0; i < length - 1; i++)
        {
            for (int j = i + 1; j < length; j++)
            {
                int lowerHeight = Math.Min(height[i], height[j]);
                int area = lowerHeight * (j - i);
                maxArea = Math.Max(maxArea, area);
            }
        }

        return maxArea;
    }
}

public class SolutionUsingTwoPointers
{
    /// 执行用时: 120 ms, 在所有 C# 提交中击败了 87.42% 的用户
    /// 内存消耗: 27.6 MB, 在所有 C# 提交中击败了 33.33% 的用户
    /// Acknowledgement: This idea is borrowed from [the official solution](https://leetcode-cn.com/problems/container-with-most-water/solution/sheng-zui-duo-shui-de-rong-qi-by-leetcode-solution/).

    public int MaxArea(int[] height)
    {
        int maxArea = 0;

        int leftPointer = 0;
        int rightPointer = height.Count() - 1;

        while (leftPointer < rightPointer)
        {
            int lowerHeight;

            if (height[leftPointer] < height[rightPointer])
            {
                lowerHeight = height[leftPointer++];
            }
            else
            {
                lowerHeight = height[rightPointer--];
            }

            int area = lowerHeight * (rightPointer - leftPointer + 1);
            maxArea = Math.Max(maxArea, area);
        }

        return maxArea;
    }
}