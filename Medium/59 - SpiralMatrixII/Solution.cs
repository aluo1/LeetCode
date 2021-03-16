// Question 59. Spiral Matrix II (https://leetcode-cn.com/problems/spiral-matrix-ii/)

/// <summary>
/// 执行用时：292 ms, 在所有 C# 提交中击败了 8.75% 的用户
/// 内存消耗：25.9 MB, 在所有 C# 提交中击败了 91.25% 的用户
/// 
/// Acknowledgement: This solution is the C#-version of method I of the 
/// [official solution](https://leetcode-cn.com/problems/spiral-matrix-ii/solution/luo-xuan-ju-zhen-ii-by-leetcode-solution-f7fp/)
/// </summary>
public class Solution 
{
    public int[][] GenerateMatrix(int n) 
    {
        int maxNum = n * n;

        int[][] matrix = new int[n][];
        // Initialize the matrix.
        for (int i = 0; i < n; i++)
        {
            int[] row = new int[n];
            for (int j = 0; j < n; j++)
            {
                row[j] = 0;
            }
            matrix[i] =row; 
        } 

        int currentValue = 1;
        int currentRow = 0;
        int currentColumn = 0;

        List<(int, int)> DIRECTIONS = new List<(int, int)> { (0, 1), (1, 0), (0, -1), (-1, 0) };
        int directionIndex = 0;

        while (currentValue <= maxNum)
        {
            matrix[currentRow][currentColumn] = currentValue++;

            (int rowDirection, int columnDirection) = DIRECTIONS[directionIndex];
            int nextRow = currentRow + rowDirection;
            int nextColumn = currentColumn + columnDirection;

            if (nextRow < 0 || nextRow >= n || nextColumn < 0 || nextColumn >= n || matrix[nextRow][nextColumn] != 0) 
            {
                directionIndex = (directionIndex + 1) % DIRECTIONS.Count;
            }

            (rowDirection, columnDirection) = DIRECTIONS[directionIndex];
            currentRow += rowDirection;
            currentColumn += columnDirection;
        }

        return matrix;
    }
}