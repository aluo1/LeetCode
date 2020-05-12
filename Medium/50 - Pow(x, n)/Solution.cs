/// Question 50. Pow(x, n) (https://leetcode-cn.com/problems/powx-n/)

public class SolutionFirstTry
{
    // This solution failed when n is negative. (e.g. 2.00000, -2)
    public double MyPow(double x, int n)
    {
        double val = 1.0;

        for (int i = 0; i < Math.Abs(n); i++)
        {
            val *= x;
        }

        return val;
    }
}

public class SolutionSecondTry
{
    // This solution will time out when n is too big. (e.g. 0.00001, 2147483647)
    public double MyPow(double x, int n)
    {
        double val = 1.0;

        for (int i = 0; i < Math.Abs(n); i++)
        {
            val *= x;
        }

        return n < 0 ? 1.0 / val : val;
    }
}

public class SolutionThirdTry
{
    // This solution will time out when n is too big. (e.g. 0.00001, 2147483647)
    public double MyPow(double x, int n)
    {
        if (n == 0) { return 1.0; }


        double val = x;

        int i = 1;
        while (true)
        {
            if (i >= Math.Abs(n) - 1) { break; }
            val *= val;
            i *= 2;
        }

        if (n % 2 != 0) { val *= x; }

        return n < 0 ? 1.0 / val : val;
    }
}

public class Solution
{
    // 执行用时: 52 ms, 在所有 C# 提交中击败了 78.26% 的用户
    // 内存消耗: 15 MB, 在所有 C# 提交中击败了 50.00% 的用户
    // Acknowledgement: This solution is borrowed from the [official solution](https://leetcode-cn.com/problems/powx-n/solution/powx-n-by-leetcode-solution/)
    public double MyPow(double x, int n)
    {
        if (n == 0) { return 1.0; }

        double val = 1.0;
        double contribution = x;

        long N = (long)n > 0 ? (long)n : -1 * (long)n;

        while (N > 0)
        {
            if (N % 2 == 1)
            {
                val *= contribution;
            }
            contribution *= contribution;
            N /= 2;
        }

        return n < 0 ? 1.0 / val : val;
    }
}