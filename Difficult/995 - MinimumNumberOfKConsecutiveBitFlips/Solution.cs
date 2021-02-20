// Question 995. Minimum Number of K Consecutive Bit Flips (https://leetcode-cn.com/problems/minimum-number-of-k-consecutive-bit-flips/)

/// <summary>
/// 执行用时：296 ms, 在所有 C# 提交中击败了 100.00% 的用户
/// 内存消耗：43.4 MB, 在所有 C# 提交中击败了 100.00% 的用户
/// 
/// Acknowledgement: This solution is a C# version duplicate of 
/// [this solution](https://leetcode-cn.com/problems/minimum-number-of-k-consecutive-bit-flips/solution/hua-dong-chuang-kou-shi-ben-ti-zui-rong-z403l/)
/// </summary>
public class Solution 
{
    public int MinKBitFlips(int[] A, int K) 
    {
        int N = A.Count();
        int result = 0;
        Queue<int> queue = new Queue<int>();

        for (var i = 0; i < N; i++)
        {
            if (queue.Any() && i > queue.Peek() + K - 1)
            {
                queue.Dequeue();
            }

            if (queue.Count() % 2 == A[i])
            {
                if (i + K > N) { return -1; }

                queue.Enqueue(i);
                result++;
            }
        }

        return result;
    }
}