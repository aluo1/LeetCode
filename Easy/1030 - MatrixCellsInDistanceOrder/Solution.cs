// Question 1030. Matrix Cells in Distance Order (https://leetcode-cn.com/problems/matrix-cells-in-distance-order/)

/// <summary>
/// 执行用时：292 ms, 在所有 C# 提交中击败了 100.00% 的用户
/// 内存消耗：32.8 MB, 在所有 C# 提交中击败了 50.00% 的用户
/// </summary>
public class Solution 
{
    private readonly List<int[]> DIRECTIONS = new List<int[]> { new int[2] { -1, 0 }, 
                                                                new int[2] { 1, 0 }, 
                                                                new int[2] { 0, -1 }, 
                                                                new int[2] { 0, 1 }};
    private readonly int X_INDEX = 0;
    private readonly int Y_INDEX = 1;

    public int[][] AllCellsDistOrder(int R, int C, int r0, int c0) 
    {
        int matrixSize = R * C;
        int[][] sortedCells = new int[matrixSize][];
        bool[][] visited = new bool[R][];

        for (int i = 0; i < R; i++) 
        {
            bool[] visitedRow = new bool[C];
            for (int j = 0; j < C; j++)
            {
                visitedRow[j] = i == r0 && j == c0;
            }
            visited[i] = visitedRow;
        }

        int[] initCell = new int[2] { r0, c0 };
        Queue<int[]> queue = new Queue<int[]>();
        int sortedCellIndex = 0;
        queue.Enqueue(initCell);

        while (queue.Count() > 0)
        {
            var currentCell = queue.Dequeue();
            var currentX = currentCell[X_INDEX];
            var currentY = currentCell[Y_INDEX];

            sortedCells[sortedCellIndex++] = currentCell;
            visited[currentX][currentY] = true;            

            foreach (var direction in DIRECTIONS)
            {
                var xDirection = direction[X_INDEX];
                var yDirection = direction[Y_INDEX];

                var newX = currentX + xDirection;
                var newY = currentY + yDirection;

                if (newX >= 0 && newX < R && newY >= 0 && newY < C && !visited[newX][newY])
                {
                    System.Console.WriteLine($"new coordinate = [{newX}, {newY}]");
                    queue.Enqueue(new int[2] { newX, newY });
                }
            }
        }

        return sortedCells;
    }
}