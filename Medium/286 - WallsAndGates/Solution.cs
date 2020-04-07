/// Question 286. Walls and Gates (https://leetcode-cn.com/problems/walls-and-gates/)
///
/// 执行用时: 452 ms, 在所有 C# 提交中击败了 15.00% 的用户
/// 内存消耗: 35.2 MB, 在所有 C# 提交中击败了 100.00% 的用户

public class Solution
{
    private readonly List<(int, int)> directions = new List<(int, int)>() {
        (-1, 0),
        (1, 0),
        (0, 1),
        (0, -1)
    };

    public void WallsAndGates(int[][] rooms)
    {
        Queue<(int, int)> queue = new Queue<(int, int)>();
        int rowSize = rooms.Count();

        if (rowSize == 0) { return; }

        int columnSize = rooms[0].Count();

        // Add all rooms to the queue.
        for (int i = 0; i < rowSize; i++)
        {
            for (int j = 0; j < columnSize; j++)
            {
                if (rooms[i][j] == 0)
                {
                    queue.Enqueue((i, j));
                }
            }
        }

        while (queue.Count() > 0)
        {
            var (row, column) = queue.Dequeue();
            foreach (var (rowDirection, columnDirection) in this.directions)
            {
                int newRow = row + rowDirection;
                int newColumn = column + columnDirection;

                if (newRow < 0 || newRow >= rowSize || newColumn < 0 || newColumn >= columnSize || rooms[newRow][newColumn] != Int32.MaxValue)
                {
                    continue;
                }

                rooms[newRow][newColumn] = rooms[row][column] + 1;

                queue.Enqueue((newRow, newColumn));
            }
        }
    }
}