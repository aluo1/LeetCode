// Question 978. Longest Turbulent Subarray (https://leetcode-cn.com/problems/longest-turbulent-subarray/)

/// <summary>
/// 执行用时：212 ms, 在所有 C# 提交中击败了 56.52% 的用户
/// 内存消耗：40.6 MB, 在所有 C# 提交中击败了 82.61% 的用户
/// 
/// Acknowledgement: This solution borrows idea from the 
/// [official solution](https://leetcode-cn.com/problems/longest-turbulent-subarray/solution/zui-chang-tuan-liu-zi-shu-zu-by-leetcode-t4d8/)
/// </summary>
public class Solution 
{
    public int MaxTurbulenceSize(int[] arr) 
    {
        int maxTurbulentArrayLength = 1;
        int N = arr.Count();
        if (N == 1) { return maxTurbulentArrayLength; }

        int left = 0;
        int right = 0;
        
        while (right < N - 1)
        {
            if (left == right)
            {
                if (arr[left + 1] == arr[left]) { left++; }
                right++;
            }
            else
            {
                if ((arr[right - 1] < arr[right] && arr[right] > arr[right + 1])
                  ||(arr[right - 1] > arr[right] && arr[right] < arr[right + 1]))
                {
                    right++;
                }
                else
                {
                    left = right;    
                }
            }

            maxTurbulentArrayLength = Math.Max(maxTurbulentArrayLength, right - left + 1);
        }

        return maxTurbulentArrayLength;
    }
}