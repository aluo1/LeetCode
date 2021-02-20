// Question 1004. Max Consecutive Ones III (https://leetcode-cn.com/problems/max-consecutive-ones-iii/)

/// <summary>
/// 执行用时：216 ms, 在所有 C# 提交中击败了 52.94% 的用户
/// 内存消耗：39 MB, 在所有 C# 提交中击败了 41.18% 的用户
/// 
/// Acknowledgement: This solution borrows idea from the 
/// [official solution](https://leetcode-cn.com/problems/max-consecutive-ones-iii/solution/fen-xiang-hua-dong-chuang-kou-mo-ban-mia-f76z/)
/// </summary>
public class Solution 
{
    public int LongestOnes(int[] A, int K) 
    {
        int N = A.Count();
        
        int left = 0;
        int right = 0;
        int result = 0;

        while (right < N)
        {
            if (A[right] == 0) 
            {
                K--;
            }

            while (K < 0)
            {
                K += A[left] == 0 ? 1 : 0;
                left++;
            }
            
            result = Math.Max(result, right - left + 1);
            right++;
        }

        return result;
    }
}