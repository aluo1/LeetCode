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
        List<(int, int)> visitedCooridnates = new List<(int, int)>();
        Queue<(int, int)> queue = new Queue<(int, int)>();

        // Visit all zeros first.
        for (int i = 0; i < matrixRowSize; i++)
        {
            int[] distanceRow = new int[matrixColumnSize];

            for (int j = 0; j < matrixColumnSize; j++)
            {
                if (matrix[i][j] == 0)
                {
                    visitedCooridnates.Add((i, j));
                    queue.Enqueue((i, j));
                    distanceRow[j] = 0;
                }
            }

            distanceMatrix[i] = distanceRow;
        }

        while (queue.Count > 0)
        {
            (int row, int column) = queue.Dequeue();
            foreach ((int rowDirection, int columnDirection) in this.DIRECTIONS)
            {
                int newRow = row + rowDirection;
                int newColumn = column + columnDirection;

                if (newRow < 0 ||
                    newRow >= matrixRowSize ||
                    newColumn < 0 ||
                    newColumn >= matrixColumnSize ||
                    visitedCooridnates.Exists(record => record.Item1.Equals(newRow) && record.Item2.Equals(newColumn)))
                {
                    continue;
                }

                distanceMatrix[newRow][newColumn] = distanceMatrix[row][column] + 1;
                visitedCooridnates.Add((newRow, newColumn));
                queue.Enqueue((newRow, newColumn));
            }
        }

        return distanceMatrix;
    }
}