/// Question 200. Number of Islands (https://leetcode-cn.com/problems/number-of-islands/)
/// 执行用时 : 144 ms, 在所有 C# 提交中击败了 26.06% 的用户
/// 内存消耗 : 27.7 MB, 在所有 C# 提交中击败了 100.00% 的用户

public class Solution
{
    public int NumIslands(char[][] grid)
    {
        List<(int, int)> directions = new List<(int, int)>() { (-1, 0), (1, 0), (0, 1), (0, -1) };

        int gridRows = grid.Count();
        if (gridRows == 0) { return 0; }

        int gridColumns = grid.First().Count();
        List<(int, int)> visitedLands = new List<(int, int)>();
        int islandCount = 0;

        for (int i = 0; i < gridRows; i++)
        {
            for (int j = 0; j < gridColumns; j++)
            {
                if (grid[i][j].Equals('1'))
                {
                    islandCount++;

                    Queue<(int, int)> adjacentLands = new Queue<(int, int)>();
                    adjacentLands.Enqueue((i, j));

                    while (adjacentLands.Count() > 0)
                    {
                        (int landX, int landY) = adjacentLands.Dequeue();

                        for (int k = 0; k < directions.Count(); k++)
                        {
                            (int directionX, int directionY) = directions.ElementAt(k);

                            int newX = landX + directionX;
                            int newY = landY + directionY;

                            if (newX < 0 || newY < 0 ||
                                newX >= gridRows || newY >= gridColumns ||
                                grid[newX][newY].Equals('0'))
                            {
                                continue;
                            }

                            grid[newX][newY] = '0';
                            adjacentLands.Enqueue((newX, newY));
                        }
                    }
                }
            }
        }


        return islandCount;
    }
}