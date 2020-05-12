/// Question 69. Sqrt(x) (https://leetcode-cn.com/problems/sqrtx/)

public class Solution
{
    // 执行用时: 324 ms, 在所有 C# 提交中击败了 5.60% 的用户
    // 内存消耗: 14.5 MB, 在所有 C# 提交中击败了 33.33% 的用户
    // Acknowledgement: This solution is learnt from the [official solution](https://leetcode-cn.com/problems/sqrtx/solution/x-de-ping-fang-gen-by-leetcode-solution/)
    public int MySqrt(int x)
    {
        int left = 0;
        int right = x;
        int answer = x;

        while (left <= right)
        {
            int mid = left + (right - right) / 2;
            if ((mid == 0 && mid * mid <= x) || (mid != 0 && mid <= x / mid))
            {
                answer = mid;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return answer;
    }
}