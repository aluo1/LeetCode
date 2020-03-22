// Question 945. Minimum Increment to Make Array Unique (https://leetcode-cn.com/problems/minimum-increment-to-make-array-unique/)
// Difficulty: Medium

public class Solution
{
    public int MinIncrementForUnique(int[] A)
    {
        // 执行用时: 196 ms, 在所有 C# 提交中击败了 100.00% 的用户
        // 内存消耗: 35.3 MB, 在所有 C# 提交中击败了 50.00% 的用户

        if (A.Count() <= 1) { return 0; }

        Array.Sort(A);
        int steps = 0;

        for (int i = 0; i < A.Length - 1; i++)
        {
            if (A[i] >= A[i + 1])
            {
                // we need Ai - A(i+1) + 1 steps to make sure these two won't overlap.
                steps += A[i] - A[i + 1] + 1;
                A[i + 1] = A[i] + 1;
            }
        }

        return steps;
    }
}