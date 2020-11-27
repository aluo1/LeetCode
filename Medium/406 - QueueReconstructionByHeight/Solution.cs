// Question 406. Queue Reconstruction by Height (https://leetcode-cn.com/problems/queue-reconstruction-by-height/)

/// <summary>
/// 执行用时：316 ms, 在所有 C# 提交中击败了 69.01% 的用户
/// 内存消耗：34 MB, 在所有 C# 提交中击败了 32.39% 的用户
/// 
/// Acknowledgement: This solution borrows idea from [the solution](https://leetcode-cn.com/problems/queue-reconstruction-by-height/solution/xian-pai-xu-zai-cha-dui-dong-hua-yan-shi-suan-fa-g/)
/// </summary>
public class Solution
{
    private readonly int HEIGHT_INDEX = 0;
    private readonly int K_INDEX = 1;

    public int[][] ReconstructQueue(int[][] people)
    {
        // Sort the array based on height.
        Array.Sort(people, (personA, personB) =>
        {
            int comparisonResult = -1 * personA[HEIGHT_INDEX].CompareTo(personB[HEIGHT_INDEX]);

            if (comparisonResult == 0)
            {
                comparisonResult = personA[K_INDEX].CompareTo(personB[K_INDEX]);
            }

            return comparisonResult;
        });


        int N = people.Count();
        int personPointer = 0;


        List<int[]> sortedQueue = new List<int[]>();
        foreach (int[] person in people)
        {
            int height = person[HEIGHT_INDEX];
            int k = person[K_INDEX];

            if (sortedQueue.Count() <= k)
            {
                sortedQueue.Add(person);
            }
            else
            {
                sortedQueue.Insert(k, person);
            }
        }

        return sortedQueue.ToArray();
    }
}