/// Question 867. Transpose Matrix (https://leetcode-cn.com/problems/transpose-matrix/)
/// Difficulty: Easy

public class Solution {
    public int[][] Transpose(int[][] A) {
        // 执行用时: 296 ms, 在所有 C# 提交中击败了 95.45% 的用户
        // 内存消耗: 34.9 MB, 在所有 C# 提交中击败了 12.50% 的用户
        if (A.Length == 0) { return A; }
        
        int[][] transposed = new int[A[0].Length][];
        for (int i = 0; i < A[0].Length; i++) {
            int[] transposedColumns = new int[A.Length];
            for (int j = 0; j < A.Length; j++) {
                transposedColumns[j] = A[j][i];
            }
            transposed[i] = transposedColumns;
        }

        return transposed;
    }
}