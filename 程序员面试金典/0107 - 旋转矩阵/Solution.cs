/// 面试题 01.07. 旋转矩阵 (https://leetcode-cn.com/problems/rotate-matrix-lcci/)
/// Difficulty: Medium

public class Solution
{
    public void Rotate(int[][] matrix)
    {
        return RotateUsingExtraMatrix(matrix);
    }

    public void RotateUsingExtraMatrix(int[][] matrix)
    {
        // 执行用时 : 324 ms, 在所有 C# 提交中击败了 30.00% 的用户
        // 内存消耗 : 30.2 MB, 在所有 C# 提交中击败了 100.00% 的用户
        int matrixSize = matrix.Length;
        int[][] transposed = new int[matrixSize][];

        for (int j = 0; j < matrixSize; j++)
        {
            int[] transposedRow = new int[matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                transposedRow[matrixSize - i - 1] = matrix[i][j];
            }
            transposed[j] = transposedRow;
        }

        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                matrix[i][j] = transposed[i][j];
            }
        }
    }

    public void RotateByFlipping(int[][] matrix)
    {
        // Acknowledgement: Borrows the idea from the [official solution](https://leetcode-cn.com/problems/rotate-matrix-lcci/solution/xuan-zhuan-ju-zhen-by-leetcode-solution/)
        // 执行用时: 320 ms, 在所有 C# 提交中击败了 30.00% 的用户
        // 内存消耗: 30.5 MB, 在所有 C# 提交中击败了 100.00% 的用户

        int matrixSize = matrix.Length;

        // swap the first upper half of the matrix the second lower half.
        for (int i = 0; i < matrixSize / 2; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                int temp1 = matrix[i][j];
                int lowerHalfIndex = matrixSize - i - 1;

                matrix[i][j] = matrix[lowerHalfIndex][j];
                matrix[lowerHalfIndex][j] = temp1;
            }
        }

        // flip diagonally.
        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < i; j++)
            {
                int temp = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = temp;
            }
        }
    }
}