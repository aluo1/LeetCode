/// Question 279. Perfect Squares (https://leetcode-cn.com/problems/perfect-squares/)

public class Solution
{
    // 执行用时: 164 ms, 在所有 C# 提交中击败了 33.33% 的用户
    // 内存消耗: 30.1 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public int NumSquares(int n)
    {
        HashSet<int> squareNumbers = new HashSet<int>();
        for (int i = 0; i * i <= n; i++)
        {
            squareNumbers.Add(i * i);
        }

        HashSet<int> queue = new HashSet<int>();
        queue.Add(n);

        int level = 0;
        while (queue.Count > 0)
        {
            level++;
            HashSet<int> nextQueue = new HashSet<int>();

            foreach (int val in queue)
            {
                foreach (int squareNumber in squareNumbers)
                {
                    if (squareNumber == val)
                    {
                        return level;
                    }
                    else if (val < squareNumber)
                    {
                        break;
                    }
                    else
                    {
                        nextQueue.Add(val - squareNumber);
                    }
                }
            }

            queue = nextQueue;
        }

        return level;
    }
}