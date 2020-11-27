// Question 454. 4Sum II (https://leetcode-cn.com/problems/4sum-ii/)

/// <summary>
/// 执行用时：200 ms, 在所有 C# 提交中击败了 75.76% 的用户
/// 内存消耗：36 MB, 在所有 C# 提交中击败了 50.00% 的用户
/// </summary>
public class Solution 
{
    public int FourSumCount(int[] A, int[] B, int[] C, int[] D) 
    {
        int N = A.Count();

        Dictionary<int, int> halfSum = new Dictionary<int, int>();
        for(int i = 0; i < N; i++)
        {
            for(int j = 0; j < N; j++)
            {
                int sum = A[i] + B[j];
                if (halfSum.ContainsKey(sum))
                {
                    halfSum[sum]++;
                }
                else
                {
                    halfSum[sum] = 1;
                }
            }
        }

        int count = 0;
        for (int k = 0; k < N; k++)
        {
            for (int l = 0; l < N; l++)
            {
                int sum = C[k] + D[l];
                if (halfSum.ContainsKey(-sum))
                {
                    count += halfSum[-sum];
                }
            }
        }

        return count;
    }
}