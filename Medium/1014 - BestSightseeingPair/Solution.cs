/// Question 1014. Best Sightseeing Pair (https://leetcode-cn.com/problems/best-sightseeing-pair/)


public class Solution
{
    // 执行用时: 196 ms, 在所有 C# 提交中击败了 60.00% 的用户
    // 内存消耗: 37.1 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public int MaxScoreSightseeingPair(int[] A)
    {
        int answer = int.MinValue;
        int temp = A[0] + 0;

        for (int i = 1; i < A.Length; i++)
        {
            answer = Math.Max(answer, temp + A[i] - i);
            temp = Math.Max(temp, A[i] + i);
        }

        return answer;
    }

}