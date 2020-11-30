// Question 976. Largest Perimeter Triangle (https://leetcode-cn.com/problems/largest-perimeter-triangle/)

/// <summary>
/// 执行用时：172 ms, 在所有 C# 提交中击败了 72.00% 的用户
/// 内存消耗：32.5 MB, 在所有 C# 提交中击败了 20.00% 的用户
/// 
/// Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/largest-perimeter-triangle/solution/san-jiao-xing-de-zui-da-zhou-chang-by-leetcode-sol/)
/// </summary>
public class Solution 
{
    public int LargestPerimeter(int[] A) 
    {
        Array.Sort(A, (a, b) => -1 * a.CompareTo(b));

        int N = A.Count();
        int largestPerimeterSum = int.MinValue;
        
        for (int i = 0; i < N - 2; i++)
        {
            if (this.IsTriangle(A[i], A[i + 1], A[i + 2]))
            {
                return A[i] + A[i + 1] + A[i + 2];
            }
        }

        return 0;
    }

    public bool IsTriangle(int perimeterOne, int perimeterTwo, int perimeterThree)
    {
        return perimeterOne + perimeterTwo > perimeterThree && 
               perimeterOne + perimeterThree > perimeterTwo && 
               perimeterTwo + perimeterThree > perimeterOne;
    }
}