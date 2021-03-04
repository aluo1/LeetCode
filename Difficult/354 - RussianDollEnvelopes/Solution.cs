// Question 354. Russian Doll Envelopes (https://leetcode-cn.com/problems/russian-doll-envelopes/)

/// <summary>
/// 执行用时：152 ms, 在所有 C# 提交中击败了 86.67% 的用户
/// 内存消耗：29.6 MB, 在所有 C# 提交中击败了 80.00% 的用户
/// 
/// Acknowledgement: This solution is the C#-version duplicate of the 
/// [official solution](https://leetcode-cn.com/problems/russian-doll-envelopes/solution/e-luo-si-tao-wa-xin-feng-wen-ti-by-leetc-wj68/)
/// method II.
/// </summary>
public class Solution 
{
    public int MaxEnvelopes(int[][] envelopes) 
    {
        int N = envelopes.Count();
        if (N == 0) { return 0; }

        Array.Sort(envelopes, (e1, e2) => 
        {
            int firstDigitComparison = e1[0] - e2[0];
            if (firstDigitComparison != 0) { return firstDigitComparison; }

            return -1 * (e1[1] - e2[1]);
        });

        List<int> f = new List<int>() { envelopes[0][1] };
        int fSize = 1;

        for (int i = 1; i < N; i++)
        {
            int num = envelopes[i][1];
            if (num > f[fSize - 1])
            {
                f.Add(num);
                fSize++;
            }
            else
            {
                int index = BinarySearch(f, num, fSize);
                f[index] = num;
            }
        }

        return fSize;
    }

    private int BinarySearch(List<int> f, int target, int fSize)
    {
        int low = 0, high = fSize - 1;

        while (low < high) {
            int mid = (high - low) / 2 + low;
            if (f[mid] < target) {
                low = mid + 1;
            } else {
                high = mid;
            }
        }

        return low;
    }
}