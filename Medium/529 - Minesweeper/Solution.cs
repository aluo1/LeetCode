/// Question 529. Minesweeper (https://leetcode-cn.com/problems/minesweeper/)

/// <summary>
/// 执行用时：456 ms, 在所有 C# 提交中击败了 34.78% 的用户
/// 内存消耗：35.4 MB, 在所有 C# 提交中击败了 46.15% 的用户
/// </summary>
public class Solution
{
    private const char UNREVEALED_MINE = 'M';
    private const char UNREVEALED_EMPTY = 'E';

    private const char REVEALED_MINE = 'X';
    private const char REVEALED_BLANK = 'B';

    private readonly List<char> UNREVEALED_SQUARES = new List<char> { UNREVEALED_MINE, UNREVEALED_EMPTY };
    private readonly List<char> MINE_SQUARES = new List<char> { REVEALED_MINE, UNREVEALED_MINE };

    public char[][] UpdateBoard(char[][] board, int[] click)
    {
        int x = click[0];
        int y = click[1];

        char clickedSquare = board[x][y];

        // Handle the situation if clicked square is an unrevealed mine.
        if (clickedSquare.Equals(UNREVEALED_MINE))
        {
            board[x][y] = REVEALED_MINE;
            return board;
        }

        Stack<(int, int)> stack = new Stack<(int, int)>();
        stack.Push((x, y));

        while (stack.Any())
        {
            (int currentX, int currentY) = stack.Pop();

            int adjacentMinesCount = 0;
            List<(int, int)> adjacentUnrevealedSquares = new List<(int, int)>();

            for (int xDirection = -1; xDirection <= 1; xDirection++)
            {
                for (int yDirection = -1; yDirection <= 1; yDirection++)
                {
                    if (xDirection == yDirection && xDirection == 0)
                    {
                        continue;
                    }

                    int newX = currentX + xDirection;
                    int newY = currentY + yDirection;

                    if (newX >= 0 && newX < board.Length &&
                        newY >= 0 && newY < board[0].Length &&
                        UNREVEALED_SQUARES.Contains(board[newX][newY]))
                    {
                        adjacentUnrevealedSquares.Add((newX, newY));

                        if (MINE_SQUARES.Contains(board[newX][newY]))
                        {
                            adjacentMinesCount++;
                        }
                    }
                }
            }


            if (!MINE_SQUARES.Contains(board[currentX][currentY]))
            {
                if (adjacentMinesCount == 0)
                {
                    board[currentX][currentY] = REVEALED_BLANK;
                    foreach (var adjacentUnrevealedSquare in adjacentUnrevealedSquares)
                    {
                        stack.Push(adjacentUnrevealedSquare);
                    }
                }
                else
                {
                    board[currentX][currentY] = $"{adjacentMinesCount}"[0];
                }
            }
        }

        return board;
    }
}