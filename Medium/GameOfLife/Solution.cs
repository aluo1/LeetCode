/// Problem 289. Game of Life (https://leetcode-cn.com/problems/game-of-life/)
/// Difficulty: Medium

public class Solution
{
    public void GameOfLife(int[][] board)
    {
        GameOfLifeSecondTry(board);
    }

    public void GameOfLifeFirstTry(int[][] board)
    {
        // 执行用时: 408 ms, 在所有 C# 提交中击败了 16.67% 的用户
        // 内存消耗: 29.9 MB, 在所有 C# 提交中击败了 50.00% 的用户
        int[][] nextGenBoard = new int[board.Length][];

        for (int i = 0; i < board.Length; i++)
        {
            int[] boardRow = new int[board[i].Length];

            for (int j = 0; j < board[0].Length; j++)
            {
                boardRow[j] = UpdateCellStatus(board, i, j);
            }

            nextGenBoard[i] = boardRow;
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                board[i][j] = nextGenBoard[i][j];
            }
        }
    }

    public void GameOfLifeSecondTry(int[][] board)
    {
        // 执行用时: 280 ms, 在所有 C# 提交中击败了 83.33% 的用户
        // 内存消耗: 30.2 MB, 在所有 C# 提交中击败了 50.00% 的用户
        Dictionary<Tuple<int, int>, int> nextGenBoard = new Dictionary<Tuple<int, int>, int>();

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                nextGenBoard[new Tuple<int, int>(i, j)] = UpdateCellStatus(board, i, j);
            }
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                board[i][j] = nextGenBoard[new Tuple<int, int>(i, j)];
            }
        }
    }

    public int UpdateCellStatus(int[][] board, int currentRowIndex, int currentColumnIndex)
    {
        int liveNeighborsCount = 0;

        int currentCellStatus = board[currentRowIndex][currentColumnIndex];

        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if (i == 0 && j == 0) { continue; }

                int neighborRowIndex = currentRowIndex + i;
                int neighborColumnIndex = currentColumnIndex + j;

                if (neighborRowIndex < 0 ||
                    neighborRowIndex >= board.Length ||
                    neighborColumnIndex < 0 ||
                    neighborColumnIndex >= board[0].Length)
                {
                    continue;
                }

                if (board[neighborRowIndex][neighborColumnIndex] == 1)
                {
                    liveNeighborsCount++;
                }
            }
        }

        if (currentCellStatus == 1)
        {
            if (liveNeighborsCount < 2)
            {
                // Rule 1
                return 0;
            }
            else if (liveNeighborsCount == 2 || liveNeighborsCount == 3)
            {
                // Rule 2
                return 1;
            }
            else if (liveNeighborsCount > 3)
            {
                // Rule 3
                return 0;
            }
        }
        else
        {
            if (liveNeighborsCount == 3)
            {
                // Rule 4
                return 1;
            }
        }

        return currentCellStatus;
    }
}