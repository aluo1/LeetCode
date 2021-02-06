// Question 888. Fair Candy Swap (https://leetcode-cn.com/problems/fair-candy-swap/)

/// <summary>
/// 执行用时：376 ms, 在所有 C# 提交中击败了 86.09% 的用户
/// 内存消耗：47.6 MB, 在所有 C# 提交中击败了 37.96% 的用户
/// </summary>
public class Solution 
{
    public int[] FairCandySwap(int[] A, int[] B) 
    {
        int[] answer = new int[2];

        Dictionary<int, int> aCandy = new Dictionary<int, int>();
        int aCandyCount = A.Count();
        for (var i = 0; i < aCandyCount; i++)
        {
            int currentValue = A[i];
            aCandy[currentValue] = aCandy.ContainsKey(currentValue) ? aCandy[currentValue] + 1 : 1;
        }

        int aSum = A.Sum();
        int bSum = B.Sum();

        int halfBAGap = (bSum - aSum) / 2;

        int bCandyCount = B.Count();
        for (int j = 0; j < bCandyCount; j++)
        {
            int y = B[j];
            int x = y - halfBAGap;
            if (aCandy.ContainsKey(x))
            {
                answer[0] = x;
                answer[1] = y;
                break;
            }
        }
    

        return answer;
    }
}
