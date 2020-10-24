// Question 1024. Video Stitching (https://leetcode-cn.com/problems/video-stitching/)

using System;

public class Solution
{
    /// <summary>
    /// 执行用时：100 ms, 在所有 C# 提交中击败了 100.00% 的用户
    /// 内存消耗：24.2 MB, 在所有 C# 提交中击败了 50.00% 的用户
    /// 
    /// Acknowledgement: This solution is just a C# version of the 
    /// [official solution](https://leetcode-cn.com/problems/video-stitching/solution/shi-pin-pin-jie-by-leetcode-solution/) 
    /// method II.
    /// </summary>
    /// <param name="clips"></param>
    /// <param name="T"></param>
    /// <returns></returns>
    public int VideoStitching(int[][] clips, int T)
    {
        int[] maxN = new int[T];
        foreach (int[] clip in clips)
        {
            int startTime = clip[0];
            int endTime = clip[1];

            if (startTime < T)
            {
                maxN[startTime] = Math.Max(maxN[startTime], endTime);
            }
        }

        int last = 0;
        int previousEnd = 0;
        int clipsCount = 0;

        for (int i = 0; i < T; i++)
        {
            last = Math.Max(last, maxN[i]);
            if (last == i)
            {
                return -1;
            }

            if (i == previousEnd)
            {
                clipsCount++;
                previousEnd = last;
            }
        }

        return clipsCount;
    }

    /// <summary>
    /// 执行用时：104 ms, 在所有 C# 提交中击败了 100.00% 的用户
    /// 内存消耗：24.5 MB, 在所有 C# 提交中击败了 25.00% 的用户
    /// 
    /// Acknowledgement: This solution is just a C# version of the 
    /// [official solution](https://leetcode-cn.com/problems/video-stitching/solution/shi-pin-pin-jie-by-leetcode-solution/) 
    /// method I.
    /// </summary>
    /// <param name="clips"></param>
    /// <param name="T"></param>
    /// <returns></returns>
    public int VideoStitchingDP(int[][] clips, int T)
    {
        int[] dp = new int[T + 1];
        Array.Fill(dp, int.MaxValue - 1);

        dp[0] = 0;

        for (int i = 1; i <= T; i++)
        {
            foreach (int[] clip in clips)
            {
                var startTime = clip[0];
                var endTime = clip[1];

                if (startTime < i && i <= endTime)
                {
                    dp[i] = Math.Min(dp[i], dp[startTime] + 1);
                }
            }
        }

        return dp[T] == int.MaxValue - 1 ? -1 : dp[T];
    }
}