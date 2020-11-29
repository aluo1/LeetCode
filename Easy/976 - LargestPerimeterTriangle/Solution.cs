// Question 976. Largest Perimeter Triangle (https://leetcode-cn.com/problems/largest-perimeter-triangle/)

public class Solution 
{
    public int LargestPerimeter(int[] A) 
    {
        Array.Sort(A, (a, b) => -1 * a.CompareTo(b));

        int N = A.Count();
        int largestPerimeterSum = int.MinValue;
        
        for (int i = 0; i < N; i++)
        {
            for (int j = i + 1; j < N; j++)
            {
                for (int k = j + 1; k < N; k++)
                {
                    if (this.IsTriangle(A[i], A[j], A[k]))
                    {
                        return A[i] + A[j] + A[k];
                    }
                }
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