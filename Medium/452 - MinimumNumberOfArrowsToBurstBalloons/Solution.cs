// Question 452. Minimum Number of Arrows to Burst Balloons (https://leetcode-cn.com/problems/minimum-number-of-arrows-to-burst-balloons/)

/// <summary>
/// 执行用时：276 ms, 在所有 C# 提交中击败了 48.39% 的用户
/// 内存消耗：39.7 MB, 在所有 C# 提交中击败了 70.97% 的用户
/// 
/// Acknowledgement: This solution is a C#-version duplicate of the [official solution](https://leetcode-cn.com/problems/minimum-number-of-arrows-to-burst-balloons/solution/yong-zui-shao-shu-liang-de-jian-yin-bao-qi-qiu-1-2/)
/// </summary>
public class Solution 
{
    private readonly int START_INDEX = 0;
    private readonly int END_INDEX = 1;

    public int FindMinArrowShots(int[][] points) 
    {
        if (points.Length == 0) { return 0; }

        Array.Sort(points, (pointA, pointB) => pointA[END_INDEX].CompareTo(pointB[END_INDEX]));
        
        int pos = points[0][END_INDEX];
        int answer = 1;
        foreach (int[] point in points)
        {
            if (point[START_INDEX] > pos)
            {
                pos = point[END_INDEX];
                answer++;
            }
            
        }

        return answer;
    }
}