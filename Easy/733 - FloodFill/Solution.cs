/// Question 733. Flood Fill (https://leetcode-cn.com/problems/flood-fill/submissions/)

public class Solution
{
    /// 执行用时: 324 ms, 在所有 C# 提交中击败了 16.67% 的用户
    /// 内存消耗: 33 MB, 在所有 C# 提交中击败了 100.00% 的用户

    private readonly List<(int, int)> DIRECTIONS = new List<(int, int)>()
    {
        (-1, 0), (1, 0), (0, 1), (0, -1)
    };

    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
    {
        int imageRowCount = image.Count();
        int imageColumnCount = image[0].Count();
        if (imageRowCount == 0) { return image; }

        int[][] floodedImage = new int[imageRowCount][];
        for (int i = 0; i < imageRowCount; i++)
        {
            int[] floodedRow = new int[imageColumnCount];
            for (int j = 0; j < imageColumnCount; j++)
            {
                floodedRow[j] = image[i][j];
            }
            floodedImage[i] = floodedRow;
        }

        int startingPixelValue = image[sr][sc];
        floodedImage[sr][sc] = newColor;

        Queue<(int, int)> floodedPixels = new Queue<(int, int)>();
        floodedPixels.Enqueue((sr, sc));

        while (floodedPixels.Any())
        {
            (int currentRow, int currentColumn) = floodedPixels.Dequeue();

            foreach ((int rowDirection, int columnDirection) in this.DIRECTIONS)
            {
                int newRow = currentRow + rowDirection;
                int newColumn = currentColumn + columnDirection;

                if (newRow < imageRowCount && newRow >= 0 &&
                    newColumn < imageColumnCount && newColumn >= 0 &&
                    image[newRow][newColumn] == startingPixelValue &&
                    floodedImage[newRow][newColumn] != newColor)
                {
                    floodedImage[newRow][newColumn] = newColor;
                    floodedPixels.Enqueue((newRow, newColumn));
                }

            }
        }

        return floodedImage;
    }
}