/// Question 542. 01 Matrix (https://leetcode-cn.com/problems/01-matrix/)
/// 执行用时: 564 ms, 在所有 C# 提交中击败了 27.78% 的用户
/// 内存消耗: 48.4 MB, 在所有 C# 提交中击败了 100.00% 的用户

public class Solution
{
    private readonly List<(int, int)> DIRECTIONS = new List<(int, int)>()
    {
        (-1, 0), (1, 0), (0, 1), (0, -1)
    };

    public int[][] UpdateMatrix(int[][] matrix)
    {
        int matrixRowSize = matrix.Count();
        int matrixColumnSize = matrix[0].Count();

        int[][] distanceMatrix = new int[matrixRowSize][];

        // A list storing the visited node.
        Dictionary<(int, int), bool> visitedCooridnates = new Dictionary<(int, int), bool>();
        Queue<(int, int)> queue = new Queue<(int, int)>();

        // Visit all zeros first.
        for (int i = 0; i < matrixRowSize; i++)
        {
            int[] distanceRow = new int[matrixColumnSize];

            for (int j = 0; j < matrixColumnSize; j++)
            {
                if (matrix[i][j] == 0)
                {
                    visitedCooridnates[(i, j)] = true;
                    queue.Enqueue((i, j));
                    distanceRow[j] = 0;
                }
            }

            distanceMatrix[i] = distanceRow;
        }

        while (queue.Any())
        {
            (int row, int column) = queue.Dequeue();

            for (int i = 0; i < this.DIRECTIONS.Count(); i++)
            {
                (int rowDirection, int columnDirection) = this.DIRECTIONS.ElementAt(i);

                int newRow = row + rowDirection;
                int newColumn = column + columnDirection;

                if (newRow >= 0 &&
                    newRow < matrixRowSize &&
                    newColumn >= 0 &&
                    newColumn < matrixColumnSize &&
                    !visitedCooridnates.ContainsKey((newRow, newColumn)))
                {
                    distanceMatrix[newRow][newColumn] = distanceMatrix[row][column] + 1;
                    visitedCooridnates[(newRow, newColumn)] = true;
                    queue.Enqueue((newRow, newColumn));
                }
            }
        }

        return distanceMatrix;
    }
}