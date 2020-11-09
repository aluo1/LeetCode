// Question 973. K Closest Points to Origin (https://leetcode-cn.com/problems/k-closest-points-to-origin/)

public class Solution 
{
    /// <summary>
    /// 执行用时：576 ms, 在所有 C# 提交中击败了 11.43% 的用户
    /// 内存消耗：50.9 MB, 在所有 C# 提交中击败了 5.72% 的用户
    /// </summary>
    /// <param name="points"></param>
    /// <param name="K"></param>
    /// <returns></returns>
    public int[][] KClosest(int[][] points, int K) 
    {
        Dictionary<long, List<int[]>> distancesToOrigin = new Dictionary<long, List<int[]>>();
        List<long> uniqueDistances = new List<long>();

        foreach (int[] point in points)
        {
            long distance = (long) Math.Pow((point[0] - 0), 2) + (long) Math.Pow((point[1] - 0), 2);
            if (distancesToOrigin.ContainsKey(distance))
            {
                distancesToOrigin[distance].Add(point);
            }
            else
            {
                distancesToOrigin[distance] = new List<int[]>() { point };
                uniqueDistances.Add(distance);
            }

            // System.Console.WriteLine($"point = [{point[0]}, {point[1]}], distance = {distance}");
        }

        uniqueDistances.Sort();

        int[][] closestDistances = new int[K][];
        int i = 0;
        foreach (int distance in uniqueDistances)
        {
            List<int[]> pointsOfCurrentDistance = distancesToOrigin[distance];
            foreach (var pointOfCurrentDistance in pointsOfCurrentDistance)
            {
                if (i == K) { return closestDistances; }
                closestDistances[i++] = pointOfCurrentDistance;
            }
        }

        return closestDistances;
    }
}