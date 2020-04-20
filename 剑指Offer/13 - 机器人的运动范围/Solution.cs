/// 面试题13. 机器人的运动范围 (https://leetcode-cn.com/problems/ji-qi-ren-de-yun-dong-fan-wei-lcof/)
/// Difficulty: Medium
/// 
/// 执行用时 : 72 ms, 在所有 C# 提交中击败了 13.33% 的用户
/// 内存消耗 : 17.1 MB, 在所有 C# 提交中击败了 100.00% 的用户

public class Solution
{
    private readonly List<(int, int)> WALKABLE_DIRECTIONS = new List<(int, int)>() { (1, 0), (0, 1) };

    public int MovingCount(int m, int n, int k)
    {
        Queue<(int, int)> queue = new Queue<(int, int)>();
        HashSet<(int, int)> reachableCells = new HashSet<(int, int)>();

        queue.Enqueue((0, 0));
        while (queue.Count > 0)
        {
            (int x, int y) = queue.Dequeue();
            if (!reachableCells.Contains((x, y)))
            {
                reachableCells.Add((x, y));

                foreach ((int xDirection, int yDirection) in WALKABLE_DIRECTIONS)
                {
                    int newX = x + xDirection;
                    int newY = y + yDirection;

                    if (newX >= m || newY >= n || SumOfTheCellCoordinate(newX, newY) > k || reachableCells.Contains((newX, newY)))
                    {
                        continue;
                    }

                    queue.Enqueue((newX, newY));
                }
            }
        }

        return reachableCells.Count;
    }

    private int SumOfTheCellCoordinate(int x, int y)
    {
        return this.SumOfTheDigit(x) + this.SumOfTheDigit(y);
    }

    private int SumOfTheDigit(int digit)
    {
        int sum = 0;
        while (digit != 0)
        {
            sum += digit % 10;
            digit /= 10;
        }
        return sum;
    }

    private bool ListContainTheCoordinate(List<(int, int)> recordedCoordinates, (int, int) coordinateToCheck)
    {
        return recordedCoordinates.Exists(coordinate => coordinate.Item1 == coordinateToCheck.Item1 && coordinate.Item2 == coordinateToCheck.Item2);
    }
}