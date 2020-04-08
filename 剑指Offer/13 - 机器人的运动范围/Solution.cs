public class Solution
{
    private readonly List<(int, int)> WALKABLE_DIRECTIONS = new List<(int, int)>() { (1, 0), (0, 1) };

    public int MovingCount(int m, int n, int k)
    {
        Queue<(int, int)> queue = new Queue<(int, int)>();
        List<(int, int)> reachableCells = new List<(int, int)>();

        queue.Enqueue((0, 0));
        while (queue.Count > 0)
        {
            (int x, int y) = queue.Dequeue();
            if (!this.ListContainTheCoordinate(reachableCells, (x, y)))
            {
                reachableCells.Add((x, y));
            }

            // Console.WriteLine($"(x, y) = ({x}, {y})");

            foreach ((int xDirection, int yDirection) in WALKABLE_DIRECTIONS)
            {
                int newX = x + xDirection;
                int newY = y + yDirection;

                if (newX >= m || newY >= n || SumOfTheCellCoordinate(newX, newY) > k || this.ListContainTheCoordinate(reachableCells, (newX, newY)))
                {
                    continue;
                }

                queue.Enqueue((newX, newY));
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
        // return digit.ToString().Split("").Select(digitChar => int.Parse(digitChar)).Sum();
    }

    private bool ListContainTheCoordinate(List<(int, int)> recordedCoordinates, (int, int) coordinateToCheck)
    {
        return recordedCoordinates.Exists(coordinate => coordinate.Item1 == coordinateToCheck.Item1 && coordinate.Item2 == coordinateToCheck.Item2);
    }
}