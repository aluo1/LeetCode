// Question 1631. Path With Minimum Effort (https://leetcode-cn.com/problems/path-with-minimum-effort/)

/// <summary>
/// 执行用时：504 ms, 在所有 C# 提交中击败了 28.57% 的用户
/// 内存消耗：32.1 MB, 在所有 C# 提交中击败了 100.00% 的用户
/// 
/// Acknowledgement: This solution is the C#-version duplicate of the [official solution]
/// (https://leetcode-cn.com/problems/path-with-minimum-effort/solution/zui-xiao-ti-li-xiao-hao-lu-jing-by-leetc-3q2j/)
/// </summary>
public class Solution 
{
    private static readonly (int, int)[] DIRECTIONS = { (-1, 0), (1, 0), (0, -1), (0, 1) };

    public int MinimumEffortPath(int[][] heights) 
    {
        int m = heights.Count();
        int n = heights[0].Count();

         int left = 0;
         int right = 999999;
         int answer = 0;

         while (left <= right)
         {
             int mid = (left + right) / 2;
             Queue<(int, int)> queue = new Queue<(int, int)>();
             queue.Enqueue((0, 0));
             bool[] seen = new bool[m * n];
             Array.Fill(seen, false);
             seen[0] = true;

             while (queue.Any())
             {
                var (x, y) = queue.Dequeue();
                foreach (var (xDirection, yDirection) in DIRECTIONS)
                {
                    int nextX = x + xDirection;
                    int nextY = y + yDirection;

                    if (nextX >= 0 && nextX < m && nextY >= 0 && nextY < n 
                    && !seen[nextX * n + nextY] && Math.Abs(heights[x][y] - heights[nextX][nextY]) <= mid)
                    {
                        queue.Enqueue((nextX, nextY));
                        seen[nextX * n + nextY] = true;
                    }
                }
             }

             if (seen[m * n - 1])
             {
                answer = mid;
                right = mid - 1;
             }
             else
             {
                 left = mid + 1;
             }
        }

        return answer;
    }
}