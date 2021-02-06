// Question 1423. Maximum Points You Can Obtain from Cards (https://leetcode-cn.com/problems/maximum-points-you-can-obtain-from-cards/)

/// <summary>
/// 执行用时：204 ms, 在所有 C# 提交中击败了 36.36% 的用户
/// 内存消耗：38.4 MB, 在所有 C# 提交中击败了 100.00% 的用户
/// Acknowledgement: This solution borrows idea from the [official solution]()
/// </summary>
public class Solution 
{
    public int MaxScore(int[] cardPoints, int k) 
    {
        int CARD_COUNT = cardPoints.Count();
        int SLIDING_WINDOW_SIZE = CARD_COUNT - k;
        int CARD_SUM = cardPoints.Sum();

        int windowSum = 0;
        for (int i = 0; i < SLIDING_WINDOW_SIZE; i++)
        {   
            windowSum += cardPoints[i];
        }

        int minSum = windowSum;
        for (int i = SLIDING_WINDOW_SIZE; i < CARD_COUNT; i++)
        {
            // Add the right most of the window in, and substract the left most one of the previous window.
            windowSum += cardPoints[i] - cardPoints[i - SLIDING_WINDOW_SIZE];
            minSum = Math.Min(minSum, windowSum);
        }

        return CARD_SUM - minSum;
    }
}